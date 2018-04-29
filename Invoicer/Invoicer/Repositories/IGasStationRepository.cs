using Invoicer.Models;
using System.Collections.Generic;

namespace Invoicer.Repositories
{
    public interface IGasStationRepository
    {
        IEnumerable<GasStation> GetGasStations();
    }
}