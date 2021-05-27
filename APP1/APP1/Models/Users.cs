using APP1.Models.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APP1.Models
{
    public class Users
    {
        string email;
        string password;
        string firstName;
        string lastName;
        string phone;
        int typeUsers;
        DateTime birthDay;
        string sex;
        string position;
        DateTime register;
        string address;
        string status;
        int statusId;
        float height;
        DateTime estimatedYear;
        int active;

        public Users()
        {

        }
        public Users(float height, string status, int statusId,string address , DateTime register, string position, string email, string password, string firstName, string lastName, string phone, int typeUsers, DateTime birthDay, string sex, DateTime estimatedYear, int active)
        {
            Email = email;
            Password = password;
            FirstName = firstName;
            LastName = lastName;
            Phone = phone;
            TypeUsers = typeUsers;
            BirthDay = birthDay;
            Sex = sex;
            Position = position;
            Register = register;
            Address = address;
            Status = status;
            StatusId = statusId;
            Height = height;
            EstimatedYear= estimatedYear;
            Active = active;
        }

        public string Email { get => email; set => email = value; }
        public string Password { get => password; set => password = value; }
        public string FirstName { get => firstName; set => firstName = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public string Phone { get => phone; set => phone = value; }
        public int TypeUsers { get => typeUsers; set => typeUsers = value; }
        public DateTime BirthDay { get => birthDay; set => birthDay = value; }
        public string Sex { get => sex; set => sex = value; }
        public string Position { get => position; set => position = value; }
        public DateTime Register { get => register; set => register = value; }
        public string Address { get => address; set => address = value; }
        public string Status { get => status; set => status = value; }
        public int StatusId { get => statusId; set => statusId = value; }
        public float Height { get => height; set => height = value; }
        public DateTime EstimatedYear { get => estimatedYear; set => estimatedYear = value; }
        public int Active { get => active; set => active = value; }

        public int update_New_Users(Users u)
        {
            DB_Services dbs = new DB_Services();

            return dbs.update_New_Users(u);
        }
        public int Insert_New_Users(Users u)
        {
            DB_Services dbs = new DB_Services();

            return dbs.Insert_New_Users(u);
        }
        public List<Users> Show_Users()
        {

            DB_Services dbs = new DB_Services();
            List<Users> cList = dbs.Show_Users();
            return cList;

        }
        public int Login_User(string email, string password)
        {
            DB_Services dbs = new DB_Services();
            
            return dbs.Login_User(email, password); ;

        }
        public int Delete_Users(Users u)
        {
            DB_Services dbs = new DB_Services();

            return dbs.Delete_Users(u); ;

        }
        
    }
}