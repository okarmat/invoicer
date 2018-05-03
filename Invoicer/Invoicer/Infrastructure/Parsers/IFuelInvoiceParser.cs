using Invoicer.ViewModels;

namespace Invoicer.Infrastructure.Parsers
{
    public interface IFuelInvoiceParser
    {
        FuelInvoiceFormViewModel GetFuelInvoiceFormViewModel(string data);
    }
}