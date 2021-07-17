using APP1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace APP1.Controllers
{
    public class StatusController : ApiController
    {
        // GET api/<controller>
        public List<Status> Get()
        {
            Status s = new Status();
            return s.get_status();
        }

        // GET api/<controller>/5
        public int Post(Status s)
        {
            return s.Insert_status(s);
        }
        public int Put(Status s)
        {
            return s.update_status(s);
        }

        // POST api/<controller>
      

      

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}