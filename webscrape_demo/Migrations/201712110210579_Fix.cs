namespace webscrape_demo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Fix : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Stocks", "Price", c => c.String());
            AlterColumn("dbo.Stocks", "Change", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Stocks", "Change", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Stocks", "Price", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
    }
}
