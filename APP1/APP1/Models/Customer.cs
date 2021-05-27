using APP1.Models.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APP1.Models
{
    public class Customer
    {
        string name;
        string fname;
        string email;
        string phone;
        string password;
        string myfile;
        int pricerange;



        public Customer(string name, string fname, string email, string phone, string password, string myfile, int pricerange)
        {
            Name = name;
            Fname = fname;
            Email = email;
            Phone = phone;
            Password = password;
            Myfile = myfile;
            Pricerange = pricerange;


        }

        public Customer(string email, string password)
        {

            Email = email;
            Password = password;



        }



        public string Name { get => name; set => name = value; }
        public string Fname { get => fname; set => fname = value; }
        public string Email { get => email; set => email = value; }
        public string Phone { get => phone; set => phone = value; }
        public string Password { get => password; set => password = value; }
        public string Myfile { get => myfile; set => myfile = value; }
        public int Pricerange { get => pricerange; set => pricerange = value; }

        public Customer() { }


        public List<Customer> Show()
        {

            DBServices dbs = new DBServices();
            List<Customer> cList = dbs.Show();
            return cList;

        }
        public int InsertCust()
        {
            DBServices dbs = new DBServices();
            return dbs.InsertCust(this);
        }

        public int title(string email)
        {
            DBServices dbs = new DBServices();
            return dbs.title(email);
        }


        public bool show_u(string email, string password)
        {

            DBServices dbs = new DBServices();
            return dbs.show_u(email, password);

        }

        public int on_mouseover(int id)
        {

            DBServices dbs = new DBServices();
            return dbs.on_mouseover(id);

        }


        public int put_c(string title, string email, int status)
        {
            DBServices dbs = new DBServices();
            return dbs.put_c(title, email, status);
        }
    }
}