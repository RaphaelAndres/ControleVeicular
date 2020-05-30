using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ControleVeicular.Repository.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Brands",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Nome = table.Column<string>(nullable: true),
                    Pais = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brands", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Vehicles",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ModelName = table.Column<string>(nullable: true),
                    ModelSpecification = table.Column<string>(nullable: true),
                    EngineDisplacement = table.Column<int>(nullable: true),
                    Bodytype = table.Column<string>(nullable: true),
                    EngineSpecification = table.Column<string>(nullable: true),
                    BrandId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vehicles_Brands_BrandId",
                        column: x => x.BrandId,
                        principalTable: "Brands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Advertisements",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    BuyPrice = table.Column<float>(nullable: false),
                    SellPrice = table.Column<float>(nullable: true),
                    FabricationYear = table.Column<int>(nullable: true),
                    ModelYear = table.Column<int>(nullable: true),
                    Color = table.Column<string>(nullable: true),
                    FuelType = table.Column<string>(nullable: true),
                    SellDate = table.Column<DateTime>(nullable: true),
                    DriveTrain = table.Column<string>(nullable: true),
                    TransmissionType = table.Column<string>(nullable: true),
                    VehicleId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Advertisements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Advertisements_Vehicles_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "Vehicles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AdvertisementPhotos",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    AdvertisementId = table.Column<Guid>(nullable: false),
                    PhotoURL = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdvertisementPhotos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AdvertisementPhotos_Advertisements_AdvertisementId",
                        column: x => x.AdvertisementId,
                        principalTable: "Advertisements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AdvertisementPhotos_AdvertisementId",
                table: "AdvertisementPhotos",
                column: "AdvertisementId");

            migrationBuilder.CreateIndex(
                name: "IX_Advertisements_VehicleId",
                table: "Advertisements",
                column: "VehicleId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_BrandId",
                table: "Vehicles",
                column: "BrandId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdvertisementPhotos");

            migrationBuilder.DropTable(
                name: "Advertisements");

            migrationBuilder.DropTable(
                name: "Vehicles");

            migrationBuilder.DropTable(
                name: "Brands");
        }
    }
}
