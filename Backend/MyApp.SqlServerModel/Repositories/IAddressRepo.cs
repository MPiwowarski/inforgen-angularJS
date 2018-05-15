using System.Collections.Generic;
using MyApp.SqlServerModel.Entities;

namespace MyApp.SqlServerModel.Repositories
{
    public interface IAddressRepo
    {
        Address Create(Address entity);
        Address FindById(int id);
        ICollection<Address> GetAll();
        bool Remove(int id);
    }
}