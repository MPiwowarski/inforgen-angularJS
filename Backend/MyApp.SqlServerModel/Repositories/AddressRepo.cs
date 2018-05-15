using MyApp.SqlServerModel.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.SqlServerModel.Repositories
{
    public class AddressRepo : IAddressRepo
    {
        protected readonly MyAppDbContext _db;

        public AddressRepo(MyAppDbContext db)
        {
            _db = db;
        }

        public Address Create(Address entity)
        {
            try
            {
                return _db.Set<Address>().Add(entity);
                _db.SaveChanges();
            }
            catch (Exception ex)
            {
                //log exception
                return null;
            }
        }

        public Address Update(Address entity)
        {
            try
            {
                _db.Entry(entity).CurrentValues.SetValues(entity);
                _db.SaveChanges();
                return entity;
            }
            catch (Exception ex)
            {
                //log exception
                return null;
            }
        }

        public bool Remove(int id)
        {
            try
            {
                Address entity = FindById(id);
                _db.Set<Address>().Remove(entity);
                _db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                //log exception
                return false;
            }
        }

        public Address FindById(int id)
        {
            try
            {
                return _db.Set<Address>().Find(id);
            }
            catch (Exception ex)
            {
                //log exception
                return null;
            }
        }

        public ICollection<Address> GetAll()
        {
            try
            {
                return _db.Set<Address>().ToList();
            }
            catch (Exception ex)
            {
                //log exception
                return null;
            }
        }
    }
}
