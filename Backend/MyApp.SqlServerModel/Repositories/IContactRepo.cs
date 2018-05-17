using System.Collections.Generic;
using System.Threading.Tasks;
using MyApp.SqlServerModel.DataStructure;
using MyApp.SqlServerModel.Dtos;
using MyApp.SqlServerModel.Entities;

namespace MyApp.SqlServerModel.Repositories
{
    public interface IContactRepo
    {
        Contact Create(Contact entity);
        Task<Contact> Update(ContactUpdateDto entity);
        Contact FindById(int id);
        ICollection<Contact> GetAll();
        bool Remove(int id);
        bool AddAddress(int contactId, int addressId, AddressTypeEnum addressType);
    }
}