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
        [Display(Name = "Rodzaj paliwa")]
        public int FuelType { get; set; }
        
        [Required]
        [Display(Name = "Data tankowania")]
        public string RefuelingDate { get; set; }

        [Required]
        [RegularExpression("(^\\d{1,8}(\\.\\d{1,2})?$)", ErrorMessage = "Niepoprawny format ceny")]
        [Display(Name = "Cena")]
        public decimal? Amount { get; set; }

        [Required]
        [Display(Name = "Waluta")]
        public int CurrencyType { get; set; }

        [Required]
        [Display(Name = "Cena za litr")]
        [RegularExpression("(^\\d{1,2}(\\.\\d{1,2})?$)", ErrorMessage = "Niepoprawny format ceny")]
        public decimal? UnitPrice { get; set; }

        [Required]
        [Display(Name = "Ilość litrów")]
        [RegularExpression("(^\\d{1,9}?$)", ErrorMessage = "Niepoprawny ilości kilometrów")]
        public decimal? Quantity { get; set; }

        [Display(Name = "Stacja paliw")]
        public int GasStation { get; set; }

        [Required]
        [Display(Name = "Stan licznika")]
        public int? MeterStatus { get; set; }

        public IEnumerable<FuelType> FuelTypes { get; set; }

        public IEnumerable<CurrencyType> CurrencyTypes { get; set; }

        public IEnumerable<GasStation> GasStations { get; set; }
    }
}