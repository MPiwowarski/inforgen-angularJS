using MyApp.SqlServerModel.Dtos;
using MyApp.SqlServerModel.Entities;
using MyApp.SqlServerModel.Repositories;
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
        public IEnumerable<ContactBasicInfo> Get()
        {
            var result = _contactRepo.GetAll();
            return result;
        }

        // GET api/values/5
        public ContactDetailsDto Get(int id)
        {
            var result = _contactRepo.FindById(id);
            return result;
        }

        // POST api/values
        public IHttpActionResult Post([FromBody]Contact value)
        {
            _contactRepo.Create(value);
            return Ok();
        }

        [HttpPatch]
        [Route("edit")]
        public async Task<IHttpActionResult> Patch([FromBody]ContactUpdateDto value)
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
        public IHttpActionResult AddAddress([FromBody]AddAddressToContactDto dto)
        {
            return Ok(_contactRepo.AddAddress(dto));
        }

    }
}