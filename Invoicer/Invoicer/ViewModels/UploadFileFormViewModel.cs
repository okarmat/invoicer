using Invoicer.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Invoicer.ViewModels
{
    public class UploadFileFormViewModel
    {
        [Required]
        [Display(Name = "Rodzaj faktury")]
        public int InvoiceType { get; set; }

        public IEnumerable<InvoiceType> InvoiceTypes { get; set; }
    }
}