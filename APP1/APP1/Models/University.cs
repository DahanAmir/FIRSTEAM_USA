using APP1.Models.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APP1.Models
{
    public class University
    {
        string email;
        string universityName;
        string states;
        string district;
        string url;
        int priceMAX ;
        int priceMIN;
        int universitySize;
        string universityLevel;
        int zip;
        int id;
        public University()
        {

        }
        public University(string email, string universityName)
        {
            Email = email;
            UniversityName = universityName;
        }
        public University(int id,string email ,string universityName, string states, string district, string url, int priceMAX, int priceMIN, int universitySize, string universityLevel, int zip)
        {
            UniversityName = universityName;
            States = states;
            District = district;
            Url = url;
            PriceMAX = priceMAX;
            PriceMIN = priceMIN;
            UniversitySize = universitySize;
            UniversityLevel = universityLevel;
            Zip = zip;
            Email = email;
            Id = id;
        }

        public string UniversityName { get => universityName; set => universityName = value; }
        public string States { get => states; set => states = value; }
        public string District { get => district; set => district = value; }
        public string Url { get => url; set => url = value; }
        public int PriceMAX { get => priceMAX; set => priceMAX = value; }
        public int PriceMIN { get => priceMIN; set => priceMIN = value; }
        public int UniversitySize { get => universitySize; set => universitySize = value; }
        public string UniversityLevel { get => universityLevel; set => universityLevel = value; }
        public int Zip { get => zip; set => zip = value; }
        public string Email { get => email; set => email = value; }
        public int Id { get => id; set => id = value; }

        public void  Insert_University_Email(List<University> IUE)
        {
            DB_Services db = new DB_Services();
                db.Insert_University_Email(IUE);
        }



            public int getDivision(int d)
        {
            DB_Services db = new DB_Services();
            return db.getDivision(d);
        }


        public List<University>  getdiv()
        {
            DB_Services dbs = new DB_Services();

            
            return dbs.getdiv();
        }

        public List<University> getWish(string email)
        {
            DB_Services dbs = new DB_Services();


            return dbs.getWish(email);
        }





        public int SaveWishList(List <University>  u)
        {
            DB_Services dbs = new DB_Services();

            return dbs.SaveWishList(u);
        }



        public List<University> getR()
        {
            DB_Services dbs = new DB_Services();


            return dbs.getR();
        }

    }
}