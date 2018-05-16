namespace MyApp.SqlServerModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class address_county_changed_to_country : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Addresses", "Country", c => c.String(maxLength: 50));
            DropColumn("dbo.Addresses", "County");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Addresses", "County", c => c.String(maxLength: 50));
            DropColumn("dbo.Addresses", "Country");
        }
    }
}
