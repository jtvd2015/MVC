namespace CustomerProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedStringLengthtoOrderDescriptionandCustomerNameFields : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Customers", "Name", c => c.String(maxLength: 80));
            AlterColumn("dbo.Orders", "Description", c => c.String(maxLength: 80));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Orders", "Description", c => c.String());
            AlterColumn("dbo.Customers", "Name", c => c.String());
        }
    }
}
