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
    public class AddressController : ApiController
    {
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
            //return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}