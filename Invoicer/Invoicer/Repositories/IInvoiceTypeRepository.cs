using Invoicer.Models;
using System.Collections.Generic;

namespace Invoicer.Repositories
{
    public interface IInvoiceTypeRepository
    {
        IEnumerable<InvoiceType> GetInvoiceTypes();
    }
}