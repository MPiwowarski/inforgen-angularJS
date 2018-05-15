using System.Collections.Generic;
using MyApp.SqlServerModel.DataStructure;
using MyApp.SqlServerModel.Entities;

namespace MyApp.SqlServerModel.Repositories
{
    public interface IContactRepo
    {
        Contact Create(Contact entity);
        Contact Update(Contact entity);
        Contact FindById(int id);
        ICollection<Contact> GetAll();
        bool Remove(int id);
        bool AddAddress(int contactId, int addressId, AddressTypeEnum addressType);
    }
}