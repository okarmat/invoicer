using Invoicer.Infrastructure.Parsers;
using Invoicer.Models.Enums;
using Invoicer.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace Invoicer.Infrastructure
{
    public class OcrUtils
    {
        private static string GetTextFromPicture(string path)
        {
            string fileExtension = Path.GetExtension(path);
            string fileName = Path.GetFileName(path);

            if (fileExtension != ".jpg" && fileExtension != ".JPG")
                throw new Exception("Nieobsługiwany typ pliku.");

            MODI.Document md = new MODI.Document();
            md.Create(path);
            md.OCR(MODI.MiLANGUAGES.miLANG_ENGLISH);
            MODI.Image image = (MODI.Image)md.Images[0];

            return image.Layout.Text;
        }

        public static object GetFuelInvoicViewModel(string path)
        {
            var stringData = GetTextFromPicture(path);
            var gasStation = GetGasStation(stringData);

            if (!gasStation.HasValue) return null;

            var invoiceParserFactory = new InvoiceParserFactory();
            var invoiceParser = invoiceParserFactory.CreateFuelInvoiceParser(gasStation.Value);

            var result = invoiceParser.GetFuelInvoiceFormViewMode(stringData);

            return result;
        }

        private static GasStationEnum? GetGasStation(string data)
        {
            if (data.Contains("BP"))
                return GasStationEnum.BP;
            else if (data.Contains("Orlen"))
                return GasStationEnum.Orlen;
            else if (data.Contains("Lotos"))
                return GasStationEnum.Lotos;
            else if (data.Contains("Circle"))
                return GasStationEnum.Circle;
            else
                return null;
        }
    }
}