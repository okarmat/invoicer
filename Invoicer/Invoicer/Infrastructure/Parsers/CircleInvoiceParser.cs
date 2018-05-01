using Invoicer.Models.Enums;
using Invoicer.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Invoicer.Infrastructure.Parsers
{
    public class CircleInvoiceParser : IFuelInvoiceParser
    {
        public FuelInvoiceFormViewModel GetFuelInvoiceFormViewMode(string data)
        {
            var fuelType = GetFuelType(data);

            var result = new FuelInvoiceFormViewModel
            {
                GasStation = (int)GasStationEnum.Circle
            };

            return result;
        }

        private FuelTypeEnum? GetFuelType(string data)
        {
            if (data.Contains("Diesel"))
                return FuelTypeEnum.Diesel;
            else if (data.Contains("LPG"))
                return FuelTypeEnum.LPG;
            else if (data.Contains("PB95"))
                return FuelTypeEnum.Petrol;
            else
                return null;
        }
    }
}