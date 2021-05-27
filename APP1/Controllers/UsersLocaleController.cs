using APP1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace APP1.Controllers
{
    public class UsersLocaleController : ApiController
    {

        //[HttpGet]
        //[Route("api/UsersLocale/get_all_Locales/2")]
        //public List<UsersLocale> Get(string email)
        //{
        //    UsersLocale u = new UsersLocale();
        //    return u.get_User_Locale(email);
        //}
        // GET api/<controller>
        [HttpGet]
        [Route("api/UsersLocale/{email}/get_all_Locale")]
        public List<UsersLocale> Get(string email)
        {
           
            UsersLocale u = new UsersLocale();
            return u.get_User_Locale(email);
        }

        // GET api/<controller>/5
       

        [HttpPost]
        [Route("api/UsersLocale/list_user_Locale")]
        public int Post(List<UsersLocale> us)
        {
           
            return us[0].Insert_arr_Locale(us);

        }

    }
}