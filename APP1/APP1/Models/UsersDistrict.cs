using APP1.Models.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APP1.Models
{
    public class UsersDistrict
    {
        int id;
        string email;
        string district;

        public UsersDistrict() { }

        public UsersDistrict(int id, string email, string district)
        {
            Id = id;
            Email = email;
            District = district;
        }

        public int Id { get => id; set => id = value; }
        public string Email { get => email; set => email = value; }
        public string District { get => district; set => district = value; }

        public int Insert_arry_region(List<UsersDistrict> ud)
        {
            DB_Services db = new DB_Services();
            return db.insert_arr_region(ud);
        }


        public List<UsersDistrict> get_User_district(string email)
        {
            DB_Services db = new DB_Services();
            return db.get_User_district(email);
        }

    }
    
}