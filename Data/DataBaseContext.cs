using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using survey_imprecise_api.Data;
using survey_imprecise_api.Models;

namespace survey_imprecise_api.Data
{
    public partial class DataBaseContext : DbContext
    {
        public DataBaseContext(DbContextOptions<DataBaseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CaseParameter> CaseParameters { get; set; }
        public virtual DbSet<CaseRanking> CaseRankings { get; set; }
        public virtual DbSet<Case> Cases { get; set; }
        public virtual DbSet<EfmigrationsHistory> EfmigrationsHistory { get; set; }
        public virtual DbSet<Parameter> Parameters { get; set; }
        public virtual DbSet<Question> Questions { get; set; }
        public virtual DbSet<Ranking> Rankings { get; set; }
        public virtual DbSet<Respondant> Respondants { get; set; }
        public virtual DbSet<Response> Responses { get; set; }
        public virtual DbSet<QuestionCases> QuestionCases { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<QuestionCases>(entity =>
            {
                entity
                    .HasKey(qc => new { qc.QuestionId, qc.CaseId });
                entity
                        .HasOne(qc => qc.Case)
                        .WithMany(c => c.QuestionCases)
                        .HasForeignKey(qc => qc.CaseId);
                entity
                        .HasOne(qc => qc.Question)
                        .WithMany(q => q.QuestionCases)
                        .HasForeignKey(qc => qc.QuestionId);
            });
            modelBuilder.Entity<CaseParameter>(entity =>
            {
                entity.HasKey(e => new { e.CaseId, e.ParameterId })
                    .HasName("PRIMARY");

                entity.HasIndex(e => e.ParameterId);

                entity.Property(e => e.CaseId).HasColumnType("int(11)");

                entity.Property(e => e.ParameterId).HasColumnType("int(11)");

                entity.HasOne(d => d.Case)
                    .WithMany(p => p.CaseParameters)
                    .HasForeignKey(d => d.CaseId);

                entity.HasOne(d => d.Parameter)
                    .WithMany(p => p.CaseParameters)
                    .HasForeignKey(d => d.ParameterId);
            });

            modelBuilder.Entity<CaseRanking>(entity =>
            {
                entity.HasNoKey();

                entity.HasIndex(e => e.CaseId)
                    .HasName("CaseId");

                entity.HasIndex(e => e.RankingId)
                    .HasName("RankingId");

                entity.Property(e => e.CaseId).HasColumnType("int(11)");

                entity.Property(e => e.Priority).HasColumnType("int(11)");

                entity.Property(e => e.RankingId).HasColumnType("int(11)");

                entity.HasOne(d => d.Case)
                    .WithMany()
                    .HasForeignKey(d => d.CaseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("CaseRankings_ibfk_2");

                entity.HasOne(d => d.Ranking)
                    .WithMany()
                    .HasForeignKey(d => d.RankingId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("CaseRankings_ibfk_1");
            });

            modelBuilder.Entity<Case>(entity =>
            {
                entity.HasKey(e => e.CaseId)
                    .HasName("PRIMARY");

                entity.Property(e => e.CaseId).HasColumnType("int(11)");
            });

            modelBuilder.Entity<EfmigrationsHistory>(entity =>
            {
                entity.HasKey(e => e.MigrationId)
                    .HasName("PRIMARY");

                entity.ToTable("__EFMigrationsHistory");

                entity.Property(e => e.MigrationId)
                    .HasColumnType("varchar(95)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ProductVersion)
                    .IsRequired()
                    .HasColumnType("varchar(32)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<Parameter>(entity =>
            {
                entity.HasKey(e => e.ParameterId)
                    .HasName("PRIMARY");

                entity.Property(e => e.ParameterId).HasColumnType("int(11)");

                entity.Property(e => e.DescriptionOne)
                    .HasColumnType("longtext")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.DescriptionTwo)
                    .HasColumnType("longtext")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.Indicator)
                    .IsRequired()
                    .HasColumnType("varchar(24)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Score).HasColumnType("int(11)");
            });

            modelBuilder.Entity<Question>(entity =>
            {
                entity.HasKey(e => e.QuestionId)
                    .HasName("PRIMARY");

                entity.Property(e => e.QuestionId).HasColumnType("int(11)");

                entity.Property(e => e.Content)
                    .HasColumnType("longtext")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");
            });

            modelBuilder.Entity<Ranking>(entity =>
            {
                entity.HasKey(e => e.RankingId)
                    .HasName("PRIMARY");

                entity.HasIndex(e => e.RespondantId)
                    .HasName("RespondantId");

                entity.Property(e => e.RankingId).HasColumnType("int(11)");

                entity.Property(e => e.RespondantId).HasColumnType("int(11)");

                entity.HasOne(d => d.Respondant)
                    .WithMany(p => p.Rankings)
                    .HasForeignKey(d => d.RespondantId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Rankings_ibfk_1");
            });

            modelBuilder.Entity<Respondant>(entity =>
            {
                entity.HasKey(e => e.RespondantId)
                    .HasName("PRIMARY");

                entity.Property(e => e.RespondantId).HasColumnType("int(11)");

                entity.Property(e => e.CreatedAt).HasDefaultValueSql("'CURRENT_TIMESTAMP(6)'");

                entity.Property(e => e.Occupation)
                    .HasColumnType("longtext")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");
            });

            modelBuilder.Entity<Response>(entity =>
            {
                entity.HasKey(e => e.ResponseId)
                    .HasName("PRIMARY");

                entity.HasIndex(e => e.ChosenCaseId);

                entity.HasIndex(e => e.RespondantId);

                entity.Property(e => e.ResponseId).HasColumnType("int(11)");

                entity.Property(e => e.ChosenCaseId).HasColumnType("int(11)");

                entity.Property(e => e.RespondantId).HasColumnType("int(11)");

                entity.HasOne(d => d.ChosenCase)
                    .WithMany(p => p.Responses)
                    .HasForeignKey(d => d.ChosenCaseId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(d => d.Respondant)
                    .WithMany(p => p.Responses)
                    .HasForeignKey(d => d.RespondantId);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
