﻿// <auto-generated />
using System;
using AppServer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AppServer.Migrations
{
    [DbContext(typeof(RecipeContext))]
    partial class RecipeContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("AppServer.Models.ImagePath", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Path")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("RecipeDBId")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("RecipeDBId");

                    b.ToTable("ImagePath");
                });

            modelBuilder.Entity("AppServer.Models.RecipeDB", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Comment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RecipeRating")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Recipes");
                });

            modelBuilder.Entity("AppServer.Models.UsedDate", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("RecipeDBId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RecipeDBId");

                    b.ToTable("UsedDate");
                });

            modelBuilder.Entity("AppServer.Models.ImagePath", b =>
                {
                    b.HasOne("AppServer.Models.RecipeDB", null)
                        .WithMany("RecipeImages")
                        .HasForeignKey("RecipeDBId");
                });

            modelBuilder.Entity("AppServer.Models.UsedDate", b =>
                {
                    b.HasOne("AppServer.Models.RecipeDB", null)
                        .WithMany("RecipeDates")
                        .HasForeignKey("RecipeDBId");
                });

            modelBuilder.Entity("AppServer.Models.RecipeDB", b =>
                {
                    b.Navigation("RecipeDates");

                    b.Navigation("RecipeImages");
                });
#pragma warning restore 612, 618
        }
    }
}
