namespace Invoicer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modelmodification : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.FuelInvoices", "CurrencyId_Id", "dbo.CurrencyTypes");
            DropIndex("dbo.FuelInvoices", new[] { "CurrencyId_Id" });
            RenameColumn(table: "dbo.FuelInvoices", name: "PetrolStationId", newName: "GasStationId");
            RenameIndex(table: "dbo.FuelInvoices", name: "IX_PetrolStationId", newName: "IX_GasStationId");
            AddColumn("dbo.FuelInvoices", "CurrencyId", c => c.Int(nullable: false));
            DropColumn("dbo.FuelInvoices", "CurrencyId_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.FuelInvoices", "CurrencyId_Id", c => c.Int(nullable: false));
            DropColumn("dbo.FuelInvoices", "CurrencyId");
            RenameIndex(table: "dbo.FuelInvoices", name: "IX_GasStationId", newName: "IX_PetrolStationId");
            RenameColumn(table: "dbo.FuelInvoices", name: "GasStationId", newName: "PetrolStationId");
            CreateIndex("dbo.FuelInvoices", "CurrencyId_Id");
            AddForeignKey("dbo.FuelInvoices", "CurrencyId_Id", "dbo.CurrencyTypes", "Id", cascadeDelete: true);
        }
    }
}
