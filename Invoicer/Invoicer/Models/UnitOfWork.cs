using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Invoicer.Repositories;

namespace Invoicer.Models
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public IFuelInvoiceRepository FuelInvoices { get; set; }
        public IFuelTypeRepository FuelTypes { get; set; }
        public ICurrencyTypeRepository CurrencyTypes { get; set; }
        public IGasStationRepository GasStations { get; set; }

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            FuelInvoices = new FuelInvoiceRepository(context);
            FuelTypes = new FuelTypeRepository(context);
            CurrencyTypes = new CurrencyTypeRepository(context);
            GasStations = new GasStationRepository(context);
        }

        public void Complete()
        {
            _context.SaveChanges();
        }
    }
}