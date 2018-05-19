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
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;

namespace MyApp.WebAPI.Controllers
{
    [System.Web.Http.RoutePrefix("api/contact")]
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
            if (id == 0)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.NotFound,
                    "id can not be null"));
            }

            var result = _contactRepo.FindById(id);
            return result;
        }

        // POST api/values
        public async Task<IHttpActionResult> Post([FromBody]Contact value)
        {
            if (value == null)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.NotFound,
                    "contact can not be null"));
            }

            var result = await _contactRepo.Create(value);
            return Ok(result);
        }

        [System.Web.Http.HttpPatch]
        [System.Web.Http.Route("edit")]
        public async Task<IHttpActionResult> Edit([FromBody]ContactUpdateDto value)
        {
            var result = await _contactRepo.Update(value);
            return Ok(result);
        }

        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("delete")]
        public async Task<IHttpActionResult> Delete([FromBody]int id)
        {
            var result = await _contactRepo.Remove(id);
            return Ok(result);
        }

        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("addAddress")]
        public async Task<IHttpActionResult> AddAddress([FromBody]AddAddressToContactDto dto)
        {
            var result = await _contactRepo.AddAddress(dto);
            return Ok(result);
        }

    }
}