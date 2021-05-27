using APP1.Models.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APP1.Models
{
    public class File
    {
        string email;
        int isnull;
        string filetype;
        string remark ;
        string fileName;
        int score;
        string full_Name;
        int id;
        public File()
        {

        }
        public File(string filetype, string remark, string fileName, int score,string email, int isnull, string full_Name,int id)
        {
            Isnull = isnull;
            Filetype = filetype;
            Remark = remark;
            FileName = fileName;
            Score = score;
            Email = email;
            Id = id;
            Full_Name = full_Name;
        }

        public string Filetype { get => filetype; set => filetype = value; }
        public string Remark { get => remark; set => remark = value; }
        public string FileName { get => fileName; set => fileName = value; }
        public int Score { get => score; set => score = value; }
        public string Email { get => email; set => email = value; }
        public int Isnull { get => isnull; set => isnull = value; }
        public string Full_Name { get => full_Name; set => full_Name = value; }
        public int Id { get => id; set => id = value; }

        public List<File> get_UF()
        {
            List<File> t = new List<File>();
            DB_Services dbs = new DB_Services();

            return dbs.show_UF();
        }




    }


    //public int SaveFiles(List<File> f)
    //{
    //    DB_Services dbs = new DB_Services();

    //    return dbs.SaveFiles(f);
    //}




}