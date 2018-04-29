using Invoicer.Models;
using System.Collections.Generic;

namespace Invoicer.Repositories
{
    public interface IFuelTypeRepository
    {
        IEnumerable<FuelType> GetFuelTypes();
    }
}