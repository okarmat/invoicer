using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Invoicer.Models;

namespace Invoicer.Repositories
{
    public class FuelTypeRepository : IFuelTypeRepository
    {
        private readonly ApplicationDbContext _context;

        public FuelTypeRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<FuelType> GetFuelTypes()
        {
            return _context.FuelTypes.OrderBy(f => f.Name).ToList();
        }
    }
}