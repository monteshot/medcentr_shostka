using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;
namespace VrachMedcentr
{
    class connect
    {
        private string stat;

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

        //public DataRow selectARR(string field, string value)
        //{

        //    DataRow result=null;
        //    DataRow[] DR;

        //    DR = dtFbase.Select(field + "='" + value + "'");

        //        result = DR[0].ItemArray;


        //    return result;

        //}
        public DataTable query(string Statement)
        {
            stat = Statement;
            MySqlConnectionStringBuilder mysqlCSB;
            mysqlCSB = new MySqlConnectionStringBuilder();
            mysqlCSB.Server = "shostka.mysql.ukraine.com.ua";
            mysqlCSB.Database = "shostka_medcentr";
            mysqlCSB.UserID = "shostka_medcentr";
            mysqlCSB.Password = "Cpu25Pro";

            MySqlConnection con = new MySqlConnection();
            con.ConnectionString = mysqlCSB.ConnectionString;
            MySqlCommand cmd = new MySqlCommand();

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

        //public string Name
        //{
        //    get { return stat; }
        //    set { stat = value; }
        //}
    }
}
