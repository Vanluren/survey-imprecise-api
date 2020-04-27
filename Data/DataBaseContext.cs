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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Case>().HasOne(c => c.Supplier).WithMany(s => s.Cases);
            modelBuilder.Entity<CaseParameter>().HasOne(cp => cp.Case).WithMany(c => c.Parameters);
        }
    }
}
