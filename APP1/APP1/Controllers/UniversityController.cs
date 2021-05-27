using APP1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace APP1.Controllers
{
    public class UniversityController : ApiController
    {
        // GET api/<controller>
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        [HttpGet]
        [Route("api/University/getdiv")]
        public List<University> Get()
        {
            University un = new University();
            return un.getdiv();
        }

        [HttpGet]
        [Route("api/University/getrank")]
        public List<University> GetRank()
        {
            University un = new University();
            return un.getR();
        }


        [HttpGet]
        [Route("api/University/{email}/get_wishlist")]
        public List<University> GetWish(string email)
        {
            University un = new University();
            return un.getWish(email);
        }







        [HttpPost]
        [Route("api/University")]
        public int Post(List<University> wishlist)
        {
            University un = new University();

            return un.SaveWishList(wishlist);
        }




        // GET api/<controller>/5
        public int Get(int division)
        {
            University un= new University();
           return un.getDivision(division);
        }

        // POST api/<controller>
        //public void Post(List <University> IUE)
        //{
        //    //University u
        //    //u.Insert_University_Email(IUE);
        //}

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