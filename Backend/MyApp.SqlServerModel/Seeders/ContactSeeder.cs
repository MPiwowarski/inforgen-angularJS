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
    public class ContactSeeder
    {
        public static void Run(MyAppDbContext db)
        {
            db.Contact.AddOrUpdate(s => s.Id,
                new Contact
                {
                    Id = 1,
                    Email = "abc1@email.com",
                    FirstName = "firstName1",
                    LastName = "lastName1",
                    Title = "title1",
                    Version = TimestampHelper.Generate()
                },
                new Contact
                {
                    Id = 2,
                    Email = "abc2@email.com",
                    FirstName = "firstName2",
                    LastName = "lastName2",
                    Title = "title2",
                    Version = TimestampHelper.Generate()
                }
            );
            db.SaveChanges();
        }
    }
}
