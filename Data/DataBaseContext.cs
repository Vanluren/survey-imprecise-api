using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;
using survey_imprecise_api.Models;

namespace survey_imprecise_api.Data
{
    public partial class DataBaseContext : DbContext
    {
        public DataBaseContext(DbContextOptions<DataBaseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Case> Cases { get; set; }
        public virtual DbSet<Supplier> Suppliers { get; set; }
        public virtual DbSet<CaseParameter> CaseParameters { get; set; }
        public virtual DbSet<Respondant> Respondants { get; set; }
        public virtual DbSet<Response> Responses { get; set; }
        public virtual DbSet<Question> Questions { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Case>().HasOne(c => c.Supplier).WithMany(s => s.Cases);
            modelBuilder.Entity<CaseParameter>().HasOne(cp => cp.Supplier).WithMany(s => s.Parameters);
            modelBuilder.Entity<Response>().HasOne(r => r.Respondant).WithMany(ra => ra.Responses);
            modelBuilder.Entity<QuestionCases>()
                    .HasKey(qc => new { qc.QuestionId, qc.CaseId });
            modelBuilder.Entity<QuestionCases>()
                    .HasOne(qc => qc.Case)
                    .WithMany(c => c.QuestionCases)
                    .HasForeignKey(qc => qc.CaseId);
            modelBuilder.Entity<QuestionCases>()
                    .HasOne(qc => qc.Question)
                    .WithMany(q => q.QuestionCases)
                    .HasForeignKey(qc => qc.QuestionId);
        }
    }
}
