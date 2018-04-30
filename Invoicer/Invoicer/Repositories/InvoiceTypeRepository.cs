using Invoicer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Invoicer.Repositories
{
    public class InvoiceTypeRepository : IInvoiceTypeRepository
    {
        private readonly ApplicationDbContext _context;

        public InvoiceTypeRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<InvoiceType> GetInvoiceTypes()
        {
            return _context.InvoiceTypes.ToList();
        }
    }
}