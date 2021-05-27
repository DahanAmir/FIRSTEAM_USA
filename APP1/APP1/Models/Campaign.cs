using APP1.Models.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APP1.Models
{
    public class Campaign
    {
        int campid;
        int budget;
        int remain;
        int clicks;
        int views;
        int status;



        public Campaign()
        {
        }
        public Campaign(int campid, int budget)
        {
            Campid = campid;
            Budget = budget;
            //Status = status;

        }

        public Campaign(int campid, int budget, int remain, int status)
        {
            Campid = campid;
            Budget = budget;
            Remain = remain;
            Status = status;

        }
        public Campaign(int campid, int budget, int remain, int clicks, int views, int status)
        {
            Campid = campid;
            Budget = budget;
            Remain = remain;
            Clicks = clicks;
            Views = views;
            Status = status;

        }

        public int Campid { get => campid; set => campid = value; }
        public int Budget { get => budget; set => budget = value; }
        public int Remain { get => remain; set => remain = value; }
        public int Clicks { get => clicks; set => clicks = value; }
        public int Views { get => views; set => views = value; }
        public int Status { get => status; set => status = value; }



        public int click(int id, int parameter)
        {
            DBServices dbs = new DBServices();
            return dbs.click(id, parameter);
        }





        //public int InsertC()
        //{
        //    DBServices dbs = new DBServices();
        //    return dbs.InsertC(this);
        //}
        public List<Campaign> ShowC()
        {
            DBServices dbs = new DBServices();
            List<Campaign> campList = dbs.ShowC();
            return campList;

        }






        public List<Campaign> Show_campaigns()
        {
            DBServices dbs = new DBServices();
            List<Campaign> campList = dbs.Show_campaigns();
            return campList;

        }



        public List<Campaign> ShowC(int status)
        {
            DBServices dbs = new DBServices();
            List<Campaign> campList = dbs.ShowC(status);
            return campList;

        }

      

        public bool updatecamp(int id, int budget)
        {

            DBServices dbs = new DBServices();
            return dbs.updatecamp(id, budget);


        }

        public void delete (int id)
        {
            DBServices dbs = new DBServices();
             dbs.deletecamp(id);

        }


    }
}