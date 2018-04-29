using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Invoicer.Models;

namespace Invoicer.Repositories
{
    public class FuelInvoiceRepository : IFuelInvoiceRepository
    {
        private readonly ApplicationDbContext _context;

        public FuelInvoiceRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Add(FuelInvoice fuelInvoice)
        {
            _context.FuelInvoices.Add(fuelInvoice);
            _context.SaveChanges();
        }
    }
}