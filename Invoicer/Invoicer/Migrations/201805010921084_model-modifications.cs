namespace Invoicer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modelmodifications : DbMigration
    {
        public override void Up()
        {
            Sql("SET IDENTITY_INSERT FuelTypes ON;");
            Sql("INSERT INTO FuelTypes (Id, Name) VALUES (0, 'Unknown')");
            Sql("SET IDENTITY_INSERT FuelTypes OFF;");

            Sql("SET IDENTITY_INSERT GasStations ON;");
            Sql("INSERT INTO GasStations (Id, Name) VALUES (0, 'Unknown')");
            Sql("SET IDENTITY_INSERT GasStations OFF;");
        }
        
        public override void Down()
        {
            Sql("DELETE FROM FuelTypes WHERE Id IN (0)");

            Sql("DELETE FROM GasStations WHERE Id IN (0)");
        }
    }
}
