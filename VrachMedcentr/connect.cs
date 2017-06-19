﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MySql.Data.MySqlClient;
using System.Data;


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
            adapter.InsertCommand.Parameters.Add(new MySqlParameter("@dataZvern", MySqlDbType.Date, 0, "DataZvern"));
            adapter.InsertCommand.Parameters.Add(new MySqlParameter("@text_diag", MySqlDbType.VarChar, 1000, "ZaklDiagn"));
            adapter.InsertCommand.Parameters.Add(new MySqlParameter("@diagFirst", MySqlDbType.Binary, 1, "FDiagn"));
            adapter.InsertCommand.Parameters.Add(new MySqlParameter("@diagProf", MySqlDbType.Binary, 1, "PDiag"));
            adapter.InsertCommand.Parameters.Add(new MySqlParameter("@pidpLik", MySqlDbType.Binary, 100, "Sign"));
            MySqlParameter par = adapter.InsertCommand.Parameters.Add("@ID", MySqlDbType.Int32, 0, "Id");

            par.Direction = ParameterDirection.Output;
            con.Open();
            //           cmd.CommandText = stat;
            cmd.Connection = con;

            adapter.Fill(dt);
            //cmd.ExecuteNonQuery();

            //

            //  dt.Load(cmd.ExecuteReader());
            con.Close();
            dtFbase = dt;
            //dt.Columns[0].Caption = "azazaza231zaz";
            dt.Columns[2].ColumnName = "DataZvern";
            dt.Columns[3].ColumnName = "ZaklDiagn";
            dt.Columns[4].ColumnName = "FDiagn";
            //            dt.Columns[4]
            dt.Columns[5].ColumnName = "PDiag";
            dt.Columns[6].ColumnName = "Sign";
            return dt.DefaultView;
            //arr = new object[dt.Rows.Count];
            //for (int k = 0; k <= dt.Rows.Count - 1; k++)
            //{
            //    arr[k] = dt.Rows[k].ItemArray;

            //}
            //return arr;
        }
        //public string Name
        //{
        //    get { return stat; }
        //    set { stat = value; }
        //}
    }
}
