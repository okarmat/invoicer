using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Invoicer.Models
{
    public class Invoice
    {
        public int Id { get; set; }

        [Required]
        public decimal Amount { get; set; }

        [Required]
        public CurrencyType CurrencyId { get; set; }

        [Required]
        public int InvoiceTypeId { get; set; }

        [Required]
        public string UserId { get; set; }

        public InvoiceType InvoiceType { get; set; }       

        public ApplicationUser User { get; set; }
    }
}