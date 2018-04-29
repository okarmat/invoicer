using Invoicer.Models;
using System.Collections;
using System.Collections.Generic;

namespace Invoicer.Repositories
{
    public interface ICurrencyTypeRepository
    {
        IEnumerable<CurrencyType> GetCurrencyTypes();
    }
}