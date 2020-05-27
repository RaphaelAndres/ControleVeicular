using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ControleVeicular.WebApi.Migrations
{
    public partial class Criaçãodasmodels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AdvertisementPictures",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    AdvertisementId = table.Column<Guid>(nullable: false),
                    PictureUrl = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdvertisementPictures", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Advertisements",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    VehicleId = table.Column<Guid>(nullable: false),
                    BuyPrice = table.Column<float>(nullable: false),
                    SellPrice = table.Column<float>(nullable: false),
                    FabricationYear = table.Column<int>(nullable: false),
                    ModelYear = table.Column<int>(nullable: false),
                    Color = table.Column<string>(nullable: true),
                    FuelType = table.Column<string>(nullable: true),
                    SellDate = table.Column<DateTime>(nullable: false),
                    DriveTrain = table.Column<string>(nullable: true),
                    TransmissionType = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Advertisements", x => x.Id);
                });

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
                    BrandId = table.Column<int>(nullable: false),
                    ModelName = table.Column<string>(nullable: true),
                    ModelSpecification = table.Column<string>(nullable: true),
                    EngineDisplacement = table.Column<int>(nullable: false),
                    Bodytype = table.Column<string>(nullable: true),
                    EngineSpecification = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicles", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdvertisementPictures");

            migrationBuilder.DropTable(
                name: "Advertisements");

            migrationBuilder.DropTable(
                name: "Brands");

            migrationBuilder.DropTable(
                name: "Vehicles");
        }
    }
}
