﻿
using APP1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace APP1.Controllers
{
    public class ToDoListController : ApiController
    {
        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }


       
        [HttpGet]
        [Route("api/ToDoList/{email}/get_all_TODO")]
        public List<ToDoList> Get(string email)
        {
            ToDoList u = new ToDoList();
            return u.get_User_ToDoList(email);
        }


        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>

       
        public int Post(ToDoList Post_ToDoList)
        {
            ToDoList todo = new ToDoList();
            return todo.Insert_ToDoList(Post_ToDoList);

        }

        [HttpPut]
        [Route("api/ToDoList/{u}/update")]
        public int PUT(ToDoList u)
        {
            return u.update_todo(u);
        }








        // PUT api/<controller>/5
        public int Put(List<UsersStates> lus)
        {
            return lus[0].Insert_arr_states(lus);

        }

        [HttpDelete]
        [Route("api/ToDoList/{id}/del")]

        // DELETE api/<controller>/5
        public int Delete(int id)
        {

            ToDoList td = new ToDoList();
                return td.Delete_todo(id);
           
        }

        [HttpPost]
        [Route("api/UsersDistrict/list_user_States")]
        public int Post(List<UsersStates> us)
        {
            UsersStates usersstates = new UsersStates();
            return usersstates.Insert_arr_states(us);

        }
    }
}