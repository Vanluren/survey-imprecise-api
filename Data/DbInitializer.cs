using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using survey_imprecise_api.Models;


namespace survey_imprecise_api.Data
{
    public class DbInitializer
    {
        public static void Initialize(DataBaseContext context)
        {
            context.Database.EnsureCreated();

            // Look for any suppliers.
            if (context.Suppliers.Any())
            {
                return;   // DB has been seeded
            }

            var suppliers = new Supplier[]{
                new Supplier {
                     FirstName = "Lars",
                      LastName = "Landmand",
                      Soil = 77,
                      Husbandry = 88,
                      Nutrients = 80,
                      Water = 78,
                      Energy = 66,
                      Biodiversity = 58,
                      Workconditions = 87,
                      Lifequality = 89,
                      Economy = 80,
                      Management = 8
                }
            };

            foreach (Supplier s in suppliers)
            {
                context.Suppliers.Add(s);
            }
            context.SaveChanges();
        }
    }
}