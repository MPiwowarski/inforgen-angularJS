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

        public async Task<Contact> Create(Contact entity)
        {
            try
            {
                _db.Set<Contact>().Add(entity);
                await _db.SaveChangesAsync();
                return entity;
            }
            catch (Exception ex)
            {
                //log exception
                return null;
            }
        }

        public async Task<ContactUpdateDto> Update(ContactUpdateDto entity)
        {
            try
            {
                var contact = await _db.Contact.FindAsync(entity.Id);
                contact.Title = entity.Title;
                contact.FirstName = entity.FirstName;
                contact.LastName = entity.LastName;
                contact.Email = entity.Email;
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
                Contact entity = _db.Contact.Find(id);
                _db.Set<Contact>().Remove(entity);
                await _db.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                //log exception
                return false;
            }
        }

        public ContactDetailsDto FindById(int id)
        {
            try
            {
                var contact = _db.Set<Contact>().First(x => x.Id == id);
                var contactAddressIds = contact.ContactAddresses.Select(y => y.AddressId).ToList();
                var addresses = _db.Address.Where(x => contactAddressIds.Contains(x.Id)).ToList();

                var addressListDto = new List<AddressDtoDetails>();
                foreach (var adr in contact.ContactAddresses)
                {
                    var address = addresses.First(x => x.Id == adr.Id);
                    var adrDto = new AddressDtoDetails()
                    {
                        AddressType = adr.AddressType,
                        Id = address.Id,
                        City = address.City,
                        Country = address.Country,
                        Line1 = address.Line1,
                        Line2 = address.Line2,
                        Line3 = address.Line3,
                        PostCode = address.PostCode,
                        Version = address.Version
                    };
                    addressListDto.Add(adrDto);
                }

                var contactDetails = new ContactDetailsDto()
                {
                    Id = contact.Id,
                    Email = contact.Email,
                    FirstName = contact.FirstName,
                    LastName = contact.LastName,
                    Title = contact.Title,
                    Version = contact.Version,
                    Addresses = addressListDto
                };

                return contactDetails;
            }
            catch (Exception ex)
            {
                //log exception
                return null;
            }
        }

        public ICollection<ContactBasicInfo> GetAll()
        {
            try
            {
                var contacts = _db.Set<Contact>().AsNoTracking().ToList();
                var result = new List<ContactBasicInfo>();
                foreach (var item in contacts)
                {
                    var con = new ContactBasicInfo()
                    {
                        Id = item.Id,
                        Email = item.Email,
                        FirstName = item.FirstName,
                        LastName = item.LastName,
                        Title = item.Title,
                        Version = item.Version
                    };
                    result.Add(con);
                }
                return result;
            }
            catch (Exception ex)
            {
                //log exception
                return null;
            }
        }

        public async Task<bool> AddAddress(AddAddressToContactDto dto)
        {
            using (var dbTran = _db.Database.BeginTransaction())
            {
                try
                {
                    var contact = _db.Contact.First(x => x.Id == dto.ContactId);

                    var address = new Address()
                    {
                        City = dto.City,
                        PostCode = dto.PostCode,
                        Country = dto.Country,
                        Line1 = dto.Line1,
                        Line2 = dto.Line2,
                        Line3 = dto.Line3,
                    };
                    _db.Address.Add(address);

                    var rel = new ContactAddress()
                    {
                        Address = address,
                        Contact = contact,
                        AddressType = dto.AddressType
                    };
                    _db.Set<ContactAddress>().Add(rel);

                    await _db.SaveChangesAsync();
                    dbTran.Commit();
                    return true;
                }
                catch (Exception ex)
                {
                    dbTran.Rollback();
                    //log exception
                    return false;
                }
            }
        }

    }
}
