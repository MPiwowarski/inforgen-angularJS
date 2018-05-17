namespace MyApp.SqlServerModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class title_not_required_in_contact : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Contacts", "Title", c => c.String(maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Contacts", "Title", c => c.String(nullable: false, maxLength: 50));
        }
    }
}
