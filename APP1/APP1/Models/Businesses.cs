using APP1.Models.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APP1.Models
{
    public class Businesses
    {
        string name;
        string featured_image;
        int id;
        float price;
        double rating;
        string address;
        string phone;
        string url;



        public string Name { get => name; set => name = value; }
        public string Featured_image { get => featured_image; set => featured_image = value; }
        public int Id { get => id; set => id = value; }
        public float Price { get => price; set => price = value; }
        public double Rating { get => rating; set => rating = value; }
        public string Address { get => address; set => address = value; }
        public string Phone { get => phone; set => phone = value; }
        public string Url { get => url; set => url = value; }

        public Businesses() { }

        public Businesses(string name, string featured_image, int id, float price, int rating, string address, string phone, string url)
        {
            Name = name;
            Featured_image = featured_image;
            Id = id;
            Price = price;
            Rating = rating;
            Address = address;
            Phone = phone;
            Url = url;

        }


        public void Insert()
        {
            DBServices dbs = new DBServices();
            dbs.Insert(this);
        }



        public List<Businesses> Show_r()
        {

            DBServices dbs = new DBServices();
            List<Businesses> bList = dbs.Show_r();
            return bList;

        }
        public List<Businesses> Show_r(string category, int price)
        {

            DBServices dbs = new DBServices();
            List<Businesses> bList = dbs.Show_r(category, price);
            return bList;

        }


       
        public List<Businesses> Show_r_s(int status)
        {

            DBServices dbs = new DBServices();
            List<Businesses> bList = dbs.Show_r_s(status);
            return bList;

        }
        public List<Businesses> Show_r_s_e(string  email, int status)
        {

            DBServices dbs = new DBServices();
            List<Businesses> bList = dbs.Show_r_s_e(email, status);
            return bList;

        }
    }
}