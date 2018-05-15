using MyApp.SqlServerModel;
using MyApp.SqlServerModel.Seeders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.DataSeeder
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new MyAppDbContext())
            {
                BasicSeeder.Run(db);
            }
        }
    }
}
