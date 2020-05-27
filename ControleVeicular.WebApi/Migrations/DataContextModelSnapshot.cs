﻿// <auto-generated />
using System;
using ControleVeicular.WebApi.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ControleVeicular.WebApi.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ControleVeicular.WebApi.Model.Advertisement", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<float>("BuyPrice");

                    b.Property<string>("Color");

                    b.Property<string>("DriveTrain");

                    b.Property<int>("FabricationYear");

                    b.Property<string>("FuelType");

                    b.Property<int>("ModelYear");

                    b.Property<DateTime>("SellDate");

                    b.Property<float>("SellPrice");

                    b.Property<string>("TransmissionType");

                    b.Property<Guid>("VehicleId");

                    b.HasKey("Id");

                    b.ToTable("Advertisements");
                });

            modelBuilder.Entity("ControleVeicular.WebApi.Model.AdvertisementPicture", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("AdvertisementId");

                    b.Property<string>("PictureUrl");

                    b.HasKey("Id");

                    b.ToTable("AdvertisementPictures");
                });

            modelBuilder.Entity("ControleVeicular.WebApi.Model.Brand", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Nome");

                    b.Property<string>("Pais");

                    b.HasKey("Id");

                    b.ToTable("Brands");
                });

            modelBuilder.Entity("ControleVeicular.WebApi.Model.Vehicle", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Bodytype");

                    b.Property<int>("BrandId");

                    b.Property<int>("EngineDisplacement");

                    b.Property<string>("EngineSpecification");

                    b.Property<string>("ModelName");

                    b.Property<string>("ModelSpecification");

                    b.HasKey("Id");

                    b.ToTable("Vehicles");
                });
#pragma warning restore 612, 618
        }
    }
}
