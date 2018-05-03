using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using Invoicer.Models.Enums;
using Invoicer.ViewModels;

namespace Invoicer.Infrastructure.Parsers
{
    public class LotosInvoiceParser : FuelInvoiceParser, IFuelInvoiceParser
    {
        public new FuelInvoiceFormViewModel GetFuelInvoiceFormViewModel(string data)
        {
            var result = new FuelInvoiceFormViewModel
            {
                GasStation = (int)GasStationEnum.Lotos,
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
            string pattern = @"\d{1,5}\\[A-Z]{2}\\\d{1,5}\\\d{4}";

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