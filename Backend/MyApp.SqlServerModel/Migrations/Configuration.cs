namespace MyApp.SqlServerModel.Migrations
{
    using MyApp.SqlServerModel.Seeders;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MyApp.SqlServerModel.MyAppDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(MyApp.SqlServerModel.MyAppDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            BasicSeeder.Run(context);
        }
    }
}
