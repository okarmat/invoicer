namespace Invoicer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class renamingfuelinvoicetypedirectoryrecord : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE InvoiceTypes SET Name = 'Paliwowa' where Id = 1");            
        }

        public override void Down()
        {
            Sql("UPDATE InvoiceTypes SET Name = 'Fuel invoice' where Id = 1");
        }
                
    }
}
