using APP1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
namespace APP1.Controllers
{
    public class UsersFileController : ApiController
    {
        // GET api/<controller>
        [HttpGet]
        [Route("api/UsersFile/get_all_UF")]

        public List<File> Get()
        {
            File f = new File();
            return f.get_UF();
        }
        [HttpDelete]
        [Route("api/UsersFile/get_all_File_Type")]
        public List<File> Delete()
        {
            File f = new File();
            return f.get_FT();
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }
        [HttpPost]
        [Route("api/UsersFile/Post_Favorite/insert/save")]
        // POST api/<controller>
        public int Post(File f)
        {
            return f.insertFile(f);
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