using System;
using System.Web.Http;
using System.Collections.Generic;
using System.Web.Http.Cors;

using JobFairApi.Models;
using System.Web.Http.Description;
using JobFairApi.Repository;

namespace JobFairApi.Controllers
{
    public class RegistrationController : ApiController
    {
        private RegistrationRepository repo = new RegistrationRepository();


        // GET: /Api/Registration/GetAll
        [ResponseType(typeof(IEnumerable<Registration>))]
        [HttpGet]
        [EnableCors(origins: "*", methods: "*", headers: "*")]
        public IHttpActionResult GetAll()
        {
            var result = repo.GetRegistrations();

            return Ok(result);
        }

        //POST: /Api/Registration/Add
        [HttpPost]
        [EnableCors(origins: "*", methods: "*", headers: "*")]
        public IHttpActionResult Add([FromBody] Registration newRegistration)
        {
            repo.AddRegistration(newRegistration);
            return Ok();
        }


    }
}
