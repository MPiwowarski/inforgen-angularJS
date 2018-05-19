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

        public async Task<Address> Create(Address entity)
        {
            try
            {
                _db.Set<Address>().Add(entity);
                await _db.SaveChangesAsync();
                return entity;
            }
            catch (Exception ex)
            {
                //log exception
                return null;
            }
        }

        public async Task<Address> Update(Address entity)
        {
            try
            {
                _db.Entry(entity).CurrentValues.SetValues(entity);
                await _db.SaveChangesAsync();
                return entity;
            }
            catch (Exception ex)
            {
                //log exception
                return null;
            }
        }

        public async Task<bool> Remove(int id)
        {
            try
            {
                Address entity = await _db.Address.FindAsync(id);
                _db.Set<Address>().Remove(entity);
                await _db.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                //log exception
                return false;
            }
        }

        public async Task<Address> FindById(int id)
        {
            try
            {
                return await _db.Set<Address>().FindAsync(id);
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
