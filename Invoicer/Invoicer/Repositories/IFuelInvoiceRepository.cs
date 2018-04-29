using Invoicer.Models;

namespace Invoicer.Repositories
{
    public interface IFuelInvoiceRepository
    {
        void Add(FuelInvoice fuelInvoice);
    }
}