using APP1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace APP1.Controllers
{
    public class UserDataController : ApiController
    {
        // GET api/<controller>
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        // GET api/<controller>/5
        //public string Get(int id)
        //{
        //    return "value";
        //}


        [HttpGet]
        [Route("api/UserData/all_data")]
        public List<UserData> Get(UserData ud)
        {
            UserData u = new UserData();
            return u.Show_Users_Data(ud.Email);
        }


        // POST api/<controller>

        [HttpPost]
        [Route("api/UserData")]
        public int Post (UserData u)
        {
            return u.Insert_New_UserData(u);
        }

        [HttpPut]
        [Route("api/UserData")]
        public List<UserData>  Put(UserData ud)
        {
            UserData u = new UserData();
            return u.Show_Users_Data(ud.Email);
        }

        //// DELETE api/<controller>/5
        //public void Delete(int id)
        //{
        //}
    }
}