using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Configuration;

namespace APP1.Models.DAL
{
    public class DB_Services
    {


        public List<File> show_UF()
        {
           List<File> uf1 = new List<File>();
            SqlConnection con = null;

            try
            {
                con = connect("DBConnectionString"); // create a connection to the database using the connection String defined in the web config file

                String selectSTR = "select *,uf.Email  as 'EmailFile' ,u.email as 'UEmail' from users u left join UsersFile uf on u.email= uf.Email  where u.Active is null or u.Active=1 order by FileName";
                SqlCommand cmd = new SqlCommand(selectSTR, con);

                // get a reader
                SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection); // CommandBehavior.CloseConnection: the connection will be closed after reading has reached the end

                while (dr.Read())
                {
                    File f = new File();
                    if (dr["EmailFile"].GetType() != typeof(DBNull))
                    {
                    
                        f.Email = (string)dr["Email"];
                        f.Full_Name = (string)dr["LastName"] + ' ' + (string)dr["FirstName"];
                        if (dr["Filetype"].GetType() != typeof(DBNull))
                            f.Filetype = (string)dr["Filetype"];

                        if (dr["Remark"].GetType() != typeof(DBNull))
                            f.Remark = (string)dr["Remark"];

                        if (dr["FileName"].GetType() != typeof(DBNull))
                            f.FileName = (string)dr["FileName"];

                        if (dr["Score"].GetType() != typeof(DBNull))
                            f.Score = Convert.ToInt32(dr["Score"]);
                        if (dr["id"].GetType() != typeof(DBNull))
                            f.Id = Convert.ToInt32(dr["id"]);

                        f.Isnull = 1;
                    }
                    else
                    {
                        f.Full_Name = (string)dr["LastName"] + ' ' + (string)dr["FirstName"];
                        f.Email = (string)dr["UEmail"];
                        f.Isnull = 0;

                    }

                    uf1.Add(f);
                }
                return uf1;

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

        public int Insert_New_UserData(UserData u)
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

            String cStr = BuildInsertCommandUserData(u);      // helper method to build the insert string

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
                if (con != null) //אם אימייל כבר קיים שגיאה 500
                {
                    // close the db connection
                    con.Close();
                }
            }

        }


        // ליצור טבלה
        private String BuildInsertCommandUserData(UserData u)
        {





            String command;

            StringBuilder sb = new StringBuilder();
            string EXISTS = " IF EXISTS(SELECT * FROM[UserData] WHERE Email = '" + u.Email + "') ";

            // use a string builder to create the dynamic string
            sb.AppendFormat("Values('{0}','{1}', '{2}', '{3}', '{4}', '{5}', '{6}','{7}','{8}','{9}')", u.Email, u.National, u.Captain, u.League, u.Champions,u.Cups, u.Position, u.Tofel, u.Sat, u.Gpa);
            String prefix = "insert INTO[UserData] (Email,[National], Captain, League, Champions,[Cups], Position, Tofel, Sat, Gpa )";
            String delete = " DELETE FROM [UserData] WHERE Email='" + u.Email + " '";
            command = EXISTS +delete  + prefix + sb.ToString();
       return command ;

        }



        //======TODO=====//

