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
    [Migration("20200501092617_ScaffoldAfterUpdate")]
    partial class ScaffoldAfterUpdate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("survey_imprecise_api.EfmigrationsHistory", b =>
                {
                    b.Property<string>("MigrationId")
                        .HasColumnType("varchar(95)")
                        .HasAnnotation("MySql:CharSet", "utf8")
                        .HasAnnotation("MySql:Collation", "utf8_general_ci");

                    b.Property<string>("ProductVersion")
                        .IsRequired()
                        .HasColumnType("varchar(32)")
                        .HasAnnotation("MySql:CharSet", "utf8")
                        .HasAnnotation("MySql:Collation", "utf8_general_ci");

                    b.HasKey("MigrationId")
                        .HasName("PRIMARY");

                    b.ToTable("__EFMigrationsHistory");
                });

            modelBuilder.Entity("survey_imprecise_api.Models.Case", b =>
                {
                    b.Property<int>("CaseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(11)");

                    b.HasKey("CaseId")
                        .HasName("PRIMARY");

                    b.ToTable("Cases");
                });

            modelBuilder.Entity("survey_imprecise_api.Models.CaseParameter", b =>
                {
                    b.Property<int>("CaseId")
                        .HasColumnType("int(11)");

                    b.Property<int>("ParameterId")
                        .HasColumnType("int(11)");

                    b.HasKey("CaseId", "ParameterId")
                        .HasName("PRIMARY");

                    b.HasIndex("ParameterId");

                    b.ToTable("CaseParameters");
                });

            modelBuilder.Entity("survey_imprecise_api.Models.CaseRanking", b =>
                {
                    b.Property<int>("CaseId")
                        .HasColumnType("int(11)");

                    b.Property<int?>("Priority")
                        .HasColumnType("int(11)");

                    b.Property<int>("RankingId")
                        .HasColumnType("int(11)");

                    b.HasIndex("CaseId")
                        .HasName("CaseId");

                    b.HasIndex("RankingId")
                        .HasName("RankingId");

                    b.ToTable("CaseRankings");
                });

            modelBuilder.Entity("survey_imprecise_api.Models.Parameter", b =>
                {
                    b.Property<int>("ParameterId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(11)");

                    b.Property<string>("DescriptionOne")
                        .HasColumnType("longtext")
                        .HasAnnotation("MySql:CharSet", "utf8mb4")
                        .HasAnnotation("MySql:Collation", "utf8mb4_general_ci");

                    b.Property<string>("DescriptionTwo")
                        .HasColumnType("longtext")
                        .HasAnnotation("MySql:CharSet", "utf8mb4")
                        .HasAnnotation("MySql:Collation", "utf8mb4_general_ci");

                    b.Property<string>("Indicator")
                        .IsRequired()
                        .HasColumnType("varchar(24)")
                        .HasAnnotation("MySql:CharSet", "utf8")
                        .HasAnnotation("MySql:Collation", "utf8_general_ci");

                    b.Property<int>("Score")
                        .HasColumnType("int(11)");

                    b.HasKey("ParameterId")
                        .HasName("PRIMARY");

                    b.ToTable("Parameters");
                });

            modelBuilder.Entity("survey_imprecise_api.Models.Question", b =>
                {
                    b.Property<int>("QuestionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(11)");

                    b.Property<string>("Content")
                        .HasColumnType("longtext")
                        .HasAnnotation("MySql:CharSet", "utf8mb4")
                        .HasAnnotation("MySql:Collation", "utf8mb4_general_ci");

                    b.HasKey("QuestionId")
                        .HasName("PRIMARY");

                    b.ToTable("Questions");
                });

            modelBuilder.Entity("survey_imprecise_api.Models.QuestionCases", b =>
                {
                    b.Property<int?>("QuestionId")
                        .HasColumnType("int(11)");

                    b.Property<int?>("CaseId")
                        .HasColumnType("int(11)");

                    b.HasKey("QuestionId", "CaseId");

                    b.HasIndex("CaseId");

                    b.ToTable("QuestionCases");
                });

            modelBuilder.Entity("survey_imprecise_api.Models.Ranking", b =>
                {
                    b.Property<int>("RankingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(11)");

                    b.Property<int>("RespondantId")
                        .HasColumnType("int(11)");

                    b.HasKey("RankingId")
                        .HasName("PRIMARY");

                    b.HasIndex("RespondantId")
                        .HasName("RespondantId");

                    b.ToTable("Rankings");
                });

            modelBuilder.Entity("survey_imprecise_api.Models.Respondant", b =>
                {
                    b.Property<int>("RespondantId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(11)");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime(6)")
                        .HasDefaultValueSql("'CURRENT_TIMESTAMP(6)'");

                    b.Property<string>("Occupation")
                        .HasColumnType("longtext")
                        .HasAnnotation("MySql:CharSet", "utf8mb4")
                        .HasAnnotation("MySql:Collation", "utf8mb4_general_ci");

                    b.HasKey("RespondantId")
                        .HasName("PRIMARY");

                    b.ToTable("Respondants");
                });

            modelBuilder.Entity("survey_imprecise_api.Models.Response", b =>
                {
                    b.Property<int>("ResponseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(11)");

                    b.Property<int?>("ChosenCaseId")
                        .HasColumnType("int(11)");

                    b.Property<int?>("RespondantId")
                        .HasColumnType("int(11)");

                    b.HasKey("ResponseId")
                        .HasName("PRIMARY");

                    b.HasIndex("ChosenCaseId");

                    b.HasIndex("RespondantId");

                    b.ToTable("Responses");
                });

            modelBuilder.Entity("survey_imprecise_api.Models.CaseParameter", b =>
                {
                    b.HasOne("survey_imprecise_api.Models.Case", "Case")
                        .WithMany("CaseParameters")
                        .HasForeignKey("CaseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("survey_imprecise_api.Models.Parameter", "Parameter")
                        .WithMany("CaseParameters")
                        .HasForeignKey("ParameterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("survey_imprecise_api.Models.CaseRanking", b =>
                {
                    b.HasOne("survey_imprecise_api.Models.Case", "Case")
                        .WithMany()
                        .HasForeignKey("CaseId")
                        .HasConstraintName("CaseRankings_ibfk_2")
                        .IsRequired();

                    b.HasOne("survey_imprecise_api.Models.Ranking", "Ranking")
                        .WithMany()
                        .HasForeignKey("RankingId")
                        .HasConstraintName("CaseRankings_ibfk_1")
                        .IsRequired();
                });

            modelBuilder.Entity("survey_imprecise_api.Models.QuestionCases", b =>
                {
                    b.HasOne("survey_imprecise_api.Models.Case", "Case")
                        .WithMany("QuestionCases")
                        .HasForeignKey("CaseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("survey_imprecise_api.Models.Question", "Question")
                        .WithMany("QuestionCases")
                        .HasForeignKey("QuestionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("survey_imprecise_api.Models.Ranking", b =>
                {
                    b.HasOne("survey_imprecise_api.Models.Respondant", "Respondant")
                        .WithMany("Rankings")
                        .HasForeignKey("RespondantId")
                        .HasConstraintName("Rankings_ibfk_1")
                        .IsRequired();
                });

            modelBuilder.Entity("survey_imprecise_api.Models.Response", b =>
                {
                    b.HasOne("survey_imprecise_api.Models.Case", "ChosenCase")
                        .WithMany("Responses")
                        .HasForeignKey("ChosenCaseId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("survey_imprecise_api.Models.Respondant", "Respondant")
                        .WithMany("Responses")
                        .HasForeignKey("RespondantId");
                });
#pragma warning restore 612, 618
        }
    }
}
