using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using VrachMedcentr;

namespace kepkaSQL
{
    class connect
    {
        string server;
        string database;
        string UserID;
        string Password;
        private string stat;
        MySqlDataAdapter adapter;
        public connect()
        {
            server = "192.168.1.114";
            database = "medcentr";
            UserID = "monteshot";
            Password = "a12345";
        }
        public connect(string Server, string Database, string userid, string pass)
        {
            server = Server;
            database = Database;
            UserID = userid;
            Password = pass;
        }
        private DataTable dtFbase;
        public string selectSTR(string field, string value)
        {

            DataRow[] DR;
            string result = "";
            DR = dtFbase.Select(field + "='" + value + "'");
            for (int i = 0; i <= DR[0].ItemArray.Length - 1; i++)
            {
                result += DR[0].ItemArray[i].ToString() + "\n";
            }
            return result;
        }
        //sadasd
        //public string selectARR(string field, string value)
        //{
        //    // result = null;
        //    var DR = dtFbase.Select(field + "='" + value + "'");
        //    //for (int i = 0; i <= DR[0].ItemArray.Length - 1; i++)
        //    //{
        //    //    result = DR[0].ToString();
        //    //}
        //    return DR[0].ItemArray.ToString();

        //}
        string result;
        public string selectONE(string field, string value, int arr)
        {
            var DR = dtFbase.Select(field + "='" + value + "'");
            result = DR[0].ItemArray[arr].ToString();
            return result;
        }

        public string Server;


        public DataTable query(string Statement)
        {
            stat = Statement;
            MySqlConnectionStringBuilder mysqlCSB;
            mysqlCSB = new MySqlConnectionStringBuilder();
            mysqlCSB.Server = server;
            mysqlCSB.Database = database;
            mysqlCSB.UserID = UserID;
            mysqlCSB.Password = Password;

            //mysqlCSB.Server = "shostka.mysql.ukraine.com.ua";
            //mysqlCSB.Database = "shostka_medcentr";
            //mysqlCSB.UserID = "shostka_medcentr";
            //mysqlCSB.Password = "Cpu25Pro";

            MySqlConnection con = new MySqlConnection();
            con.ConnectionString = mysqlCSB.ConnectionString;
            MySqlCommand cmd = new MySqlCommand();
            adapter = new MySqlDataAdapter(cmd);


            con.Open();
            cmd.CommandText = stat;
            cmd.Connection = con;
            cmd.ExecuteNonQuery();

            //
            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());
            con.Close();
            dtFbase = dt;
            return dt;
        }