        public List<ToDoList> show_ToDoList(string email)
        {
            List<ToDoList> list_of_todo = new List<ToDoList>();
            SqlConnection con = null;

            try
            {
                con = connect("DBConnectionString"); // create a connection to the database using the connection String defined in the web config file

                String selectSTR = "select top 5 * from UsersToDoList where email='" + email+ "'" ;
                SqlCommand cmd = new SqlCommand(selectSTR, con);

                // get a reader
                SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection); // CommandBehavior.CloseConnection: the connection will be closed after reading has reached the end

                while (dr.Read())
                {

                    ToDoList t = new ToDoList();
                  
                    t.Email = (string)dr["Email"];
                    t.Task = (string)dr["Task"];
                    t.DueDate = (DateTime)dr["Duedate"];
                    t.Status = (string)dr["Status"];

                   
                    list_of_todo.Add(t);
                }
                ToDoList td = new ToDoList();
                return list_of_todo;

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




        public int Insert_ToDoList(ToDoList t)
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

            String cStr = BuildInsert_ToDoList(t);      // helper method to build the insert string

            cmd = CreateCommand(cStr, con);             // create the command

            try
            {
                int numEffected = cmd.ExecuteNonQuery(); // execute the command

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

            return 1;

        }

        private String BuildInsert_ToDoList(ToDoList t)
        {
            String command;

            StringBuilder sb = new StringBuilder();
            // use a string builder to create the dynamic string
          
                sb.AppendFormat("Values('{0}', '{1}', '{2}', '{3}')", t.Email, t.Task, t.DueDate,"בתהליך");
           
            String prefix = "INSERT INTO [UsersToDoList] " + "(Email,Task, DueDate,Status)";
            command = prefix + sb.ToString();
            return command;

        }

        //===============================University========================
        public void Insert_University_Email(List<University> IUE)
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

            String cStr = BuildInsert_University_Email(IUE);      // helper method to build the insert string

            cmd = CreateCommand(cStr, con);             // create the command

            try
            {
                int numEffected = cmd.ExecuteNonQuery(); // execute the command

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

        private String BuildInsert_University_Email(List<University> IUE)
        {
            String command;

            StringBuilder sb = new StringBuilder();
            // use a string builder to create the dynamic string
            for (int i = 0; i < IUE.Count; i++)
            {
                sb.AppendFormat("Values('{0}', '{1}', '{2}')", IUE[i].Email, IUE[i].UniversityName, IUE[i].Id);
            }
            String prefix = "INSERT INTO [UsersUniversity] " + "(Email,UniversityName, Id)";
            String delete = "DELETE FROM [UsersUniversity] WHERE Email=" + IUE[0].Email + " ";
            command = delete + " " + prefix + sb.ToString();
            return command;

        }
        public List<University> getWish(string email)
        {
            List<University> wishlist = new List<University>();
            SqlConnection con = null;

            try
            {
                con = connect("DBConnectionString"); // create a connection to the database using the connection String defined in the web config file

                String selectSTR = "select * from UsersUniversity where email='" + email + "'";
                SqlCommand cmd = new SqlCommand(selectSTR, con);

                // get a reader
                SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection); // CommandBehavior.CloseConnection: the connection will be closed after reading has reached the end

                while (dr.Read())
                {
                    University ul = new University();
                    ul.UniversityName = (string)dr["UniversityName"];
                    ul.Id = Convert.ToInt32(dr["id"]);
                    wishlist.Add(ul);
                }
                University ule = new University();
                return wishlist;

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

        public int SaveWishList(List<University> u)
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

            String cStr = BuildInsertWishList(u);      // helper method to build the insert string

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

        private String BuildInsertWishList(List<University> u)
        {
            String command;
            string tmp;
            string sbud = "";
            StringBuilder append_UsersDistrict = new StringBuilder();
            // use a string builder to create the dynamic string
            for (int i = 0; i < u.Count; i++)
            {
                if (i == 0) // הראשון
                    sbud = "Values('" + u[i].Email + "', '" + u[i].UniversityName + "', '" + u[i].Id + "')";
                else
                {
                    tmp = ",('" + u[i].Email + "', '" + u[i].UniversityName + "', '" + u[i].Id + "')";
                    sbud = append(sbud, tmp);

                }
            }



            String prefix_UsersDistrict = "INSERT INTO [UsersUniversity] " + "(Email,UniversityName, Id)";


            String delete = "DELETE FROM [UsersUniversity] WHERE Email='" + u[0].Email + "' ";
            delete = " IF EXISTS (SELECT * FROM [UsersUniversity] WHERE Email = '" + u[0].Email + "' ) DELETE FROM [UsersUniversity] WHERE Email = '" + u[0].Email + "'";
            command = delete + prefix_UsersDistrict + sbud;

            return command;
        }



        //======================================================================
        //===============================District/region========================
        //======================================================================
        public int insert_arr_region(List<UsersDistrict> ud)
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

            String cStr = BuildInsertListUsersDistrict(ud);      // helper method to build the insert string

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
        private String BuildInsertListUsersDistrict(List<UsersDistrict> ud)
        {
            String command;
            string tmp;
            string sbud = "";
            StringBuilder append_UsersDistrict = new StringBuilder();
            // use a string builder to create the dynamic string
            for (int i = 0; i < ud.Count; i++)
            {
                if (i == 0)
                    sbud = "Values('" + ud[i].Email + "', '" + ud[i].District + "', '" + ud[i].Id + "')";
                else
                {
                    tmp = ",('" + ud[i].Email + "', '" + ud[i].District + "', '" + ud[i].Id + "')";
                    sbud = append(sbud, tmp);

                }
            }



            String prefix_UsersDistrict = "INSERT INTO [UsersDistrict] " + "(Email,District, Id)";


            String delete = "DELETE FROM [UsersDistrict] WHERE Email='" + ud[0].Email + "' ";
            delete = " IF EXISTS (SELECT * FROM [UsersDistrict] WHERE Email = '" + ud[0].Email + "' ) DELETE FROM [UsersDistrict] WHERE Email = '" + ud[0].Email + "'";
            command = delete + prefix_UsersDistrict + sbud;

            return command;

        }
        public List<UsersDistrict> get_User_district(string email)
        {
            List<UsersDistrict> list_of_user_district = new List<UsersDistrict>();
            SqlConnection con = null;

            try
            {
                con = connect("DBConnectionString"); // create a connection to the database using the connection String defined in the web config file

                String selectSTR = "SELECT * FROM UsersDistrict where UsersDistrict.Email='" + email + "'";
                SqlCommand cmd = new SqlCommand(selectSTR, con);

                // get a reader
                SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection); // CommandBehavior.CloseConnection: the connection will be closed after reading has reached the end

                while (dr.Read())
                {
                    UsersDistrict ud = new UsersDistrict();

                    ud.District = (string)dr["District"];
                    ud.Email = (string)dr["Email"];
                    ud.Id = Convert.ToInt32(dr["Id"]);



                    list_of_user_district.Add(ud);
                }
                return list_of_user_district;

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

        //======================================================================
        //===============================Locale========================
        //======================================================================
        public int Insert_arr_Locale(List<UsersLocale> us)
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

            String cStr = BuildInsertListUsersLocale(us);      // helper method to build the insert string

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
        private String BuildInsertListUsersLocale(List<UsersLocale> us)
        {
            String command;
            string tmp;
            string sbud = "";
            StringBuilder append_UsersDistrict = new StringBuilder();
            // use a string builder to create the dynamic string
            for (int i = 0; i < us.Count; i++)
            {
                if (i == 0)
                    sbud = "Values('" + us[i].Email + "', '" + us[i].Locale + "', '" + us[i].Id + "')";
                else
                {
                    tmp = ",('" + us[i].Email + "', '" + us[i].Locale + "', '" + us[i].Id + "')";
                    sbud = append(sbud, tmp);
                }
            }
            String prefix_UsersDistrict = "INSERT INTO [UsersLocale] " + "(Email,Locale, Id)";
            String delete = "DELETE FROM [UsersLocale] WHERE Email='" + us[0].Email + "' ";
            delete = " IF EXISTS (SELECT * FROM [UsersLocale] WHERE Email = '" + us[0].Email + "' ) DELETE FROM [UsersLocale] WHERE Email = '" + us[0].Email + "'";
            command = delete + prefix_UsersDistrict + sbud;
            return command;
        }
        public List<UsersLocale> get_User_Locale(string email)
        {
            List<UsersLocale> list_of_user_locale = new List<UsersLocale>();
            SqlConnection con = null;

            try
            {
                con = connect("DBConnectionString"); // create a connection to the database using the connection String defined in the web config file

                String selectSTR = "SELECT * FROM UsersLocale where UsersLocale.Email='" + email + "'";
                SqlCommand cmd = new SqlCommand(selectSTR, con);

                // get a reader
                SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection); // CommandBehavior.CloseConnection: the connection will be closed after reading has reached the end

                while (dr.Read())
                {
                    UsersLocale ul = new UsersLocale();

                    ul.Locale = (string)dr["Locale"];
                    ul.Email = (string)dr["Email"];
                    ul.Id = (string)dr["Id"];



                    list_of_user_locale.Add(ul);
                }
                return list_of_user_locale;

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
        //======================================================================
        //===============================State========================
        //======================================================================

        public List<University> getR()
        {
            List<University> list_of_div_school = new List<University>();
            SqlConnection con = null;

            try
            {
                con = connect("DBConnectionString"); // create a connection to the database using the connection String defined in the web config file

                String selectSTR = "SELECT * FROM [NCAAUniversities]";
                SqlCommand cmd = new SqlCommand(selectSTR, con);

                // get a reader
                SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection); // CommandBehavior.CloseConnection: the connection will be closed after reading has reached the end

                while (dr.Read())
                {
                    University Rank = new University();

                    Rank.UniversityLevel = (string)dr["UniversityLevel"];

                    list_of_div_school.Add(Rank);
                }
                return list_of_div_school;

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
        public List<University> getdiv()
        {
            List<University> list_of_div_school = new List<University>();
            SqlConnection con = null;

            try
            {
                con = connect("DBConnectionString"); // create a connection to the database using the connection String defined in the web config file

                String selectSTR = "SELECT * FROM [NCAAUniversities]";
                SqlCommand cmd = new SqlCommand(selectSTR, con);

                // get a reader
                SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection); // CommandBehavior.CloseConnection: the connection will be closed after reading has reached the end

                while (dr.Read())
                {
                    University div = new University();

                   div.UniversityLevel = (string)dr["UniversityLevel"];

                    list_of_div_school.Add(div);
                }
                return list_of_div_school;

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


        // getdiv()"SELECT * FROM [NCAAUniversities]";

        public List<UsersStates> get_User_States(string email)
        {
            List<UsersStates> list_of_user_States = new List<UsersStates>();
            SqlConnection con = null;

            try
            {
                con = connect("DBConnectionString"); // create a connection to the database using the connection String defined in the web config file

                String selectSTR = "SELECT * FROM UsersStates where UsersStates.Email='" + email + "'";
                SqlCommand cmd = new SqlCommand(selectSTR, con);

                // get a reader
                SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection); // CommandBehavior.CloseConnection: the connection will be closed after reading has reached the end

                while (dr.Read())
                {
                    UsersStates us = new UsersStates();

                    us.States = (string)dr["States"];
                    us.Email = (string)dr["Email"];
                    us.Id = Convert.ToInt32(dr["Id"]);



                    list_of_user_States.Add(us);
                }
                return list_of_user_States;

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
        public int Insert_arr_states(List<UsersStates> us)
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

            String cStr = BuildInsertListUsersStates(us);      // helper method to build the insert string

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
        private String BuildInsertListUsersStates(List<UsersStates> us)
        {
            String command;
            string tmp;
            string sbud = "";
            StringBuilder append_UsersDistrict = new StringBuilder();
            // use a string builder to create the dynamic string
            for (int i = 0; i < us.Count; i++)
            {
                if (i == 0)
                    sbud = "Values('" + us[i].Email + "', '" + us[i].States + "', '" + us[i].Id + "')";
                else
                {
                    tmp = ",('" + us[i].Email + "', '" + us[i].States + "', '" + us[i].Id + "')";
                    sbud = append(sbud, tmp);

                }
            }



            String prefix_UsersDistrict = "INSERT INTO [UsersStates] " + "(Email,States, Id)";


            String delete = "DELETE FROM [UsersStates] WHERE Email='" + us[0].Email + "' ";
            delete = " IF EXISTS (SELECT * FROM [UsersStates] WHERE Email = '" + us[0].Email + "' ) DELETE FROM [UsersStates] WHERE Email = '" + us[0].Email + "'";
            command = delete + prefix_UsersDistrict + sbud;

            return command;

        }
        //======================================================================
        //===============================Favorites========================
        //======================================================================
        public int Insert_Favorites(Favorites f)
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

            String cStr = BuildInsertFavorites(f);      // helper method to build the insert string

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

        private String BuildInsertFavorites(Favorites f)
        {
            String command;

            StringBuilder sb = new StringBuilder();

            // use a string builder to create the dynamic string
            sb.AppendFormat("Values('{0}', '{1}', '{2}', '{3}', '{4}', '{5}')", f.Email, f.UniversitySize, f.UniversityLevel, f.UniversityType, f.PriceMAX, f.Sat);
            String prefix = "INSERT INTO [UsersFavorites] " + "(Email,UniversitySize, UniversityLevel ,UniversityType ,PriceMAX, SAT)";

            prefix = "IF EXISTS(select* from UsersFavorites where email= '" + f.Email + "') begin UPDATE UsersFavorites SET UniversitySize = " + f.UniversitySize + " ,UniversityLevel ='" + f.UniversityLevel + "' ,UniversityType = '" + f.UniversityType + "',PriceMAX =" + f.PriceMAX + ",SAT = " + f.Sat + " WHERE Email = '" + f.Email + "' END else begin " + prefix ; 


            command = prefix + sb.ToString() + "end";

            return command;

        }
        public int getDivision(int d)
        {

            SqlConnection con = null;

            try
            {
                con = connect("DBConnectionString"); // create a connection to the database using the connection String defined in the web config file

                String selectSTR = "SELECT * FROM [NCAAUniversities] where Division='" + d;
                SqlCommand cmd = new SqlCommand(selectSTR, con);

                // get a reader
                SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection); // CommandBehavior.CloseConnection: the connection will be closed after reading has reached the end

                while (dr.Read())
                {   // Read till the end of the data into a row
                    return Convert.ToInt32(dr["TypeUsers"]);
                }
                return -1;

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

        public Favorites Get_Favorites_By_email(string email)
        {
            Favorites uf = new Favorites();
            SqlConnection con = null;

            try
            {
                con = connect("DBConnectionString"); // create a connection to the database using the connection String defined in the web config file

                String selectSTR = "select * from UsersFavorites where email='" + email + "'";
                SqlCommand cmd = new SqlCommand(selectSTR, con);

                // get a reader
                SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection); // CommandBehavior.CloseConnection: the connection will be closed after reading has reached the end

                while (dr.Read())
                {
                    uf.Email = (string)dr["Email"];
                    uf.UniversitySize = Convert.ToInt32(dr["UniversitySize"]);
                    uf.UniversityLevel = (string)dr["UniversityLevel"];
                    uf.PriceMAX = Convert.ToInt32(dr["PriceMAX"]);
                    uf.UniversityType = (string)dr["UniversityType"];
                    uf.Sat = Convert.ToInt32(dr["Sat"]);
                }
                return uf;

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




        //======================================================================
        //===============================ALGO========================
        //======================================================================


        public List<UserData> Show_Users_Data(string email)
        {
            List<UserData> Users_data_list = new List<UserData>();
            SqlConnection con = null;

            try
            {
                con = connect("DBConnectionString"); // create a connection to the database using the connection String defined in the web config file

                String selectSTR = "select * from UserData where email='"+ email+ "'";
                SqlCommand cmd = new SqlCommand(selectSTR, con);

                // get a reader
                SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection); // CommandBehavior.CloseConnection: the connection will be closed after reading has reached the end

                while (dr.Read())
                {

                    UserData ul = new UserData();
            
                    ul.National = Convert.ToInt32(dr["National"]);
                    ul.Captain = Convert.ToInt32(dr["Captain"]);
                    ul.League = Convert.ToInt32(dr["League"]);
                    ul.Champions = Convert.ToInt32(dr["Champions"]);
                    ul.Cups = Convert.ToInt32(dr["Cups"]);
                    ul.Gpa = Convert.ToInt32(dr["Gpa"]);
                    ul.Tofel = Convert.ToInt32(dr["Tofel"]);
                    ul.Sat = Convert.ToInt32(dr["Sat"]);
                    ul.Position =(string)dr["Position"];


                    Users_data_list.Add(ul);
                }
                Users ule = new Users();
                return Users_data_list;

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









        //======================================================================
        //===============================Users========================
        //======================================================================

        public List<Users> Show_Users()
        {
            List<Users> list_of_user= new List<Users>();
            SqlConnection con = null;

            try
            {
                con = connect("DBConnectionString"); // create a connection to the database using the connection String defined in the web config file

                String selectSTR = "SELECT * FROM Users left JOIN UsersStatus ON Users.Email = UsersStatus.Email ";
                SqlCommand cmd = new SqlCommand(selectSTR, con);

                // get a reader
                SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection); // CommandBehavior.CloseConnection: the connection will be closed after reading has reached the end

                while (dr.Read())
                {
                  
                    Users ul = new Users();
                    ul.FirstName = (string)dr["FirstName"];
                    ul.Email = (string)dr["Email"];
                    ul.TypeUsers = Convert.ToInt32(dr["TypeUsers"]);
                    ul.Sex = (string)dr["sex"];
                    ul.LastName = (string)dr["LastName"];
                    ul.Phone = (string)dr["Phone"];
                    ul.Position = (string)dr["Position"];
                    ul.BirthDay = (DateTime)dr["birthDay"];
                    ul.Register = (DateTime)dr["Register"];

                    if (dr["EstimatedYear"].GetType() != typeof(DBNull))
                    ul.EstimatedYear = (DateTime)dr["EstimatedYear"];

                    if (dr["Active"].GetType() != typeof(DBNull))
                        ul.Active = Convert.ToInt32(dr["Active"]);


                    if (dr["Address"].GetType() != typeof(DBNull))
                    ul.Address = (string)dr["Address"];

                    if (dr["Password"].GetType() != typeof(DBNull))
                      ul.Password = (string)dr["Password"];

                    if (dr["Status"].GetType() != typeof(DBNull))
                     ul.Status = (string)dr["Status"];


                    if (dr["Height"].GetType() != typeof(DBNull))
                        ul.Height = (float)(double)dr["Height"];


                    if (dr["Active"].GetType() == typeof(DBNull)|| Convert.ToInt32(dr["Active"]) !=-1)
                        ul.Active = 1;
                    else
                        ul.Active = -1;


                    list_of_user.Add(ul);
                }
                Users ule = new Users();
                return list_of_user;

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
        public int Login_User(string email, string password)
        {

            SqlConnection con = null;

            try
            {
                con = connect("DBConnectionString"); // create a connection to the database using the connection String defined in the web config file

                String selectSTR = "SELECT * FROM Users where Users.Email='" + email + " ' and Users.password='" + password + "'";
                SqlCommand cmd = new SqlCommand(selectSTR, con);

                // get a reader
                SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection); // CommandBehavior.CloseConnection: the connection will be closed after reading has reached the end

                while (dr.Read())
                {   // Read till the end of the data into a row
                    return Convert.ToInt32(dr["TypeUsers"]);
                }
                return -1;

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
        
        private String BuildUpdateCommandUsers(Users u)
        {
            String command;

            StringBuilder sb = new StringBuilder();
            string s = " IF EXISTS(SELECT * FROM UsersStatus WHERE Email = '" + u.Email + "') BEGIN  DELETE FROM UsersStatus WHERE Email = '" + u.Email + "'end";
            string status = " INSERT INTO UsersStatus (Email, Status)Values('" + u.Email + "', '"+u.Status+"')";
            // use a string builder to create the dynamic string
            String prefix = " UPDATE Users SET BirthDay = '" + u.BirthDay.ToString("MM/dd/yyyy") + "',FirstName = '" + u.FirstName + "',LastName = '" + u.LastName + "',Phone = '" + u.Phone+"', Address = '"+u.Address+"',Password = '"+u.Password+"', Position= '"+u.Position+"',EstimatedYear = '"+u.EstimatedYear.ToString("MM/dd/yyyy") + "' WHERE Email='"+ u.Email+"'" ;
            command = prefix ;

            return s+command + status;
        }
        private String BuildInsertCommandUsers(Users u)
        {
            String command;

            StringBuilder sb = new StringBuilder();
            string status = "INSERT INTO UsersStatus (Email, Status)Values('" + u.Email + "', 'candidate')";
            // use a string builder to create the dynamic string
            sb.AppendFormat("Values('{0}','{1}', '{2}', '{3}', '{4}', '{5}', '{6}','{7}','{8}','{9}',{10},'{11}','{12}','{13}')", u.Email, u.BirthDay.ToString("MM/dd/yyyy"), u.Sex, u.Phone, u.Password, u.LastName, u.FirstName, u.TypeUsers, u.Position, DateTime.Now.ToString("MM/dd/yyyy"), u.Height, u.Address, u.EstimatedYear.ToString("MM/dd/yyyy"), u.Active);
            String prefix = "INSERT INTO Users " + "( Email , BirthDay , Sex ,Phone ,Password ,LastName ,FirstName, TypeUsers,Position,Register,Height,Address, EstimatedYear, Active) ";
            command = prefix + sb.ToString();

            return command + status;
        }

        public int update_New_Users(Users u)
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

            String cStr = BuildUpdateCommandUsers(u);      // helper method to build the insert string

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
                if (con != null) //אם אימייל כבר קיים שגיאה 500
                {
                    // close the db connection
                    con.Close();
                }
            }

        }
        public int Insert_New_Users(Users u)
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

            String cStr = BuildInsertCommandUsers(u);      // helper method to build the insert string

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
                if (con != null) //אם אימייל כבר קיים שגיאה 500
                {
                    // close the db connection
                    con.Close();
                }
            }

        }
        public String BuilDeleteCommandUsers(Users u)
        {
            string active;
            if (u.Active == -1)
            {
                active = "1";
            }
            else
            {
                active = "-1";
            }
            String prefix = " UPDATE Users SET Active = "+active+" WHERE Email='" + u.Email + "'";

            return prefix;
        }
        public int Delete_Users(Users u)
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

            String cStr = BuilDeleteCommandUsers(u);      // helper method to build the insert string

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
                if (con != null) //אם אימייל כבר קיים שגיאה 500
                {
                    // close the db connection
                    con.Close();
                }
            }

        }




        //======================================================================
        //===============================function========================
        //======================================================================

        public SqlConnection connect(String conString)
        {

            // read the connection string from the configuration file
            string cStr = WebConfigurationManager.ConnectionStrings[conString].ConnectionString;
            SqlConnection con = new SqlConnection(cStr);
            con.Open();
            return con;
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
        private String append(string str, string app)
        {
            string append;

            append = str + app;
            return append;
        }

    }
}