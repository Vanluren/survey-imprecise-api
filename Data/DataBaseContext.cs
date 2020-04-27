using System;
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
            modelBuilder.Entity<Case>().HasData(
                   new Case
                   {
                       CaseId = 1
                   }
                );
            modelBuilder.Entity<Supplier>().HasData(
                  new Supplier
                  {
                      SupplierId = 1,
                      Name = "Lars Landmand",
                      Soil = 1,
                      Husbandry = 1,
                      Nutrients = 1,
                      Water = 1,
                      Energy = 1,
                      Biodiversity = 1,
                      Workconditions = 1,
                      Lifeequality = 1,
                      Economy = 1,
                      Management = 1
                  }
                );
            modelBuilder.Entity<CaseParameter>().HasData(new CaseParameter
            {
                CaseParameterId = 1,
                Title = "Title",
                DescriptionOne = "dkajdflkajsdfkas",
                DescriptionTwo = "æalkfjhædlksfjaæls"
            });
        }
    }
}
