using Invoicer.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Invoicer.ViewModels
{
    public class FuelInvoiceFormViewModel
    {
        public int Id { get; set; }

        [Required]
        public int FuelType { get; set; }

        [Required]
        public string RefuelingDate { get; set; }

        [Required]
        [RegularExpression("(\\d{1,8}\\,\\d{1,6})", ErrorMessage = "Wprowadź cenę")]
        public decimal Amount { get; set; }

        [Required]
        public int CurrencyType { get; set; }

        [Required]
        public decimal UnitPrice { get; set; }

        [Required]
        public decimal Quantity { get; set; }

        public int GasStation { get; set; }

        [Required]
        public int MeterStatus { get; set; }

        public IEnumerable<FuelType> FuelTypes { get; set; }

        public IEnumerable<CurrencyType> CurrencyTypes { get; set; }

        public IEnumerable<GasStation> GasStations { get; set; }
    }
}