using Invoicer.ViewModels;

namespace Invoicer.Infrastructure.Parsers
{
    public interface IFuelInvoiceParser
    {
        FuelInvoiceFormViewModel GetFuelInvoiceFormViewMode(string data);
    }
}