namespace Invoicer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RepairMigration4 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.FuelInvoices", "InvoiceNumber", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.FuelInvoices", "InvoiceNumber");
        }
    }
}
