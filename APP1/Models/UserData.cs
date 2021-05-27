using APP1.Models.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APP1.Models
{
    public class UserData
    {
        int gender;
        string email;
        int national;
        int captain;
        int league;
        int champions;
        int cups;
        int tofel;
        int sat;
        float gpa;
        string position;
       

        public UserData(int gender, string email, int national, int captain, int league, int champions, int cups, int tofel, int sat, float gpa, string position)
        {
            Gender = gender;
            Email = email;
            National = national;
            Captain = captain;
            League = league;
            Champions = champions;
            Cups = cups;
            Tofel = tofel;
            Sat = sat;
            Gpa = gpa;
            Position = position;
        
        }

        public UserData() {}

    public int Gender { get => gender; set => gender = value; }
        public string Email { get => email; set => email = value; }
        public int National { get => national; set => national = value; }
        public int Captain { get => captain; set => captain = value; }
        public int League { get => league; set => league = value; }
        public int Champions { get => champions; set => champions = value; }
        public int Cups { get => cups; set => cups = value; }
        public int Tofel { get => tofel; set => tofel = value; }
        public int Sat { get => sat; set => sat = value; }
        public float Gpa { get => gpa; set => gpa = value; }
        public string Position { get => position; set => position = value; }
      


        public int Insert_New_UserData(UserData u)
        {
            DB_Services dbs = new DB_Services();

            return dbs.Insert_New_UserData(u);
        }

        public List<UserData> Show_Users_Data(string email)
        {

            DB_Services dbs = new DB_Services();
            List<UserData> UserDataList = dbs.Show_Users_Data(email);
            return UserDataList;

        }

    }



}