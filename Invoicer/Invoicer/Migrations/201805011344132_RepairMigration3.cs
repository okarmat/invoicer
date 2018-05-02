namespace Invoicer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RepairMigration3 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.FuelInvoices", "Number");
        }
        
        public override void Down()
        {
            AddColumn("dbo.FuelInvoices", "Number", c => c.String(nullable: false));
        }
    }
}
