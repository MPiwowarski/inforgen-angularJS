using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.SqlServerModel.Seeders
{
    public class BasicSeeder
    {
        public static void Run(MyAppDbContext db)
        {
            AddressSeeder.Run(db);
            ContactSeeder.Run(db);
            ContactAddressSeeder.Run(db);
          
        }
    }
}
