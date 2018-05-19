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

        [HttpGet]
        public IEnumerable<Address> Get()
        {
            var result = _addressRepo.GetAll();
            return result;
        }

        [HttpGet]
        public async Task<IHttpActionResult> Get(int id)
        {
            var result = await _addressRepo.FindById(id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IHttpActionResult> Post([FromBody]Address value)
        {
            var result = await _addressRepo.Create(value);
            return Ok(result);
        }

        [HttpPatch]
        [Route("edit")]
        public async Task<IHttpActionResult> Patch([FromBody]Address value)
        {
            var result = await _addressRepo.Update(value);
            return Ok(result);
        }

        [HttpPost]
        [Route("delete")]
        public async Task<IHttpActionResult> Delete([FromBody]int id)
        {
            var result = await _addressRepo.Remove(id);
            return Ok(result);
        }

    }
}