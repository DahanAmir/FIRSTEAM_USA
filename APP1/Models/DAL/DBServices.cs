using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Configuration;

namespace APP1.Models.DAL
{
    public class DBServices
    {
        

        //--------------------------------------------------------------------------------------------------
        // This method creates a connection to the database according to the connectionString name in the web.config 
        //--------------------------------------------------------------------------------------------------
        public SqlConnection connect(String conString)
        {

            // read the connection string from the configuration file
            string cStr = WebConfigurationManager.ConnectionStrings[conString].ConnectionString;
            SqlConnection con = new SqlConnection(cStr);
            con.Open();
            return con;
        }
        public int Insert(Businesses businesses)
        {
            SqlConnection con;
            SqlCommand cmd;

            try
            {
                con = connect("DBConnectionString"); // create the connection
            }
            catch (Exception ex)
            {
                // write to log
                throw (ex);
            }

            String cStr = BuildInsertCommand(businesses);      // helper method to build the insert string

            cmd = CreateCommand(cStr, con);             // create the command

            try
            {
                int numEffected = cmd.ExecuteNonQuery(); // execute the command
                return numEffected;
            }
            catch (Exception ex)
            {
                // write to log
                throw (ex);
            }

            finally
            {
                if (con != null)
                {
                    // close the db connection
                    con.Close();
                }
            }

        }


        private String BuildInsertCommand(Businesses businesses)
        {
            String command;

            StringBuilder sb = new StringBuilder();

            // use a string builder to create the dynamic string
            sb.AppendFormat("Values('{0}','{1}', '{2}', '{3}', '{4}', '{5}', '{6}','{7}','{8}')", businesses.Name.Replace("'", "''"), businesses.Featured_image, businesses.Id, businesses.Price, businesses.Rating, businesses.Address, businesses.Phone);
            String prefix = "INSERT INTO Restaurants_2021 " + "( NAME , [FEATURED IMAGE] , ID ,PRICE ,RATING ,ADDRESS ,PHONE) ";
            command = prefix + sb.ToString();

            return command;
        }


        private String BuildInsertCommand(Campaign campaign)
        {
            String command;

            StringBuilder sb = new StringBuilder();

            // use a string builder to create the dynamic string
            sb.AppendFormat("Values('{0}','{1}', '{2}', '{3}', '{4}', '{5}')", campaign.Campid, campaign.Budget, campaign.Remain, campaign.Clicks, campaign.Views, campaign.Status);
            String prefix = "INSERT INTO Campaign_2021 " + "( [campaign ID] ,BUDGET , REMAIN ,CLICKS ,VIEWS , STATUS) ";
            command = prefix + sb.ToString();

            return command;
        }



        public int Insert(Customer costumer)
        {
            SqlConnection con;
            SqlCommand cmd;

            try
            {
                con = connect("DBConnectionString"); // create the connection
            }
            catch (Exception ex)
            {
                // write to log
                throw (ex);

            }

            String cStr = BuildInsertCommand(costumer);      // helper method to build the insert string
            
            cmd = CreateCommand(cStr, con);             // create the command

            try
            {
                int numEffected = cmd.ExecuteNonQuery(); // execute the command
                return numEffected;
            }
            catch (Exception ex)
            {
                // write to log
                throw (ex);
            }

            finally
            {
                if (con != null)
                {
                    // close the db connection
                    con.Close();
                }
            }

        }




