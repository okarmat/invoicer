using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Invoicer.Models;

namespace Invoicer.Repositories
{
    public class CurrencyTypeRepository : ICurrencyTypeRepository
    {
        private readonly ApplicationDbContext _context;

        public CurrencyTypeRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<CurrencyType> GetCurrencyTypes()
        {
            return _context.CurrencyTypes.ToList();
        }
    }
}