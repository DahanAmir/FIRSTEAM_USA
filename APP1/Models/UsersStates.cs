using APP1.Models.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APP1.Models
{
    public class UsersStates
    {

        int id;
        string email;
        string states;

        public UsersStates() { }

        public UsersStates(int id, string email, string states)
        {
            Id = id;
            Email = email;
            States = states;
        }

        public int Id { get => id; set => id = value; }
        public string Email { get => email; set => email = value; }
        public string States { get => states; set => states = value; }

        public int Insert_arr_states(List<UsersStates> us)
        {
            DB_Services db = new DB_Services();
            return db.Insert_arr_states(us);
        }

        public List<UsersStates> get_User_States(string email)
        {
            DB_Services db = new DB_Services();
            return db.get_User_States(email);
        }
    }
}