        public int on_mouseover(int id)
        {
            SqlConnection con = null;

            try
            {
                con = connect("DBConnectionString"); // create a connection to the database using the connection String defined in the web config file

                String selectSTR = "SELECT * FROM Restaurants_2021  ";
                SqlCommand cmd = new SqlCommand(selectSTR, con);

                // get a reader
                SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection); // CommandBehavior.CloseConnection: the connection will be closed after reading has reached the end

                while (dr.Read())
                {   // Read till the end of the data into a row
                    if (id == Convert.ToInt32(dr["restid"]))
                        return 1;
                }
                return 0;

            }
            catch (Exception ex)
            {
                // write to log
                throw (ex);
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                }
            }
        }


        public int click(int id, int parameter)
        {
            SqlConnection con = null;

            try
            {
                con = connect("DBConnectionString"); // create a connection to the database using the connection String defined in the web config file
                SqlCommand cmd;
                String selectSTR;
                if (parameter == 0)
                {
                    selectSTR = "update[campaign_2021] SET  [campaign_2021].VIEWS= [campaign_2021].VIEWS+1 ,  [campaign_2021].remain= [campaign_2021].remain-10  WHERE restid =  '" + id+ "' and status=1 ";
                    cmd = new SqlCommand(selectSTR, con);
                }
                else
                {

                    selectSTR = "update[campaign_2021] SET[campaign_2021].CLICKS = ([campaign_2021].CLICKS) + 1 ,[campaign_2021].remain = ([campaign_2021].remain) - 50 WHERE( [campaign_2021].restid = '" + id + "' and[campaign_2021].status = 1)";
                    cmd = new SqlCommand(selectSTR, con);
                }

                


                // get a reader 
                SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection); // CommandBehavior.CloseConnection: the connection will be closed after reading has reached the end

                while (dr.Read())
                {   // Read till the end of the data into a row
                    if (id == Convert.ToInt32(dr["restid"]))
                        return 1;
                }
                return 0;

            }
            catch (Exception ex)
            {
                // write to log
                throw (ex);
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                }
            }
        }


        public void deletecamp(int id)
        {
            SqlConnection con = null;

            try
            {
                con = connect("DBConnectionString"); // create a connection to the database using the connection String defined in the web config file
                SqlCommand cmd;
                String selectSTR;


                selectSTR = "update[campaign_2021] SET status = 0   WHERE restid =  " + id;
                    cmd = new SqlCommand(selectSTR, con);
              
               

                // get a reader 
                SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection); // CommandBehavior.CloseConnection: the connection will be closed after reading has reached the end

               
            }
            catch (Exception ex)
            {
                // write to log
                throw (ex);
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                }
            }
        }

        public int title(string email) // מכניס לשרת הייליטס של משתמש עם אתחול של 0
        {
            SqlConnection con;
            SqlCommand cmd;

            try
            {
                con = connect("DBConnectionString"); // create the connection
            }
            catch (Exception ex)
            {
                // write to log
                throw (ex);
            }
            String cStr = "INSERT INTO[CUSTOMER & Highlight_2021](TITLE, EMAIL, STATUS) VALUES('fULLBAR', '" + email + "', 0)";
            cStr +=   "INSERT INTO[CUSTOMER & Highlight_2021](TITLE, EMAIL, STATUS) VALUES('Air Conditioned', '" + email + "', 0)";
            cStr +=   "INSERT INTO[CUSTOMER & Highlight_2021](TITLE, EMAIL, STATUS) VALUES('Brunch', '" + email + "', 0)";
            cStr +=   "INSERT INTO[CUSTOMER & Highlight_2021](TITLE, EMAIL, STATUS) VALUES('Buffet', '" + email + "', 0)";
            cStr +=   "INSERT INTO[CUSTOMER & Highlight_2021](TITLE, EMAIL, STATUS) VALUES('Cafes', '" + email + "', 0)";
            cStr +=   "INSERT INTO[CUSTOMER & Highlight_2021](TITLE, EMAIL, STATUS) VALUES('Cash', '" + email + "', 0)";
            cStr +=   "INSERT INTO[CUSTOMER & Highlight_2021](TITLE, EMAIL, STATUS) VALUES('Delivery', '" + email + "', 0)";
            cStr +=   "INSERT INTO[CUSTOMER & Highlight_2021](TITLE, EMAIL, STATUS) VALUES('Kid Friendly', '" + email + "', 0)";
            cStr +=  "INSERT INTO[CUSTOMER & Highlight_2021](TITLE, EMAIL, STATUS) VALUES('Outdoor Seating', '" + email + "', 0)";
            cStr +=  "INSERT INTO[CUSTOMER & Highlight_2021](TITLE, EMAIL, STATUS) VALUES('Private Dining Area Available', '" + email + "', 0)";
            /*String cStr = BuildInsertCommand(email); */     // helper method to build the insert string

            cmd = CreateCommand(cStr, con);             // create the command

            try
            {
                int numEffected = cmd.ExecuteNonQuery(); // execute the command
                return numEffected;
            }
            catch (Exception ex)
            {
                // write to log
                throw (ex);
            }

            finally
            {
                if (con != null)
                {
                    // close the db connection
                    con.Close();
                }
            }

        }


        public int InsertCust(Customer customer) // מכניס יוזר חדש עם מסעדות
        {
            SqlConnection con;
            SqlCommand cmd;

            try
            {
                con = connect("DBConnectionString"); // create the connection
            }
            catch (Exception ex)
            {
                // write to log
                throw (ex);
            }

            String cStr = BuildInsertCustommand(customer);      // helper method to build the insert string
            cStr += "INSERT INTO[CUSTOMER&Highlight_2021](TITLE, EMAIL, STATUS) VALUES('fULLBAR', '" + customer.Email + "', 0)";
            cStr += "INSERT INTO[CUSTOMER&Highlight_2021](TITLE, EMAIL, STATUS) VALUES('Air Conditioned', '" + customer.Email + "', 0)";
            cStr += "INSERT INTO[CUSTOMER&Highlight_2021](TITLE, EMAIL, STATUS) VALUES('Brunch', '" + customer.Email + "', 0)";
            cStr += "INSERT INTO[CUSTOMER&Highlight_2021](TITLE, EMAIL, STATUS) VALUES('Buffet', '" + customer.Email + "', 0)";
            cStr += "INSERT INTO[CUSTOMER&Highlight_2021](TITLE, EMAIL, STATUS) VALUES('Cafes', '" + customer.Email + "', 0)";
            cStr += "INSERT INTO[CUSTOMER&Highlight_2021](TITLE, EMAIL, STATUS) VALUES('Cash', '" + customer.Email + "', 0)";
            cStr += "INSERT INTO[CUSTOMER&Highlight_2021](TITLE, EMAIL, STATUS) VALUES('Delivery', '" + customer.Email + "', 0)";
            cStr += "INSERT INTO[CUSTOMER&Highlight_2021](TITLE, EMAIL, STATUS) VALUES('Kid Friendly', '" + customer.Email + "', 0)";
            cStr += "INSERT INTO[CUSTOMER&Highlight_2021](TITLE, EMAIL, STATUS) VALUES('Outdoor Seating', '" + customer.Email + "', 0)";
            cStr += "INSERT INTO[CUSTOMER&Highlight_2021](TITLE, EMAIL, STATUS) VALUES('Private Dining Area Available', '" + customer.Email + "', 0)";

            cmd = CreateCommand(cStr, con);             // create the command

            try
            {
                int numEffected = cmd.ExecuteNonQuery(); // execute the command
                return numEffected;
            }
            catch (Exception ex)
            {
                // write to log
                throw (ex);
            }

            finally
            {
                if (con != null)
                {
                    // close the db connection
                    con.Close();
                }
            }

        }
        private String BuildInsertCustommand(Customer costumer)
        {
            String command;

            StringBuilder sb = new StringBuilder();

            // use a string builder to create the dynamic string
            sb.AppendFormat("Values('{0}', '{1}', '{2}', '{3}', '{4}', '{5}','{6}')", costumer.Name, costumer.Fname, costumer.Email, costumer.Password, costumer.Phone, costumer.Myfile, costumer.Pricerange);
            String prefix = "INSERT INTO [CUSTOMER_2021] " + "(name, fname, email ,password ,phone, myfile, pricerange)";
            command = prefix + sb.ToString();

            return command;

        }

        private String BuildInsertCommand(Customer costumer)
        {
            String command;

            StringBuilder sb = new StringBuilder();

            // use a string builder to create the dynamic string
            sb.AppendFormat("Values('{0}', '{1}', '{2}', '{3}', '{4}', '{5}','{6}')", costumer.Name, costumer.Fname, costumer.Email, costumer.Password, costumer.Phone, costumer.Myfile, costumer.Pricerange);
            String prefix = "INSERT INTO [CUSTOMER_2021] " + "(name, fname, email ,password ,phone, myfile, pricerange)";
            command = prefix + sb.ToString();

            return command;

        }


        public List<Businesses> Show_r()
        {
            SqlConnection con = null;
            List<Businesses> businessessList = new List<Businesses>();

            try
            {
                con = connect("DBConnectionString"); // create a connection to the database using the connection String defined in the web config file

                String selectSTR = "SELECT * FROM Restaurants_2021  ";
                SqlCommand cmd = new SqlCommand(selectSTR, con);

                // get a reader
                SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection); // CommandBehavior.CloseConnection: the connection will be closed after reading has reached the end

                while (dr.Read())
                {   // Read till the end of the data into a row
                    Businesses b = new Businesses();

                    b.Name = (string)dr["name"];
                    b.Featured_image = (string)dr["FEATURED IMAGE"];
                    b.Id = Convert.ToInt32(dr["Id"]);
                    b.Price = Convert.ToSingle(dr["Price"]);
                    b.Rating = Convert.ToDouble(dr["Rating"]);
                    b.Address = (string)dr["ADDRESS"];
                    b.Phone = (string)dr["Phone"];



                    businessessList.Add(b);
                }

                return businessessList;
            }
            catch (Exception ex)
            {
                // write to log
                throw (ex);
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                }
            }
        }
        public List<Businesses> Show_r(string category, int price)
        {
            SqlConnection con = null;
            List<Businesses> businessessList = new List<Businesses>();

            try
            {
                String selectSTR;

                if (category == "null" && price == 999)
                {
                    selectSTR = "SELECT * FROM Restaurants_2021 order by RATING desc" ;
                }
                else if (category == "null")
                {
                    selectSTR = "SELECT * FROM Restaurants_2021  WHERE Restaurants_2021.PRICE =" + price+ "order by RATING desc";
                }
                else if (price == 999)
                {
                    selectSTR = "SELECT * FROM Restaurants_2021 INNER JOIN[Restaurant&Highlight_2021] on [Restaurant&Highlight_2021].[id.Restaurants] = Restaurants_2021.ID WHERE" + "[Restaurant&Highlight_2021].title = '" + category + "'" + "order by RATING desc";
                }
                else
                {
                    selectSTR = "SELECT * FROM Restaurants_2021 INNER JOIN[Restaurant&Highlight_2021] on[Restaurant&Highlight_2021].[id.Restaurants] = Restaurants_2021.ID WHERE Restaurants_2021.PRICE =" + price + " AND [Restaurant&Highlight_2021].title = '" + category + "'" + "order by RATING desc";
                }
                con = connect("DBConnectionString"); // create a connection to the database using the connection String defined in the web config file

                //String selectSTR = "SELECT * FROM Restaurants_2021 r  INNER [Highlights_to_Restaurants_2021] h on h.[ID_HIGHLIGHTS]=r.ID  ";
                SqlCommand cmd = new SqlCommand(selectSTR, con);

                // get a reader
                SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection); // CommandBehavior.CloseConnection: the connection will be closed after reading has reached the end

                while (dr.Read())
                {   // Read till the end of the data into a row
                    Businesses b = new Businesses();
                    b.Name = (string)dr["name"];
                    b.Featured_image = (string)dr["FEATURED IMAGE"];
                    b.Id = Convert.ToInt32(dr["Id"]);
                    b.Price = Convert.ToSingle(dr["Price"]);
                    b.Rating = Convert.ToDouble(dr["Rating"]);
                    b.Address = (string)dr["ADDRESS"];
                    b.Phone = (string)dr["Phone"];
                    b.Url = (string)dr["Url"];
                    businessessList.Add(b);


                }

                return businessessList;
            }
            catch (Exception ex)
            {
                // write to log
                throw (ex);
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                }
            }
        }

        public List<Businesses> Show_r_s(int status) // הצגת מסעדות ממומנות
        {
            SqlConnection con = null;
            List<Businesses> businessessList = new List<Businesses>();

            try
            {
                String selectSTR;
                
                selectSTR = "update campaign_2021 set status=0 where campaign_2021.remain<60 SELECT * FROM [campaign_2021] INNER JOIN[Restaurants_2021] on campaign_2021.[restid] = Restaurants_2021.ID where campaign_2021.STATUS=1";
                con = connect("DBConnectionString"); // create a connection to the database using the connection String defined in the web config file

                //String selectSTR = "SELECT * FROM Restaurants_2021 r  INNER [Highlights_to_Restaurants_2021] h on h.[ID_HIGHLIGHTS]=r.ID  ";
                SqlCommand cmd = new SqlCommand(selectSTR, con);

                // get a reader
                SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection); // CommandBehavior.CloseConnection: the connection will be closed after reading has reached the end

                while (dr.Read())
                {   // Read till the end of the data into a row
                    Businesses b = new Businesses();
                    b.Name = (string)dr["name"];
                    b.Featured_image = (string)dr["FEATURED IMAGE"];
                    b.Id = Convert.ToInt32(dr["Id"]);
                    b.Price = Convert.ToSingle(dr["Price"]);
                    b.Rating = Convert.ToDouble(dr["Rating"]);
                    b.Address = (string)dr["ADDRESS"];
                    b.Phone = (string)dr["Phone"];
                    b.Url = (string)dr["Url"];
                    businessessList.Add(b);


                }

                return businessessList;
            }
            catch (Exception ex)
            {
                // write to log
                throw (ex);
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                }
            }
        }





        public List<Businesses> Show_r_s_e(string email, int status)// מביאה מסעדות לפי הילייטס ועם תלוי בסטאטוס
        {
            SqlConnection con = null;
            List<Businesses> businessessList = new List<Businesses>();

            try
            {
                String selectSTR;
                if(status==1)
                //   selectSTR = "select distinct[Restaurants_2021].*  from CUSTOMER_2021,   [Restaurants_2021] INNER JOIN[Restaurant&Highlight_2021] on Restaurants_2021.ID=[Restaurant&Highlight_2021].[id.Restaurants] INNER JOIN  campaign_2021 ON campaign_2021.restid = Restaurants_2021.ID where title in (select title from[CUSTOMER&Highlight_2021] WHERE CUSTOMER_2021.email ='" +email+"'  and CUSTOMER_2021.pricerange= Restaurants_2021.PRICE and campaign_2021.STATUS = "+ status+ ") ORDER BY RATING DESC";
                // selectSTR = "select r. *  from CUSTOMER_2021  c , Restaurants_2021  r where c.[pricerange]=r.price and email = '" + email + "'";
                selectSTR = "select *   from [Restaurants_2021] INNER JOIN[Restaurant&Highlight_2021] on Restaurants_2021.ID=[Restaurant&Highlight_2021].[id.Restaurants] INNER JOIN  campaign_2021 ON campaign_2021.restid = Restaurants_2021.ID where title in (select title from CUSTOMER_2021 inner join[CUSTOMER&Highlight_2021] on CUSTOMER_2021.email =  [CUSTOMER&Highlight_2021].email WHERE[CUSTOMER&Highlight_2021].email = '"+email+"' and[CUSTOMER&Highlight_2021].status = 1 and CUSTOMER_2021.pricerange = Restaurants_2021.PRICE and campaign_2021.STATUS = "+status+") ORDER BY remain ASC";
                else
                    selectSTR = "select distinct[Restaurants_2021].*   from [Restaurants_2021] INNER JOIN[Restaurant&Highlight_2021] on Restaurants_2021.ID=[Restaurant&Highlight_2021].[id.Restaurants] INNER JOIN  campaign_2021 ON campaign_2021.restid = Restaurants_2021.ID where title in (select title from CUSTOMER_2021 inner join[CUSTOMER&Highlight_2021] on CUSTOMER_2021.email =  [CUSTOMER&Highlight_2021].email WHERE[CUSTOMER&Highlight_2021].email = '" + email + "' and[CUSTOMER&Highlight_2021].status = 1 and CUSTOMER_2021.pricerange = Restaurants_2021.PRICE and campaign_2021.STATUS = " + status + ") ORDER BY RATING DESC";

                con = connect("DBConnectionString"); // create a connection to the database using the connection String defined in the web config file

                //String selectSTR = "SELECT * FROM Restaurants_2021 r  INNER [Highlights_to_Restaurants_2021] h on h.[ID_HIGHLIGHTS]=r.ID  ";
                SqlCommand cmd = new SqlCommand(selectSTR, con);

                // get a reader
                SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection); // CommandBehavior.CloseConnection: the connection will be closed after reading has reached the end

                while (dr.Read())
                {   // Read till the end of the data into a row
                    Businesses b = new Businesses();
                    b.Name = (string)dr["name"];
                    b.Featured_image = (string)dr["FEATURED IMAGE"];
                    b.Id = Convert.ToInt32(dr["Id"]);
                    b.Price = Convert.ToSingle(dr["Price"]);
                    b.Rating = Convert.ToDouble(dr["Rating"]);
                    b.Address = (string)dr["ADDRESS"];
                    b.Phone = (string)dr["Phone"];
                    b.Url = (string)dr["Url"];
                    businessessList.Add(b);


                }

                return businessessList;
            }
            catch (Exception ex)
            {
                // write to log
                throw (ex);
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                }
            }
        }
        
        public List<Customer> Show()
        {
            SqlConnection con = null;
            List<Customer> costumersList = new List<Customer>();

            try
            {
                con = connect("DBConnectionString"); // create a connection to the database using the connection String defined in the web config file

                String selectSTR = "SELECT * FROM [CUSTOMER_2021] ";
                SqlCommand cmd = new SqlCommand(selectSTR, con);

                // get a reader
                SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection); // CommandBehavior.CloseConnection: the connection will be closed after reading has reached the end

                while (dr.Read())
                {   // Read till the end of the data into a row
                    Customer c = new Customer();

                    c.Name = (string)dr["name"];
                    c.Fname = (string)dr["fname"];
                    c.Email = (string)dr["email"];
                    c.Password = (string)dr["password"];
                    c.Phone = (string)dr["phone"];
                    c.Myfile = (string)dr["myfile"];
                    c.Pricerange = Convert.ToInt32(dr["pricerange"]);

                    costumersList.Add(c);
                }

                return costumersList;
            }
            catch (Exception ex)
            {
                // write to log
                throw (ex);
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                }
            }
        }

        public List<Campaign> ShowC()
        {
            SqlConnection con = null;
            List<Campaign> campList = new List<Campaign>();

            try
            {
                con = connect("DBConnectionString"); // create a connection to the database using the connection String defined in the web config file

                String selectSTR = "select * from [campaign_2021]";
                SqlCommand cmd = new SqlCommand(selectSTR, con);

                // get a reader
                SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection); // CommandBehavior.CloseConnection: the connection will be closed after reading has reached the end

                while (dr.Read())
                {   // Read till the end of the data into a row
                    Campaign campaign = new Campaign();
                    campaign.Status = Convert.ToInt32(dr["STATUS"]);
                    campaign.Campid = Convert.ToInt32(dr["restid"]);
                    campaign.Budget = Convert.ToInt32(dr["BUDGET"]);
                    campaign.Remain = Convert.ToInt32(dr["REMAIN"]);
                    campaign.Clicks = Convert.ToInt32(dr["CLICKS"]);
                    campaign.Views = Convert.ToInt32(dr["VIEWS"]);


                    campList.Add(campaign);
                }







                return campList;
            }
            catch (Exception ex)
            {
                // write to log
                throw (ex);
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                }
            }
        }
        public List<Campaign> ShowC(int status)
        {
            SqlConnection con = null;
            List<Campaign> campList = new List<Campaign>();

            try
            {
                con = connect("DBConnectionString"); // create a connection to the database using the connection String defined in the web config file

                String selectSTR = "SELECT * FROM [campaign_2021] ";
                SqlCommand cmd = new SqlCommand(selectSTR, con);

                // get a reader
                SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection); // CommandBehavior.CloseConnection: the connection will be closed after reading has reached the end

                while (dr.Read())
                {   // Read till the end of the data into a row
                    if (status == Convert.ToInt32(dr["status"]))
                    {
                        Campaign c = new Campaign();
                        c.Campid = Convert.ToInt32(dr["campid"]);
                        c.Budget = Convert.ToInt32(dr["budget"]);
                        c.Remain = Convert.ToInt32(dr["remain"]);
                        c.Clicks = Convert.ToInt32(dr["clicks"]);
                        c.Views = Convert.ToInt32(dr["views"]);
                        c.Status = Convert.ToInt32(dr["status"]);

                        campList.Add(c);
                    }
                }

                return campList;
            }
            catch (Exception ex)
            {
                // write to log
                throw (ex);
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                }
            }
        }





        public List<Campaign> Show_campaigns()
        {
            SqlConnection con = null;
            List<Campaign> campList = new List<Campaign>();

            try
            {
                con = connect("DBConnectionString"); // create a connection to the database using the connection String defined in the web config file

                String selectSTR = "SELECT * FROM [campaign_2021] ";
                SqlCommand cmd = new SqlCommand(selectSTR, con);

                // get a reader
                SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection); // CommandBehavior.CloseConnection: the connection will be closed after reading has reached the end

                while (dr.Read())
                {   // Read till the end of the data into a row

                    Campaign c = new Campaign();
                    c.Campid = Convert.ToInt32(dr["campid"]);
                    c.Budget = Convert.ToInt32(dr["budget"]);
                    c.Remain = Convert.ToInt32(dr["remain"]);
                    c.Clicks = Convert.ToInt32(dr["clicks"]);
                    c.Views = Convert.ToInt32(dr["views"]);
                    c.Status = Convert.ToInt32(dr["status"]);

                    campList.Add(c);

                }

                return campList;
            }
            catch (Exception ex)
            {
                // write to log
                throw (ex);
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                }
            }
        }




        private SqlCommand CreateCommand(String CommandSTR, SqlConnection con)
        {

            SqlCommand cmd = new SqlCommand(); // create the command object

            cmd.Connection = con;              // assign the connection to the command object

            cmd.CommandText = CommandSTR;      // can be Select, Insert, Update, Delete 

            cmd.CommandTimeout = 60;           // Time to wait for the execution' The default is 30 seconds

            cmd.CommandType = System.Data.CommandType.Text; // the type of the command, can also be stored procedure

            return cmd;
        }

        private int Insert()
        {
            return 1;
        }
        public bool show_u(string email, string password)
        {
            SqlConnection con = null;


            try
            {
                con = connect("DBConnectionString"); // create a connection to the database using the connection String defined in the web config file

                String selectSTR = "SELECT * FROM CUSTOMER_2021 where password ='" + password + "' and email='" + email + "'";
                SqlCommand cmd = new SqlCommand(selectSTR, con);

                // get a reader
                SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection); // CommandBehavior.CloseConnection: the connection will be closed after reading has reached the end

                while (dr.Read())
                {   // Read till the end of the data into a row

                    return true;
                }
                return false;


            }
            catch (Exception ex)
            {
                // write to log
                throw (ex);
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                }
            }
        }

        public bool updatecamp(int id, int budget)
        {
            SqlConnection con = null;


            try
            {
                String selectSTR;


                {
                    selectSTR = "update[campaign_2021] SET budget = [campaign_2021].budget + " + budget + ", remain = [campaign_2021].remain + " + budget*100 + ", status=1 WHERE restid = " + id;
                }
                con = connect("DBConnectionString"); // create a connection to the database using the connection String defined in the web config file

                //String selectSTR = "SELECT * FROM Restaurants_2021 r  INNER [Highlights_to_Restaurants_2021] h on h.[ID_HIGHLIGHTS]=r.ID  ";
                SqlCommand cmd = new SqlCommand(selectSTR, con);

                // get a reader
                SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection); // CommandBehavior.CloseConnection: the connection will be closed after reading has reached the end
                                                                                       // Campaign campaign = new Campaign(id,budget);

                return true;
            }
            catch (Exception ex)
            {
                // write to log
                throw (ex);
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                }
            }
        }


        public int put_c(string title, string email, int status)
        {
            SqlConnection con = null;


            try
            {
                String selectSTR;

               selectSTR = "update[CUSTOMER&Highlight_2021] SET status = " + status + " WHERE email = '" + email+ "' and [title]='"+ title+"'";
               
                con = connect("DBConnectionString"); // create a connection to the database using the connection String defined in the web config file

                //String selectSTR = "SELECT * FROM Restaurants_2021 r  INNER [Highlights_to_Restaurants_2021] h on h.[ID_HIGHLIGHTS]=r.ID  ";
                SqlCommand cmd = new SqlCommand(selectSTR, con);

                // get a reader
                SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection); // CommandBehavior.CloseConnection: the connection will be closed after reading has reached the end
              
              
                    return 1;
            
              
            }
            catch (Exception ex)
            {
                // write to log
                throw (ex);
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                }
            }
        }




    }
}