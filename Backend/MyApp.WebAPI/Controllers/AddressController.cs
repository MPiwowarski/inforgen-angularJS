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
        private readonly IAddressRepo _addressRepo;

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

        [HttpPatch]
        [Route("edit")]
        public void Patch([FromBody]Address value)
        {
            _addressRepo.Update(value);
        }

        [HttpPost]
        [Route("delete")]
        public void Delete([FromBody]int id)
        {
            _addressRepo.Remove(id);
        }

    }
}