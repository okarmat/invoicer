using Invoicer.Infrastructure.Providers;
using Invoicer.Models.Enums;
using Invoicer.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace Invoicer.Infrastructure.Parsers
{
    public class FuelInvoiceParser
    {
        protected int GetCurrencyType(string data)
        {
            CurrencyTypeEnum currencyType;                       

            if (data.Contains("PLN") || data.Contains("ZŁ"))
                currencyType = CurrencyTypeEnum.PLN;
            else if (data.Contains("USD"))
                currencyType = CurrencyTypeEnum.USD;
            else if (data.Contains("EUR"))
                currencyType = CurrencyTypeEnum.EUR;
            else
                currencyType = CurrencyTypeEnum.Unknown;

            return (int)currencyType;
        }

        protected decimal? GetAmount(string data)
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

        protected decimal? GetUnitPrice(string data)
        {
            string pattern = @"\d{1,3}\,\d{2}";

            var matches = Regex.Matches(data, pattern);
            if (matches.Count == 0)
                return null;

            var result = matches.Cast<Match>()
                .Where(m => decimal.Parse(m.Value) > 0)
                .Select(m => decimal.Parse(m.Value))                
                .Min();

            return result;
        }

        protected string GetRefuelingDate(string data)
        {
            string pattern = @"\d{4}-\d{2}-\d{2}";

            Regex regularExpression = new Regex(pattern);

            var result = regularExpression.Match(data).Value;

            return result;
        }

        protected decimal? GetQuantity(string data)
        {
            string pattern = @"\d{1,3},\d{2}";

            Regex regularExpression = new Regex(pattern);

            var matchValue = regularExpression.Match(data);

            if (matchValue == null) return null;

            var result = decimal.Parse(matchValue.Value);

            return result;
        }

    }
}