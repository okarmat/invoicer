namespace Invoicer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fillingupdictionaries : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.FuelInvoices", "CurrencyId_Id", "dbo.CurrencyTypes");
            DropForeignKey("dbo.FuelInvoices", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.FuelInvoices", new[] { "UserId" });
            DropIndex("dbo.FuelInvoices", new[] { "CurrencyId_Id" });
            AlterColumn("dbo.FuelInvoices", "UserId", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.FuelInvoices", "CurrencyId_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.FuelInvoices", "UserId");
            CreateIndex("dbo.FuelInvoices", "CurrencyId_Id");
            AddForeignKey("dbo.FuelInvoices", "CurrencyId_Id", "dbo.CurrencyTypes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.FuelInvoices", "UserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.FuelInvoices", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.FuelInvoices", "CurrencyId_Id", "dbo.CurrencyTypes");
            DropIndex("dbo.FuelInvoices", new[] { "CurrencyId_Id" });
            DropIndex("dbo.FuelInvoices", new[] { "UserId" });
            AlterColumn("dbo.FuelInvoices", "CurrencyId_Id", c => c.Int());
            AlterColumn("dbo.FuelInvoices", "UserId", c => c.String(maxLength: 128));
            CreateIndex("dbo.FuelInvoices", "CurrencyId_Id");
            CreateIndex("dbo.FuelInvoices", "UserId");
            AddForeignKey("dbo.FuelInvoices", "UserId", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.FuelInvoices", "CurrencyId_Id", "dbo.CurrencyTypes", "Id");
        }
    }
}
