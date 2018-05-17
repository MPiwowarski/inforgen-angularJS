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
        ContactDetailsDto FindById(int id);
        ICollection<ContactBasicInfo> GetAll();
        bool Remove(int id);
        bool AddAddress(AddAddressToContactDto dto);
    }
}