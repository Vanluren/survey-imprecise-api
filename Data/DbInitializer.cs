using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using survey_imprecise_api.Models;

namespace survey_imprecise_api.Data
{
    public class DbInitializer
    {
        private readonly DataBaseContext _context;
        public DbInitializer(DataBaseContext context)
        {
            _context = context;
        }

        public void Initialize()
        {
            _context.Database.EnsureCreated();

            // Look for any cases.
            if (!_context.Cases.Any())
            {
                CasesSeeder();   // DB has been seeded
            }
            // Look for any suppliers.
            if (!_context.Suppliers.Any())
            {
                SeedSuppliers();   // DB has been seeded
            }

            // look for any CaseParameters
            if (!_context.CaseParameters.Any())
            {
                CaseParamSeeder();   // DB has been seeded
            }
        }

        public void SeedSuppliers()
        {
            Case caseforlist = _context.Cases.Find(1);

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
                      Management = 8,
                      Cases = new List<Case>{
                          caseforlist
                      }
                }
            };

            foreach (Supplier s in suppliers)
            {
                _context.Suppliers.Add(s);
            }

            _context.SaveChanges();
        }

        public void CasesSeeder()
        {
            Supplier supplier = _context.Suppliers.Find(1);
            CaseParameter casep = _context.CaseParameters.Find(1);

            var cases = new Case[]{
                new Case{
                    Parameters = new List<CaseParameter>{
                        casep
                    },
                    Supplier = supplier
                }
            };

            foreach (Case c in cases)
            {
                _context.Cases.Add(c);
            }

            _context.SaveChanges();
        }

        public void CaseParamSeeder()
        {
            Supplier supplier = _context.Suppliers.Find(1);
            CaseParameter[] parameters = new CaseParameter[]{
                new CaseParameter{
                    Supplier = supplier,
                    Indicator = 9,
                    Score = 11,
                    DescriptionOne = "Lavt indtjeningsniveau hæmmer investeringsmuligheder",
                    DescriptionTwo = "Dårlig sammenhæng mellem indtjening og afbetaling af gæld"
                }
            };

            foreach (CaseParameter cp in parameters)
            {
                _context.CaseParameters.Add(cp);
            }
            _context.SaveChanges();
        }
    }
}