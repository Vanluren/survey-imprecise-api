﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using survey_imprecise_api.Data;

namespace survey_imprecise_api.Migrations
{
    [DbContext(typeof(DataBaseContext))]
    [Migration("20200427212033_UpdateCaseParameterCols")]
    partial class UpdateCaseParameterCols
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("survey_imprecise_api.Models.Case", b =>
                {
                    b.Property<int>("CaseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("SupplierId")
                        .HasColumnType("int");

                    b.HasKey("CaseId");

                    b.HasIndex("SupplierId");

                    b.ToTable("Cases");
                });

            modelBuilder.Entity("survey_imprecise_api.Models.CaseParameter", b =>
                {
                    b.Property<int>("CaseParameterId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("CaseId")
                        .HasColumnType("int");

                    b.Property<string>("DescriptionOne")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("DescriptionTwo")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("Indicator")
                        .HasColumnType("int");

                    b.Property<int>("Score")
                        .HasColumnType("int");

                    b.HasKey("CaseParameterId");

                    b.HasIndex("CaseId");

                    b.ToTable("CaseParameters");
                });

            modelBuilder.Entity("survey_imprecise_api.Models.Supplier", b =>
                {
                    b.Property<int>("SupplierId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("Biodiversity")
                        .HasColumnType("int");

                    b.Property<int>("Economy")
                        .HasColumnType("int");

                    b.Property<int>("Energy")
                        .HasColumnType("int");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("Husbandry")
                        .HasColumnType("int");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("Lifequality")
                        .HasColumnType("int");

                    b.Property<int>("Management")
                        .HasColumnType("int");

                    b.Property<int>("Nutrients")
                        .HasColumnType("int");

                    b.Property<int>("Soil")
                        .HasColumnType("int");

                    b.Property<int>("Water")
                        .HasColumnType("int");

                    b.Property<int>("Workconditions")
                        .HasColumnType("int");

                    b.HasKey("SupplierId");

                    b.ToTable("Suppliers");
                });

            modelBuilder.Entity("survey_imprecise_api.Models.Case", b =>
                {
                    b.HasOne("survey_imprecise_api.Models.Supplier", "Supplier")
                        .WithMany("Cases")
                        .HasForeignKey("SupplierId");
                });

            modelBuilder.Entity("survey_imprecise_api.Models.CaseParameter", b =>
                {
                    b.HasOne("survey_imprecise_api.Models.Case", "Case")
                        .WithMany("Parameters")
                        .HasForeignKey("CaseId");
                });
#pragma warning restore 612, 618
        }
    }
}
