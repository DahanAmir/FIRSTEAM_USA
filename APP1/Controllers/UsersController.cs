using APP1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.UI.WebControls;

namespace APP1.Controllers
{
    public class UsersController : ApiController
    {
        // GET api/<controller>
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        // GET api/<controller>/5
        [HttpGet]
        [Route("api/Users/{email}/{password}")]
        public int Get(string email, string password)
        {
            Users u = new Users();
            return u.Login_User(email, password);
        }
        [HttpGet]
        [Route("api/Users/{users_show}/Show_all_users")]
        public List<Users> Get(string users_show)
        {
            Users u = new Users();
            return u.Show_Users();
        }


        [HttpPost]
        [Route("api/Users/update")]
        public int Post(Users u)
        {
            return u.update_New_Users(u);
        }


        [HttpPut]
        [Route("api/Users")]
        public int Put(Users u)
        {
            return u.Insert_New_Users(u);
        }

        // PUT api/<controller>/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        // DELETE api/<controller>/5
        [HttpDelete]
        [Route("api/Users/Delete")]
        public int Delete(Users u)
        {
        
            return u.Delete_Users(u);
        }
    }
}