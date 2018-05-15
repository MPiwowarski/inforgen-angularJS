using Microsoft.AspNet.Identity.EntityFramework;
using MyApp.SqlServerModel.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.SqlServerModel
{
    public class MyAppDbContext : IdentityDbContext, IDisposable
    {
        public MyAppDbContext() :
           base("name=MyAppDbContext")
        {

        }



        public virtual DbSet<Address> Address { get; set; }

        public virtual DbSet<Contact> Contact { get; set; }

        public virtual DbSet<ContactAddress> ContactAddress { get; set; }

    }
}
