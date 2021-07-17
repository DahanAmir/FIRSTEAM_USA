using APP1.Models.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APP1.Models
{
    public class Status
    {

        int id;
        int active;
        string statusname;

        public Status() { }

        public Status(int id, int active, string statusname)
        {
            Id = id;
            Active = active;
            Statusname = statusname;
        }

        public int Id { get => id; set => id = value; }
        public int Active { get => active; set => active = value; }
        public string Statusname { get => statusname; set => statusname = value; }

        public int Insert_status(Status s)
        {
            DB_Services db = new DB_Services();
            return db.Insert_status(s);
        }
        public int update_status(Status s)
        {
            DB_Services db = new DB_Services();
            return db.update_status(s);
        }

        public List<Status> get_status()
        {
            DB_Services db = new DB_Services();
            return db.get_status();
        }
    }
}