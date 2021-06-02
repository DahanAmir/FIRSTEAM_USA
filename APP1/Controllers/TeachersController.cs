using APP1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace APP1.Controllers
{
    public class TeachersController : ApiController
    {

        [HttpGet]
        [Route("api/Teachers/get")]
        // GET api/<controller>
       
        public List<Teachers> Get()
        {
            Teachers t = new Teachers();
            return t.Show_Teachers();
        }


        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
       

        [HttpPost]
        [Route("api/Teachers/add")]
        public int Post(Teachers t)
        {
            return t.Insert_New_Teacher(t);
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}