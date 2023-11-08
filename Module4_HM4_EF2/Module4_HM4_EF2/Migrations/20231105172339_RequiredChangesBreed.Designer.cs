﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Module4_HM4_EF2.DbData.Context;

#nullable disable

namespace Module4_HM4_EF2.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20231105172339_RequiredChangesBreed")]
    partial class RequiredChangesBreed
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Module4_HM4_EF2.DbData.Models.Breed", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("BreedName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.HasKey("Id")
                        .HasName("PK_BreedId");

                    b.HasIndex("CategoryId");

                    b.ToTable("Breeds");
                });

            modelBuilder.Entity("Module4_HM4_EF2.DbData.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id")
                        .HasName("PK_CategoryId");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("Module4_HM4_EF2.DbData.Models.Food", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("FoodName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FoodType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id")
                        .HasName("PK_FoodId");

                    b.ToTable("Food");
                });

            modelBuilder.Entity("Module4_HM4_EF2.DbData.Models.Location", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("LocationName")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id")
                        .HasName("PK_LocationId");

                    b.HasIndex("LocationName")
                        .IsUnique()
                        .HasDatabaseName("IX_LocationName");

                    b.ToTable("Locations");
                });

            modelBuilder.Entity("Module4_HM4_EF2.DbData.Models.Pet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("Age")
                        .HasColumnType("int");

                    b.Property<int>("BreedId")
                        .HasColumnType("int");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("LocationId")
                        .HasColumnType("int");

                    b.Property<int?>("PetInsuranceId")
                        .HasColumnType("int");

                    b.Property<string>("PetName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id")
                        .HasName("PK_PetId");

                    b.HasIndex("BreedId");

                    b.HasIndex("CategoryId");

                    b.HasIndex("LocationId");

                    b.HasIndex("PetInsuranceId")
                        .IsUnique()
                        .HasFilter("[PetInsuranceId] IS NOT NULL");

                    b.ToTable("Pets");
                });

            modelBuilder.Entity("Module4_HM4_EF2.DbData.Models.PetFood", b =>
                {
                    b.Property<int>("PetId")
                        .HasColumnType("int");

                    b.Property<int>("FoodId")
                        .HasColumnType("int");

                    b.HasKey("PetId", "FoodId")
                        .HasName("PK_PetFoodId");

                    b.HasIndex("FoodId");

                    b.ToTable("PetFood");
                });

            modelBuilder.Entity("Module4_HM4_EF2.DbData.Models.PetInsurance", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("EndInsuranceDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("PetId")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartInsuranceDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id")
                        .HasName("PK_PetInsuranceId");

                    b.ToTable("PetInsurance");
                });

            modelBuilder.Entity("Module4_HM4_EF2.DbData.Models.Breed", b =>
                {
                    b.HasOne("Module4_HM4_EF2.DbData.Models.Category", "Category")
                        .WithMany("Breeds")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired()
                        .HasConstraintName("FK_Breed_CategoryId");

                    b.Navigation("Category");
                });

            modelBuilder.Entity("Module4_HM4_EF2.DbData.Models.Pet", b =>
                {
                    b.HasOne("Module4_HM4_EF2.DbData.Models.Breed", "Breed")
                        .WithMany("Pets")
                        .HasForeignKey("BreedId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired()
                        .HasConstraintName("FK_Pet_BreedId");

                    b.HasOne("Module4_HM4_EF2.DbData.Models.Category", "Category")
                        .WithMany("Pets")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired()
                        .HasConstraintName("FK_Pet_CategoryId");

                    b.HasOne("Module4_HM4_EF2.DbData.Models.Location", "Location")
                        .WithMany("Pets")
                        .HasForeignKey("LocationId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired()
                        .HasConstraintName("FK_Pet_LocationId");

                    b.HasOne("Module4_HM4_EF2.DbData.Models.PetInsurance", "PetInsurance")
                        .WithOne("Pet")
                        .HasForeignKey("Module4_HM4_EF2.DbData.Models.Pet", "PetInsuranceId")
                        .OnDelete(DeleteBehavior.SetNull)
                        .HasConstraintName("FK_Insurance_PetId");

                    b.Navigation("Breed");

                    b.Navigation("Category");

                    b.Navigation("Location");

                    b.Navigation("PetInsurance");
                });

            modelBuilder.Entity("Module4_HM4_EF2.DbData.Models.PetFood", b =>
                {
                    b.HasOne("Module4_HM4_EF2.DbData.Models.Food", "Food")
                        .WithMany("PetFoods")
                        .HasForeignKey("FoodId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_PetFood_FoodId");

                    b.HasOne("Module4_HM4_EF2.DbData.Models.Pet", "Pet")
                        .WithMany("PetFoods")
                        .HasForeignKey("PetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_PetFood_PetId");

                    b.Navigation("Food");

                    b.Navigation("Pet");
                });

            modelBuilder.Entity("Module4_HM4_EF2.DbData.Models.Breed", b =>
                {
                    b.Navigation("Pets");
                });

            modelBuilder.Entity("Module4_HM4_EF2.DbData.Models.Category", b =>
                {
                    b.Navigation("Breeds");

                    b.Navigation("Pets");
                });

            modelBuilder.Entity("Module4_HM4_EF2.DbData.Models.Food", b =>
                {
                    b.Navigation("PetFoods");
                });

            modelBuilder.Entity("Module4_HM4_EF2.DbData.Models.Location", b =>
                {
                    b.Navigation("Pets");
                });

            modelBuilder.Entity("Module4_HM4_EF2.DbData.Models.Pet", b =>
                {
                    b.Navigation("PetFoods");
                });

            modelBuilder.Entity("Module4_HM4_EF2.DbData.Models.PetInsurance", b =>
                {
                    b.Navigation("Pet");
                });
#pragma warning restore 612, 618
        }
    }
}
