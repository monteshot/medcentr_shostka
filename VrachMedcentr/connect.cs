using System;
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
using WPF_Hospital;

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
        DataTable dt = new DataTable();
        public DataView Dpage3(/*string Statement*/)
        {
            // stat = Statement;
          
            
            try { dt.Columns.Clear(); } catch (Exception) { }
            
            MySqlConnectionStringBuilder mysqlCSB;
            mysqlCSB = new MySqlConnectionStringBuilder();
            mysqlCSB.Server = server;
            mysqlCSB.Database = database;
            mysqlCSB.UserID = UserID;
            mysqlCSB.Password = Password;
          
            MySqlConnection con = new MySqlConnection();
            con.ConnectionString = mysqlCSB.ConnectionString;
            MySqlCommand cmd = new MySqlCommand(/*stat*/);
           
            adapter = new MySqlDataAdapter(cmd);
            ///добавляем в базу новую строку
           
            adapter.FillLoadOption = LoadOption.OverwriteChanges;

            adapter.SelectCommand.CommandText = "SELECT * FROM diagnoz";
           
           
    

            adapter.InsertCommand = new MySqlCommand("INSERT INTO diagnoz (ID, ID_pat, dataZvern, text_diag, diagFirst, diagProf, pidpLik) VALUES (null,'99',@dataZvern1,@text_diag1,@diagFirst1,@diagProf1,@pidpLik1)");
            //  adapter.InsertCommand = new MySqlCommand("INSERT INTO diagnoz (ID, ID_pat, dataZvern, text_diag, diagFirst, diagProf, pidpLik) VALUES (null,'99',dataZvern=@dataZvern,text_diag=@text_diag,diagFirst=@diagFirst,diagProf=@diagProf,pidpLik=@pidpLik)");
            //  adapter.InsertCommand = new MySqlCommand("INSERT INTO diagnoz (ID, ID_pat) VALUES (null,'99')");
           
            adapter.InsertCommand.CommandType = CommandType.Text;
            adapter.InsertCommand.Parameters.Add(new MySqlParameter("@dataZvern1", MySqlDbType.Date, 0, "DataZvern"));
            adapter.InsertCommand.Parameters.Add(new MySqlParameter("@text_diag1", MySqlDbType.VarChar, 1000, "ZaklDiagn"));
            adapter.InsertCommand.Parameters.Add(new MySqlParameter("@diagFirst1", MySqlDbType.Binary, 1, "FDiagn"));
            adapter.InsertCommand.Parameters.Add(new MySqlParameter("@diagProf1", MySqlDbType.Binary, 1, "PDiag"));
            adapter.InsertCommand.Parameters.Add(new MySqlParameter("@pidpLik1", MySqlDbType.VarChar, 100, "Sign"));
            adapter.InsertCommand.Parameters.Add("@ID_pat", MySqlDbType.Int32, 0, "Id_pat");

            adapter.SelectCommand.Parameters.Add("@ID_pat", MySqlDbType.Int32, 0, "Id_pat");
            adapter.SelectCommand.Parameters.Add(new MySqlParameter("@dataZvern1", MySqlDbType.Date, 0, "DataZvern"));
            adapter.SelectCommand.Parameters.Add(new MySqlParameter("@text_diag1", MySqlDbType.VarChar, 1000, "ZaklDiagn"));
            adapter.SelectCommand.Parameters.Add(new MySqlParameter("@diagFirst1", MySqlDbType.Binary, 1, "FDiagn"));
            adapter.SelectCommand.Parameters.Add(new MySqlParameter("@diagProf1", MySqlDbType.Binary, 1, "PDiag"));
            adapter.SelectCommand.Parameters.Add(new MySqlParameter("@pidpLik1", MySqlDbType.VarChar, 100, "Sign"));
            MySqlParameter par = adapter.InsertCommand.Parameters.Add("@ID", MySqlDbType.Int32, 0, "Id");
            
            

            par.Direction = ParameterDirection.Output;
            // dt = null;
           // dt.Columns.Clear();
           
            con.Open();
            
            cmd.Connection = con;
            ///читаем с базы 

            try { adapter.Fill(dt); } catch (Exception) { }
           

            con.Close();
            dtFbase = dt;
      
            dt.Columns[2].ColumnName = "DataZvern";
            dt.Columns[3].ColumnName = "ZaklDiagn";
            dt.Columns[4].ColumnName = "FDiagn";
            dt.Columns[5].ColumnName = "PDiag";
            dt.Columns[6].ColumnName = "Sign";
            dt.Columns[2].DataType.Equals(typeof(DatePicker));

            return dt.DefaultView;

        }
        public void UpdateDB()
        {
          //  dt = null;
            MySqlCommandBuilder comandbuilder = new MySqlCommandBuilder(adapter);

            adapter.Update(dt);
            dt.AcceptChanges();


            //MySqlConnectionStringBuilder mysqlCSB;
            //mysqlCSB = new MySqlConnectionStringBuilder();
            //mysqlCSB.Server = server;
            //mysqlCSB.Database = database;
            //mysqlCSB.UserID = UserID;
            //mysqlCSB.Password = Password;

            //MySqlConnection con = new MySqlConnection();
            //con.ConnectionString = mysqlCSB.ConnectionString;

            //MySqlCommand cmd = new MySqlCommand();


            //adapter.InsertCommand.Parameters.Add(new MySqlParameter("@dataZvern", MySqlDbType.Date, 0, "DataZvern"));
            //adapter.InsertCommand.Parameters.Add(new MySqlParameter("@text_diag", MySqlDbType.VarChar, 1000, "ZaklDiagn"));
            //adapter.InsertCommand.Parameters.Add(new MySqlParameter("@diagFirst", MySqlDbType.Binary, 1, "FDiagn"));
            //adapter.InsertCommand.Parameters.Add(new MySqlParameter("@diagProf", MySqlDbType.Binary, 1, "PDiag"));
            //adapter.InsertCommand.Parameters.Add(new MySqlParameter("@pidpLik", MySqlDbType.Binary, 100, "Sign"));
            //adapter.InsertCommand = new MySqlCommand("INSERT INTO diagnoz (ID, ID_pat, dataZvern,text_diag, diagFirst, diagProf, pidpLik) VALUES (null,'99',dataZvern=@dataZvern,text_diag=@text_diag,diagFirst=@diagFirst,diagProf=@diagProf,pidpLik=@pidpLik)");

            // dt.AcceptChanges();
            //MySqlConnectionStringBuilder mysqlCSB;
            //mysqlCSB = new MySqlConnectionStringBuilder();
            //mysqlCSB.Server = server;
            //mysqlCSB.Database = database;
            //mysqlCSB.UserID = UserID;
            //mysqlCSB.Password = Password;

            //MySqlConnection con = new MySqlConnection();
            //con.ConnectionString = mysqlCSB.ConnectionString;

            //MySqlCommand cmd = new MySqlCommand();
            //{
            //    con.Open();
            //    cmd.CommandText = "INSERT INTO diagnoz (ID, ID_pat) VALUES (null,'99')";
            //    cmd.Connection = con;

            //    cmd.ExecuteNonQuery();
            //    con.Close();
            //}

        }
        public DataView Dpage4(string Statement)
        {
            stat = Statement;
            //  DataTable dt = new DataTable();
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
            //   DataTable dt = new DataTable();
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
