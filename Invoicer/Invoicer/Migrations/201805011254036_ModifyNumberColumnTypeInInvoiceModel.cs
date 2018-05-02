namespace Invoicer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifyNumberColumnTypeInInvoiceModel : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.FuelInvoices", "Number", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.FuelInvoices", "Number", c => c.Int(nullable: false));
        }
    }
}
