﻿using Invoicer.Repositories;

namespace Invoicer.Models
{
    public interface IUnitOfWork
    {
        IFuelInvoiceRepository FuelInvoices { get; }
        IInvoiceTypeRepository InvoiceTypes { get; }
        IFuelTypeRepository FuelTypes { get; }
        ICurrencyTypeRepository CurrencyTypes { get; }
        IGasStationRepository GasStations { get; }

        void Complete();
    }
}