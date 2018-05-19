using System.Collections.Generic;
using System.Threading.Tasks;
using MyApp.SqlServerModel.DataStructure;
using MyApp.SqlServerModel.Dtos;
using MyApp.SqlServerModel.Entities;

namespace MyApp.SqlServerModel.Repositories
{
    public interface IContactRepo
    {
        Task<Contact> Create(Contact entity);
        Task<Contact> Update(ContactUpdateDto entity);
        ContactDetailsDto FindById(int id);
        ICollection<ContactBasicInfo> GetAll();
        Task<bool> Remove(int id);
        Task<bool> AddAddress(AddAddressToContactDto dto);
    }
}