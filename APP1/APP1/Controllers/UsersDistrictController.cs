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
    public class UsersDistrictController : ApiController
    {
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        //[HttpPost]
        //[Route("api/UsersDistrict/1/{email}")]
        //public int Get(string email)
        //{
        //    UsersDistrict u = new UsersDistrict();
        //    return u.get_User_district(email);
        //}







        [HttpGet]
        [Route("api/UsersDistrict/{email}/get_all_District")]
        public List<UsersDistrict> Get(string email)
        {
            UsersDistrict u = new UsersDistrict();
            return u.get_User_district(email);
        }
        [HttpGet]
        [Route("api/UsersDistrict")]
        public List <UsersDistrict> Get(List<UsersDistrict> email)
        {
            UsersDistrict u = new UsersDistrict();
            return u.get_User_district(u.Email);
        }

        //POST api/<controller>
        [HttpPost]
        [Route("api/UsersDistrict/1")]
        public int Post(List<UsersDistrict> list_user_districts)
        {
            UsersDistrict u = new UsersDistrict();
           return u.Insert_arry_region(list_user_districts);
           
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {

        }
    }
}