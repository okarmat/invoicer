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

        private int GetCurrencyType(string data)
        {
            CurrencyTypeEnum currencyType;

            if (data.Contains("PLN"))
                currencyType = CurrencyTypeEnum.PLN;
            else if (data.Contains("USD"))
                currencyType = CurrencyTypeEnum.USD;
            else if (data.Contains("EUR"))
                currencyType = CurrencyTypeEnum.EUR;
            else
                currencyType = CurrencyTypeEnum.Unknown;

            return (int)currencyType;
        }

        private decimal? GetQuantity(string data)
        {
            string pattern = @"\d{1,3},\d{2}";

            Regex regularExpression = new Regex(pattern);

            var matchValue = regularExpression.Match(data);

            if (matchValue == null) return null;

            var result = decimal.Parse(matchValue.Value);

            return result;
        }

        private decimal? GetUnitPrice(string data)
        {
            string pattern = @"(litry \* )(\d{1,3},\d{2})";


            Regex regularExpression = new Regex(pattern);

            var matchValue = regularExpression.Match(data).Groups;

            if (matchValue.Count != 3 || matchValue[2].Value == null) return null;
            var result = decimal.Parse(matchValue[2].Value);

            return result;
        }

        private decimal? GetAmount(string data)
        {
            string pattern = @"\d{1,3}\,\d{2}";           

            var matches = Regex.Matches(data, pattern);
            if (matches.Count == 0)
                return null;

            var result = matches.Cast<Match>().
                Select(m => decimal.Parse(m.Value))
                .Max();

            return result;
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