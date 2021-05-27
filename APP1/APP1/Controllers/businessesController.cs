using APP1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace APP1.Controllers
{
    public class businessesController : ApiController
    {
        // GET api/<controller>
        public List<Businesses> Get()
        {
            Businesses businesses = new Businesses();
            List<Businesses> bList = businesses.Show_r();
            return bList;



        }
        [HttpGet]
        [Route("api/Businesses/{category}/{price}")]
        public List<Businesses> Get(string category, int price)
        {
            Businesses businesses = new Businesses();
            List<Businesses> bList = businesses.Show_r(category, price);
            return bList;



        }
        [HttpGet]
        [Route("api/Businesses/{status}")]
        public List<Businesses> Get(int status)
        {
            Businesses businesses = new Businesses();
            List<Businesses> bList = businesses.Show_r_s(status);
            return bList;



        }



        [HttpGet]
        [Route("api/Businesses/email/status/{email}/{status}")]
        public List<Businesses> Get_e(string email, int status)
        {
            Businesses businesses = new Businesses();
            email = email.Replace("dotttt", ".");
            List<Businesses> bList = businesses.Show_r_s_e(email, status);
            return bList;
        }





        // POST api/<controller>
        public void Post([FromBody] Businesses bs)
        {
            bs.Insert();
        }

       
    }
}