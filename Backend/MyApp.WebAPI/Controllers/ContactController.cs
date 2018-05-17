using MyApp.SqlServerModel.Dtos;
using MyApp.SqlServerModel.Entities;
using MyApp.SqlServerModel.Repositories;
using MyApp.WebAPI.Models.ContactModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
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
        public IHttpActionResult Post([FromBody]Contact value)
        {
            _contactRepo.Create(value);
            return Ok();
        }

        [HttpPatch]
        [Route("edit")]
        public async Task<IHttpActionResult> Put([FromBody]ContactUpdateDto value)
        {
            await _contactRepo.Update(value);
            return Ok();
        }

        [HttpPost]
        [Route("delete")]
        public IHttpActionResult Delete([FromBody]int id)
        {
            _contactRepo.Remove(id);
            return Ok();
        }

        [HttpPost]
        [Route("addAddress")]
        public IHttpActionResult AddAddress([FromBody]AddAddressViewModel viewModel)
        {
            _contactRepo.AddAddress(viewModel.ContactId, viewModel.AddressId, viewModel.AddressType);
            return Ok();
        }

    }
}