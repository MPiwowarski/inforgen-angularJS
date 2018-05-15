using MyApp.SqlServerModel.Entities;
using MyApp.SqlServerModel.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MyApp.WebAPI.Controllers
{
    [RoutePrefix("api/address")]
    public class AddressController : ApiController
    {
        //todo configure IOC Unity
        private readonly IAddressRepo _addressRepo = new AddressRepo(new SqlServerModel.MyAppDbContext());

        public AddressController()
        {

        }

        public AddressController(IAddressRepo addressRepo)
        {
            _addressRepo = addressRepo;
        }

        //GET api/values
        public IEnumerable<Address> Get()
        {
            var result = _addressRepo.GetAll();
            return result;
        }

        // GET api/values/5
        public Address Get(int id)
        {
            return _addressRepo.FindById(id);
        }

        // POST api/values
        public void Post([FromBody]Address value)
        {
            _addressRepo.Create(value);
        }

        // PUT api/values/5
        public void Put([FromBody]Address value)
        {
            _addressRepo.Update(value);
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
            _addressRepo.Remove(id);
        }

    }
}