using MyApp.SqlServerModel.Entities;
using MyApp.SqlServerModel.Repositories;
using MyApp.WebAPI.Models.ContactModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MyApp.WebAPI.Controllers
{
    [RoutePrefix("api/contact")]
    public class ContactController : ApiController
    {
        private readonly IContactRepo _contactRepo;

        public ContactController()
        {

        }

        public ContactController(IContactRepo contactRepo)
        {
            _contactRepo = contactRepo;
        }

        // GET api/values
        public IEnumerable<Contact> Get()
        {
            var result = _contactRepo.GetAll();
            return result;
        }

        // GET api/values/5
        public Contact Get(int id)
        {
            return _contactRepo.FindById(id);
        }

        // POST api/values
        public void Post([FromBody]Contact value)
        {
            _contactRepo.Create(value);
        }

        // PUT api/values/5
        public void Put([FromBody]Contact value)
        {
            _contactRepo.Update(value);
        }

        [HttpPost]
        [Route("delete")]
        public void Delete([FromBody]int id)
        {
            _contactRepo.Remove(id);
        }

        [HttpPost]
        [Route("addAddress")]
        public void AddAddress([FromBody]AddAddressViewModel viewModel)
        {
            _contactRepo.AddAddress(viewModel.ContactId, viewModel.AddressId, viewModel.AddressType);
        }

    }
}