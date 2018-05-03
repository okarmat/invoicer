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
    public class CircleInvoiceParser : FuelInvoiceParser, IFuelInvoiceParser
    {
        public new FuelInvoiceFormViewModel GetFuelInvoiceFormViewModel(string data)
        {
            var result = new FuelInvoiceFormViewModel
            {
                GasStation = (int)GasStationEnum.Circle,
                InvoiceNumber = GetNumber(data),
                FuelType = GetFuelType(data),                
                RefuelingDate = GetRefuelingDate(data),
                Amount = GetAmount(data),
                UnitPrice = GetUnitPrice(data),
                CurrencyType = GetCurrencyType(data),
                Quantity = GetQuantity(data)
            };

            return result;
        }

        private string GetNumber(string data)
        {
            string pattern = @"[A-Z0-9]{16}";

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