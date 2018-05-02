using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using Invoicer.Models.Enums;
using Invoicer.ViewModels;

namespace Invoicer.Infrastructure.Parsers
{
    public class BPInvoiceParser : FuelInvoiceParser, IFuelInvoiceParser
    {
        public FuelInvoiceFormViewModel GetFuelInvoiceFormViewMode(string data)
        {
            var result = new FuelInvoiceFormViewModel
            {
                GasStation = (int)GasStationEnum.BP,
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
            string pattern = @"[A-Z0-9]{6}\-[A-Z0-9]{4}\-[A-Z0-9]{3}";

            Regex regularExpression = new Regex(pattern);

            var result = regularExpression.Match(data).Value;

            return result;
        }

        private int GetFuelType(string data)
        {
            FuelTypeEnum fuelType;

            if (data.Contains("DIESEL"))
                fuelType = FuelTypeEnum.Diesel;
            else if (data.Contains("LPG"))
                fuelType = FuelTypeEnum.LPG;
            else if (data.Contains("BENZ95"))
                fuelType = FuelTypeEnum.Petrol;
            else
                fuelType = FuelTypeEnum.Unknown;

            return (int)fuelType;
        }
    }
}