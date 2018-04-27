namespace Invoicer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fillingupdictionaries2 : DbMigration
    {
        public override void Up()
        {
            Sql("SET IDENTITY_INSERT CurrencyTypes ON;");
            Sql("INSERT INTO CurrencyTypes (Id, Name) VALUES (1, 'PLN')");
            Sql("INSERT INTO CurrencyTypes (Id, Name) VALUES (2, 'USD')");
            Sql("INSERT INTO CurrencyTypes (Id, Name) VALUES (3, 'EUR')");
            Sql("SET IDENTITY_INSERT CurrencyTypes OFF;");

            Sql("SET IDENTITY_INSERT FuelTypes ON;");
            Sql("INSERT INTO FuelTypes (Id, Name) VALUES (1, 'LPG')");
            Sql("INSERT INTO FuelTypes (Id, Name) VALUES (2, 'Diesel')");
            Sql("INSERT INTO FuelTypes (Id, Name) VALUES (3, 'Petrol')");
            Sql("SET IDENTITY_INSERT FuelTypes OFF;");

            Sql("SET IDENTITY_INSERT InvoiceTypes ON;");
            Sql("INSERT INTO InvoiceTypes (Id, Name) VALUES (1, 'Fuel invoice')");
            Sql("SET IDENTITY_INSERT InvoiceTypes OFF;");

            Sql("SET IDENTITY_INSERT GasStations ON;");
            Sql("INSERT INTO GasStations (Id, Name) VALUES (1, 'BP')");            
            Sql("INSERT INTO GasStations (Id, Name) VALUES (2, 'Circle')");
            Sql("INSERT INTO GasStations (Id, Name) VALUES (3, 'Lotos')");
            Sql("INSERT INTO GasStations (Id, Name) VALUES (4, 'Orlen')");
            Sql("SET IDENTITY_INSERT GasStations OFF;");
        }
        
        public override void Down()
        {
            Sql("DELETE FROM CurrencyTypes WHERE Id IN (1, 2, 3)");

            Sql("DELETE FROM FuelTypes WHERE Id IN (1, 2, 3)");

            Sql("DELETE FROM InvoiceTypes WHERE Id IN (1)");

            Sql("DELETE FROM GasStations WHERE Id IN (1, 2, 3, 4)");
        }
    }
}
