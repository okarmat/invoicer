using Invoicer.Models;
using Invoicer.Models.Enums;
using Invoicer.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace Invoicer.Infrastructure.Parsers
{
    public class CircleInvoiceParser : IFuelInvoiceParser
    {
        public FuelInvoiceFormViewModel GetFuelInvoiceFormViewMode(string data)
        {
            var result = new FuelInvoiceFormViewModel
            {
                GasStation = (int)GasStationEnum.Circle,                
                FuelType = GetFuelType(data),                
                RefuelingDate = GetRefuelingDate(data),
                Amount = GetAmount(data),
                UnitPrice = GetUnitPrice(data),
                CurrencyType = GetCurrencyType(data),
                Quantity = GetQuantity(data)
            };

            return result;
        }

        private int GetCurrencyType(string data)
        {
            return 0;
        }

        private decimal? GetQuantity(string data)
        {
            return null;
        }

        private decimal? GetUnitPrice(string data)
        {
            return null;
        }

        private decimal? GetAmount(string data)
        {
            string pattern = @"\d{1,3}\,\d{2}+";

            Regex regularExpression = new Regex(pattern);

            var result = regularExpression.Match(data).Value;


            return null;
        }

        private string GetRefuelingDate(string data)
        {
            string pattern = @"\d{4}-\d{2}-\d{2}";

            Regex regularExpression = new Regex(pattern);

            var result = regularExpression.Match(data).Value;

            return result;
        }

        private int GetFuelType(string data)
        {
            FuelTypeEnum fuelType;

            if (data.Contains("milesPLUS diesel"))
                fuelType = FuelTypeEnum.Diesel;
            else if (data.Contains("LPG SUPRAGAZ"))
                fuelType = FuelTypeEnum.LPG;
            else if (data.Contains("milesPLUS 95"))
                fuelType = FuelTypeEnum.Petrol;
            else
                fuelType = FuelTypeEnum.Unknown;

            return (int)fuelType;
        }
    }
}