using MyApp.SqlServerModel.Entities;
using MyApp.SqlServerModel.Helpers;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.SqlServerModel.Seeders
{
    public class AddressSeeder
    {
        public static void Run(MyAppDbContext db)
        {
            db.Address.AddOrUpdate(s => s.Id,
                new Address
                {
                    Id = 1,
                    City = "Edinburgh",
                    Country = "U.K.",
                    Line1 = "Line1 x1",
                    Line2 = "Line2 x1",
                    Line3 = "Line3 x1",
                    PostCode = "EH88JU",
                    Version = TimestampHelper.Generate()
                }
                ,
                new Address
                {
                    Id = 2,
                    City = "Aberdeen",
                    Country = "U.K.",
                    Line1 = "Line1 x2",
                    Line2 = "Line2 x2",
                    Line3 = "Line3 x2",
                    PostCode = "EH37JU",
                    Version = TimestampHelper.Generate()
                }
            );
            db.SaveChanges();
        }
    }
}
