using MyApp.SqlServerModel.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MyApp.WebAPI.Controllers
{
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
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
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