using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Invoicer.Models;

namespace Invoicer.Repositories
{
    public class GasStationRepository : IGasStationRepository
    {
        private readonly ApplicationDbContext _context;

        public GasStationRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<GasStation> GetGasStations()
        {
            return _context.GasStations.ToList();
        }
    }
}