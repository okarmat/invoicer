namespace Invoicer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RepairMigrations : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.FuelInvoices", "InvoiceNumber", c => c.String(nullable: false));
        }

        public override void Down()
        {
            AlterColumn("dbo.FuelInvoices", "Number", c => c.String(nullable: false));
        }
    }
}
