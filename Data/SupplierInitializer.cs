using System.Linq;
using Microsoft.EntityFrameworkCore;
using survey_imprecise_api.Models;

namespace survey_imprecise_api.Data
{
    public class SupplierInitializer
    {
        private readonly DataBaseContext _context;
        public SupplierInitializer(DataBaseContext context)
        {
            _context = context;
        }

        public void Seed()
        {

            if (_context.Suppliers.Any())
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
                _context.Suppliers.Add(s);
            }

            _context.SaveChanges();
        }
    }
}