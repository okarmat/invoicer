using Invoicer.Infrastructure.Parsers;
using Invoicer.Infrastructure.Providers;
using Invoicer.Models.Enums;
using Invoicer.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Invoicer.Infrastructure
{
    public class FuelInvoiceViewModelProvider : IFuelInvoiceViewModelProvider
    {
        private readonly ITextDataProvider _textDataProvider;

        public FuelInvoiceViewModelProvider(ITextDataProvider textDataProvider)
        {
            _textDataProvider = textDataProvider;
        }

        public FuelInvoiceFormViewModel GetFuelInvoiceViewModel(string path)
        {
            var stringData = _textDataProvider.GetTextData(path).ToUpper();
            var gasStation = GetGasStation(stringData);

            if (!gasStation.HasValue) return null;

            var invoiceParserFactory = new FuelInvoiceParserFactory();
            var invoiceParser = invoiceParserFactory.CreateFuelInvoiceParser(gasStation.Value);

            var result = invoiceParser.GetFuelInvoiceFormViewMode(stringData);

            return result;
        }

        private static GasStationEnum? GetGasStation(string data)
        {
            if (data.Contains("BP"))
                return GasStationEnum.BP;
            else if (data.Contains("ORLEN"))
                return GasStationEnum.Orlen;
            else if (data.Contains("LOTOS"))
                return GasStationEnum.Lotos;
            else if (data.Contains("CIRCLE"))
                return GasStationEnum.Circle;
            else
                return null;
        }
    }
}