        #region ObservableCollection 
        public ObservableCollection<CardPageFive> ReadDileryList()
        {
            ObservableCollection<CardPageFive> InlIst = new ObservableCollection<CardPageFive>();
            DataTable dt = new DataTable();
            MySqlConnectionStringBuilder mysqlCSB;
            mysqlCSB = new MySqlConnectionStringBuilder();
            mysqlCSB.Server = server;
            mysqlCSB.Database = database;
            mysqlCSB.UserID = UserID;
            mysqlCSB.Password = Password;
            mysqlCSB.ConvertZeroDateTime = true;

            string queryString = "SELECT * FROM diary";
            using (MySqlConnection con = new MySqlConnection())
            {
                con.ConnectionString = mysqlCSB.ConnectionString;
                MySqlCommand com = new MySqlCommand(queryString, con);
                var da = new MySqlDataAdapter(com);

                con.Open();
                using (MySqlDataReader dr = com.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        InlIst.Add(new CardPageFive
                        {
                            ComingDate = dr.GetDateTime("dataZvern").ToString(),
                            HealingPlace = dr.GetString("misceLik"),
                            Diagnosis = dr.GetString("diagnoz"),
                            Stamp = dr.GetString("pryznLik")
                        });
                    }
                }
                con.Close();
            }
            return InlIst;
        }
        public ObservableCollection<CardPageThree> DiagList()
        {
            ObservableCollection<CardPageThree> InlIst = new ObservableCollection<CardPageThree>();
            DataTable dt = new DataTable();
            MySqlConnectionStringBuilder mysqlCSB;
            mysqlCSB = new MySqlConnectionStringBuilder();
            mysqlCSB.Server = server;
            mysqlCSB.Database = database;
            mysqlCSB.UserID = UserID;
            mysqlCSB.Password = Password;
            mysqlCSB.ConvertZeroDateTime = true;

            string queryString = "SELECT * FROM diagnoz";
            using (MySqlConnection con = new MySqlConnection())
            {
                con.ConnectionString = mysqlCSB.ConnectionString;
                MySqlCommand com = new MySqlCommand(queryString, con);
                var da = new MySqlDataAdapter(com);

                con.Open();
                using (MySqlDataReader dr = com.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        InlIst.Add(new CardPageThree
                        {
                            DataZvern = dr.GetDateTime("dataZvern"),
                            ZaklDiagn = dr.GetString("text_diag"),
                            FDiagn = dr.GetBoolean("diagFirst"),
                            PDiag = dr.GetBoolean("diagProf"),
                            Sign = dr.GetString("pidpLik")
                        });
                    }
                }
                con.Close();




            }



            //InlIst = new ObservableCollection<OblickTable>
            //{
            //    new OblickTable { TakenDate="iPhone 7", TakenReason="Apple", RemovedDate="56000", RemovedReason ="fasfasf"},
            //    new OblickTable {TakenDate="Galaxy S7 Edge", TakenReason="Samsung", RemovedDate ="60000", RemovedReason="fsdfsdfs"},
            //    new OblickTable {TakenDate="Elite x3", TakenReason="HP", RemovedDate="56000",RemovedReason= "fdsfdsfd"},
            //    new OblickTable {TakenDate="Mi5S", TakenReason="Xiaomi", RemovedDate="35000" ,RemovedReason="fsdfsdf"}
            //};

            return InlIst;
        }

        public void Tetslist1(ObservableCollection<CardPageFive> temp)
        {
            ObservableCollection<CardPageFive> InlIst = temp;


            DataTable dt = new DataTable();
            MySqlConnectionStringBuilder mysqlCSB;
            mysqlCSB = new MySqlConnectionStringBuilder();
            mysqlCSB.Server = server;
            mysqlCSB.Database = database;
            mysqlCSB.UserID = UserID;
            mysqlCSB.Password = Password;



            using (MySqlConnection con = new MySqlConnection(mysqlCSB.ConnectionString))
            {
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    cmd.Connection = con;

                    con.Open();
                    foreach (var result in InlIst)
                    {

                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = @"UPDATE diary(ID, ID_pat, dataZvern, misceLik, diagnoz, pryznLik) 
                           VALUES(null, 13, @one, @two, @three, @four)";

                        cmd.Parameters.AddWithValue("@one", result.ComingDate);
                        cmd.Parameters.AddWithValue("@two", result.HealingPlace);
                        cmd.Parameters.AddWithValue("@three", result.Diagnosis);
                        cmd.Parameters.AddWithValue("@four", result.Stamp);
                        cmd.ExecuteNonQuery();
                        cmd.Parameters.Clear();
                    }


                }
            }
            //using (MySqlConnection con = new MySqlConnection())
            //{
            //    con.ConnectionString = mysqlCSB.ConnectionString;
            //    //MySqlCommand com = con.CreateCommand();
            //    MySqlCommand command = con.CreateCommand();

            //        con.Open();

            //        foreach (var result in InlIst)
            //        {

            //            command.CommandText =
            //               @"INSERT INTO diary (ID, ID_pat, dataZvern, misceLik, diagnoz, pryznLik) VALUES(null, 13, @one, @two, @three, @four)";
            //            command.Parameters.AddWithValue("@one", result.TakenDate);
            //            command.Parameters.AddWithValue("@two", result.TakenReason);
            //            command.Parameters.AddWithValue("@three", result.RemovedDate);
            //            command.Parameters.AddWithValue("@four", result.RemovedReason);
            //            command.ExecuteNonQuery();
            //        }

            //        con.Close();



            //}






        }

        #endregion


        public DataView Dpage3(string Statement)
        {
            stat = Statement;
            DataTable dt = new DataTable();
            MySqlConnectionStringBuilder mysqlCSB;
            mysqlCSB = new MySqlConnectionStringBuilder();
            mysqlCSB.Server = server;
            mysqlCSB.Database = database;
            mysqlCSB.UserID = UserID;
            mysqlCSB.Password = Password;

            MySqlConnection con = new MySqlConnection();
            con.ConnectionString = mysqlCSB.ConnectionString;
            MySqlCommand cmd = new MySqlCommand(stat);
            adapter = new MySqlDataAdapter(cmd);

            adapter.InsertCommand = new MySqlCommand("sp_listDiagn", con);
            adapter.InsertCommand.CommandType = CommandType.StoredProcedure;
            //adapter.InsertCommand.Parameters.Add(new MySqlParameter("@dataZvern", MySqlDbType.Date, 0, "DataZvern"));
            //adapter.InsertCommand.Parameters.Add(new MySqlParameter("@text_diag", MySqlDbType.VarChar, 1000, "ZaklDiagn"));
            //adapter.InsertCommand.Parameters.Add(new MySqlParameter("@diagFirst", MySqlDbType.Binary, 1, "FDiagn"));
            //adapter.InsertCommand.Parameters.Add(new MySqlParameter("@diagProf", MySqlDbType.Binary, 1, "PDiag"));
            //adapter.InsertCommand.Parameters.Add(new MySqlParameter("@pidpLik", MySqlDbType.Binary, 100, "Sign"));
            //MySqlParameter par = adapter.InsertCommand.Parameters.Add("@ID", MySqlDbType.Int32, 0, "Id");

            //par.Direction = ParameterDirection.Output;
            con.Open();
            cmd.Connection = con;

            adapter.Fill(dt);

            con.Close();
            dtFbase = dt;
            dt.Columns[2].ColumnName = "DataZvern";
            dt.Columns[3].ColumnName = "ZaklDiagn";
            dt.Columns[4].ColumnName = "FDiagn";
            dt.Columns[5].ColumnName = "PDiag";
            dt.Columns[6].ColumnName = "Sign";
            return dt.DefaultView;

        }
        public DataView Dpage4(string Statement)
        {
            stat = Statement;
            DataTable dt = new DataTable();
            MySqlConnectionStringBuilder mysqlCSB;
            mysqlCSB = new MySqlConnectionStringBuilder();
            mysqlCSB.Server = server;
            mysqlCSB.Database = database;
            mysqlCSB.UserID = UserID;
            mysqlCSB.Password = Password;

            MySqlConnection con = new MySqlConnection();
            con.ConnectionString = mysqlCSB.ConnectionString;
            MySqlCommand cmd = new MySqlCommand(stat);
            adapter = new MySqlDataAdapter(cmd);

            adapter.InsertCommand = new MySqlCommand("sp_listRentg", con);
            adapter.InsertCommand.CommandType = CommandType.StoredProcedure;

            con.Open();
            cmd.Connection = con;

            adapter.Fill(dt);

            con.Close();
            dtFbase = dt;
            dt.Columns[0].ColumnName = "nomZver";
            dt.Columns[2].ColumnName = "dataZver";
            dt.Columns[3].ColumnName = "VydDosl";
            dt.Columns[4].ColumnName = "doza";
            dt.Columns[5].ColumnName = "mitka";
            return dt.DefaultView;

        }
        public DataView Dpage5(string Statement)
        {
            stat = Statement;
            DataTable dt = new DataTable();
            MySqlConnectionStringBuilder mysqlCSB;
            mysqlCSB = new MySqlConnectionStringBuilder();
            mysqlCSB.Server = server;
            mysqlCSB.Database = database;
            mysqlCSB.UserID = UserID;
            mysqlCSB.Password = Password;

            MySqlConnection con = new MySqlConnection();
            con.ConnectionString = mysqlCSB.ConnectionString;
            MySqlCommand cmd = new MySqlCommand(stat);
            adapter = new MySqlDataAdapter(cmd);

            adapter.InsertCommand = new MySqlCommand("sp_listDiary", con);
            adapter.InsertCommand.CommandType = CommandType.StoredProcedure;

            con.Open();
            cmd.Connection = con;

            adapter.Fill(dt);

            con.Close();
            dtFbase = dt;
            //dt.Columns[0].ColumnName = "dataZver";
            dt.Columns[2].ColumnName = "dataZver";
            dt.Columns[3].ColumnName = "misceLik";
            dt.Columns[4].ColumnName = "skarga";
            dt.Columns[5].ColumnName = "Lechen";
            return dt.DefaultView;

        }
        //public string Name
        //{
        //    get { return stat; }
        //    set { stat = value; }
        //}
    }
}
