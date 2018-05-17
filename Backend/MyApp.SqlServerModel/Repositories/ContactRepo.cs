using MyApp.SqlServerModel.DataStructure;
using MyApp.SqlServerModel.Dtos;
using MyApp.SqlServerModel.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.SqlServerModel.Repositories
{
    public class ContactRepo : IContactRepo
    {
        protected readonly MyAppDbContext _db;

        public ContactRepo(MyAppDbContext db)
        {
            _db = db;
        }

        public Contact Create(Contact entity)
        {
            try
            {
                _db.Set<Contact>().Add(entity);
                _db.SaveChanges();
                return entity;
            }
            catch (Exception ex)
            {
                //log exception
                return null;
            }
        }

        public async Task<Contact> Update(ContactUpdateDto entity)
        {
            try
            {
                var contact = await _db.Contact.FindAsync(entity.Id);
                contact.Title = entity.Title;
                contact.FirstName = entity.FirstName;
                contact.LastName = entity.LastName;
                contact.Email = entity.Email;
                await _db.SaveChangesAsync();
                return contact;
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
                Contact entity = FindById(id);
                _db.Set<Contact>().Remove(entity);
                _db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                //log exception
                return false;
            }
        }

        public Contact FindById(int id)
        {
            try
            {
                return _db.Set<Contact>().Find(id);
            }
            catch (Exception ex)
            {
                //log exception
                return null;
            }
        }

        public ICollection<Contact> GetAll()
        {
            try
            {
                return _db.Set<Contact>().ToList();
            }
            catch (Exception ex)
            {
                //log exception
                return null;
            }
        }

        public bool AddAddress(int contactId, int addressId, AddressTypeEnum addressType)
        {
            try
            {
                var contact = _db.Contact.First(x => x.Id == contactId);
                var address = _db.Address.First(x => x.Id == addressId);
                var rel = new ContactAddress()
                {
                    Address = address,
                    Contact = contact,
                    AddressType = addressType
                };
                _db.Set<ContactAddress>().Add(rel);
                _db.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                //log exception
                return false;
            }
        }

    }
}
