using APP1.Models.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APP1.Models
{
    public class Favorites
    {
        string email;
        int universitySize;
        string universityLevel;
        int priceMAX;
        string universityType;
        int sat;
        public Favorites(){ }
        public Favorites(string email, int universitySize, string universityLevel, int priceMAX, string universityType, int sat)
        {
            Email = email;
            UniversitySize = universitySize;
            UniversityLevel = universityLevel;
            PriceMAX = priceMAX;
            UniversityType = universityType;
            Sat = sat;
            
        }

        public int UniversitySize { get => universitySize; set => universitySize = value; }
        public string UniversityLevel { get => universityLevel; set => universityLevel = value; }
        public int PriceMAX { get => priceMAX; set => priceMAX = value; }
        public string UniversityType { get => universityType; set => universityType = value; }
        public int Sat { get => sat; set => sat = value; }
        public string Email { get => email; set => email = value; }

        public int Insert_Favorites(Favorites f)
        {
            DB_Services dbs = new DB_Services();

            return dbs.Insert_Favorites(f);
        }

        public Favorites Get_Favorites_By_email(string email)
        {
            DB_Services db = new DB_Services();
            return db.Get_Favorites_By_email(email);
        }

      

    }
}