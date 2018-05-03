using Invoicer.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Invoicer.Infrastructure.Parsers
{
    public class FuelInvoiceParserFactory
    {
        public virtual IFuelInvoiceParser CreateFuelInvoiceParser(GasStationEnum gasStation)
        {
            IFuelInvoiceParser fuelInvoiceParser = null;

            switch (gasStation)
            {
                case GasStationEnum.BP:
                    fuelInvoiceParser = new BPInvoiceParser();
                    break;
                case GasStationEnum.Circle:
                    fuelInvoiceParser = new CircleInvoiceParser();
                    break;
                case GasStationEnum.Lotos:
                    fuelInvoiceParser = new LotosInvoiceParser();
                    break;
                case GasStationEnum.Orlen:
                    fuelInvoiceParser = new OrlenInvoiceParser();
                    break;    
                default:
                    fuelInvoiceParser = new FuelInvoiceParser();
                    break;
            }

            return fuelInvoiceParser;
        }
    }
}