using Invoicer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Invoicer.ViewModels
{
    public class UploadFileFormViewModel
    {
        public int InvoiceType { get; set; }

        public IEnumerable<InvoiceType> InvoiceTypes { get; set; }
    }
}