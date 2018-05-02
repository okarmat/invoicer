namespace Invoicer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUnknownPositrionToCurrencyTypeDirectory : DbMigration
    {
        public override void Up()
        {
            Sql("SET IDENTITY_INSERT CurrencyTypes ON;");
            Sql("INSERT INTO CurrencyTypes (Id, Name) VALUES (0, 'Unknown')");
            Sql("SET IDENTITY_INSERT CurrencyTypes OFF;");
        }

        public override void Down()
        {           
            Sql("DELETE FROM CurrencyTypes WHERE Id IN (0)");
        }                
    }
}
