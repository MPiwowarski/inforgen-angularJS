using MyApp.SqlServerModel.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.SqlServerModel.Seeders
{
    public class ContactAddressSeeder
    {
        public static void Run(MyAppDbContext db)
        {

            db.ContactAddress.AddOrUpdate(s => s.Id,
                new ContactAddress
                {
                    Id = 1,
                    AddressId = 1,
                    ContactId = 2,
                    AddressType = DataStructure.AddressTypeEnum.Type1
                }
            );
            db.SaveChanges();

        }
    }
}
