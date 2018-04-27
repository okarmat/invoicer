using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Invoicer.Models
{
    public class Invoice
    {
        public int Id { get; set; }

        public decimal Amount { get; set; }

        public CurrencyType CurrencyId { get; set; }

        public int InvoiceTypeId { get; set; }

        public string UserId { get; set; }

        public InvoiceType InvoiceType { get; set; }       

        public ApplicationUser User { get; set; }
    }
}