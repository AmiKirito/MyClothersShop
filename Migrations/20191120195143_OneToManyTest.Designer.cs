﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MyClothersShop.Models;

namespace MyClothersShop.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20191120195143_OneToManyTest")]
    partial class OneToManyTest
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MyClothersShop.Models.Cloth", b =>
                {
                    b.Property<int>("ClothId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ClothId");

                    b.ToTable("Clothers");

                    b.HasData(
                        new
                        {
                            ClothId = 1,
                            Description = "You just can wear it anywhere :)",
                            Price = 250,
                            Title = "T-Short"
                        },
                        new
                        {
                            ClothId = 2,
                            Description = "Really comfortable and suits for any occasion",
                            Price = 500,
                            Title = "Jeans"
                        });
                });

            modelBuilder.Entity("MyClothersShop.Models.Image", b =>
                {
                    b.Property<int>("ImageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ClothId")
                        .HasColumnType("int");

                    b.Property<string>("PhotoPath")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ImageId");

                    b.HasIndex("ClothId");

                    b.ToTable("Images");

                    b.HasData(
                        new
                        {
                            ImageId = 1,
                            ClothId = 1,
                            PhotoPath = "original_images/t-short.jpg"
                        },
                        new
                        {
                            ImageId = 2,
                            ClothId = 2,
                            PhotoPath = "original_images/jeans.jpg"
                        },
                        new
                        {
                            ImageId = 3,
                            ClothId = 1,
                            PhotoPath = "original_images/logo.png"
                        },
                        new
                        {
                            ImageId = 4,
                            ClothId = 2,
                            PhotoPath = "original_images/test.png"
                        });
                });

            modelBuilder.Entity("MyClothersShop.Models.Image", b =>
                {
                    b.HasOne("MyClothersShop.Models.Cloth", "Cloth")
                        .WithMany("Images")
                        .HasForeignKey("ClothId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
