using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Invoicer.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<FuelInvoice> FuelInvoices { get; set; }
        public DbSet<CurrencyType> CurrencyTypes { get; set; }
        public DbSet<FuelType> FuelTypes { get; set; }
        public DbSet<InvoiceType> InvoiceTypes { get; set; }
        public DbSet<GasStation> GasStations { get; set; }

        public ApplicationDbContext() : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}