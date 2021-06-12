using APP1.Models.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APP1.Models
{
    public class ToDoList
    {
        int taskid;
        string email;
        string task;
        DateTime dueDate;
        string status;
        int active;
        
        public ToDoList()
        {
            
        }
        public ToDoList(int Taskid, string email, string task, DateTime dueDate, string status, int active)
        {

            Taskid = taskid;
            Email = email;
            Task = task;
            DueDate = dueDate;
            Status = status;
            Active = active;

        }

        public string Email { get => email; set => email = value; }
        public string Task { get => task; set => task = value; }
        public DateTime DueDate { get => dueDate; set => dueDate = value; }
        public string Status { get => status; set => status = value; }
        public int Taskid { get => taskid; set => taskid = value; }
        public int Active { get => active; set => active = value; }

        public List<ToDoList> get_User_ToDoList(string email)
        {
            List<ToDoList> t = new List<ToDoList>();
            DB_Services dbs = new DB_Services();

            return dbs.show_ToDoList(email);
        }

        public int Insert_ToDoList(ToDoList t)
        {
            DB_Services dbs = new DB_Services();

            return dbs.Insert_ToDoList(t);
        }

        public int Delete_todo(int id)
        {
            DB_Services dbs = new DB_Services();

            return dbs.Delete_todo(id); ;

        }
    }
}