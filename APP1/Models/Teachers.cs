using APP1.Models.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APP1.Models
{
    public class Teachers
    {
        string email;
        string firstname;
            string lastname;
        string phone;
        int active;


        public string Email { get => email; set => email = value; }
        public string Firstname { get => firstname; set => firstname = value; }
        public string Lastname { get => lastname; set => lastname = value; }
        public string Phone { get => phone; set => phone = value; }
        public int Active { get => active; set => active = value; }

        public Teachers() { }

        public Teachers(string email, string firstname, string lastname)
        {
            Email = email;
            Firstname = firstname;
            Lastname = lastname;
            Phone = phone;
            Active = active;
        }

        public int Insert_New_Teacher(Teachers t)
        {
            DB_Services dbs = new DB_Services();

            return dbs.Insert_New_Teacher(t);
        }

        public List<Teachers> Show_Teachers()
        {

            DB_Services dbs = new DB_Services();
            List<Teachers> tList = dbs.Show_Teachers();
            return tList;

        }


    }


}