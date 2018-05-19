using System.Collections.Generic;
using System.Threading.Tasks;
using MyApp.SqlServerModel.Entities;

namespace MyApp.SqlServerModel.Repositories
{
    public interface IAddressRepo
    {
        Task<Address> Create(Address entity);
        Task<Address> Update(Address entity);
        Task<Address> FindById(int id);
        ICollection<Address> GetAll();
        Task<bool> Remove(int id);
    }
}