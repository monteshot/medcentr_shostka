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
        #region Private Variables

        public string server;
        public string database;
        public string UserID;
        public string Password;

        private string stat;
        MySqlDataAdapter adapter;
        private DataTable dtFbase;
        #endregion


        #region Constructors
        public connect()
        {
            server = "shostka.mysql.ukraine.com.ua";
            database = "shostka_medcen";
            UserID = "shostka_medcen";
            Password = "n5t7jzqv";
        }
        public connect(string Server, string Database, string userid, string pass)
        {
            server = Server;
            database = Database;
            UserID = userid;
            Password = pass;
        }
        #endregion

        public /*ObservableCollection*/CardPageOne karta(/*string Name, string LastName, DateTime bDate*/string UID)
        {

            MySqlConnectionStringBuilder mysqlCSB;
            mysqlCSB = new MySqlConnectionStringBuilder();
            mysqlCSB.Server = server;
            mysqlCSB.Database = database;
            mysqlCSB.UserID = UserID;
            mysqlCSB.Password = Password;

            MySqlConnection con = new MySqlConnection();
            con.ConnectionString = mysqlCSB.ConnectionString;
            MySqlCommand cmd = new MySqlCommand();
            ObservableCollection<CardPageOne> temp = new ObservableCollection<CardPageOne>();
            CardPageOne temp1 = new CardPageOne();

            con.Open();
            cmd.Parameters.AddWithValue("@UserID", UID);
            //cmd.Parameters.AddWithValue("@name", Name);
            //cmd.Parameters.AddWithValue("@Lname", LastName);
            //cmd.Parameters.AddWithValue("@birthDate", bDate);
            cmd.CommandText = "SELECT * FROM karta WHERE ID_pat=@UserID";// WHERE P=@Lname AND I=@name AND birthDate=@birthDate
            cmd.Connection = con;
            cmd.ExecuteNonQuery();
            using (MySqlDataReader dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {
                    temp1 = (new CardPageOne
                    {
                        NumberPacient = dr.GetString("ID_pat"),
                        Sername = dr.GetString("P"),
                        Name = dr.GetString("I"),
                        FathersName = dr.GetString("B"),
                        Adress = dr.GetString("adres"),
                        Sex = ConvSex(dr.GetString("sex")),
                        dateBirth = (DateTime)dr.GetMySqlDateTime("birthDate"),
                        LeavingPlace = dr.GetString("nasPunkt"),
                        WorkingPlace = dr.GetString("robota"),
                        Contingency = dr.GetString("konting"),
                        Dispensary = dr.GetBoolean("dispans"),
                        PreferentNumber = dr.GetString("npmPilg")
                        // Likar = GetDoctrosNames(dr.GetString("id"))



                    });
                }
            }
            con.Close();

            return temp1;
        }

        public CardPageTwo signPozn(string UID)
        {

            MySqlConnectionStringBuilder mysqlCSB;
            mysqlCSB = new MySqlConnectionStringBuilder();
            mysqlCSB.Server = server;
            mysqlCSB.Database = database;
            mysqlCSB.UserID = UserID;
            mysqlCSB.Password = Password;

            MySqlConnection con = new MySqlConnection();
            con.ConnectionString = mysqlCSB.ConnectionString;
            MySqlCommand cmd = new MySqlCommand();

            CardPageTwo temp1 = new CardPageTwo();
            try
            {
                con.Open();
                cmd.Parameters.AddWithValue("@UserID", UID);

                cmd.CommandText = "SELECT * FROM signpozn WHERE ID_pat=@UserID";//
                cmd.Connection = con;
                cmd.ExecuteNonQuery();

                using (MySqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        temp1 = (new CardPageTwo
                        {
                            Shugar = dr.GetString("diabet"),
                            InfectiousDis = dr.GetString("Infeciya"),
                            AlergiAnam = dr.GetString("AlAnam"),
                            IntoleranceToDrugs = dr.GetString("AlergiyaLek"),
                            NumPat = dr.GetString("ID_pat")



                        });
                    }
                }
                con.Close();
            }
            catch (Exception e) { }

            return temp1;
        }

        public ObservableCollection<Sheplenya> shepl(string UID)
        {

            MySqlConnectionStringBuilder mysqlCSB;
            mysqlCSB = new MySqlConnectionStringBuilder();
            mysqlCSB.Server = server;
            mysqlCSB.Database = database;
            mysqlCSB.UserID = UserID;
            mysqlCSB.Password = Password;

            MySqlConnection con = new MySqlConnection();
            con.ConnectionString = mysqlCSB.ConnectionString;
            MySqlCommand cmd = new MySqlCommand();

            ObservableCollection<Sheplenya> temp1 = new ObservableCollection<Sheplenya>();

            con.Open();
            cmd.Parameters.AddWithValue("@UserID", UID);

            cmd.CommandText = "SELECT * FROM sheplennya WHERE ID_pat=@UserID";//
            cmd.Connection = con;
            cmd.ExecuteNonQuery();
            using (MySqlDataReader dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {
                    temp1.Add(new Sheplenya
                    {

                        NumPat = dr.GetString("ID_pat"),
                        NazvaShepl = dr.GetString("nazvaShep"),
                        Date = dr.GetDateTime("date"),
                        Age = dr.GetString("age"),
                        Doze = dr.GetString("doza"),
                        Seria = dr.GetString("seriya"),
                        NazvaPrep = dr.GetString("nazvaPrep"),
                        SposibVV = dr.GetString("sposib"),
                        MReact = dr.GetBoolean("reakMisceva"),
                        ZReact = dr.GetBoolean("reakZagal"),
                        MedProt = dr.GetString("medProty")


                    });
                }
            }
            con.Close();

            return temp1;
        }
        public ObservableCollection<Profilact> profilact(string UID)
        {

            MySqlConnectionStringBuilder mysqlCSB;
            mysqlCSB = new MySqlConnectionStringBuilder();
            mysqlCSB.Server = server;
            mysqlCSB.Database = database;
            mysqlCSB.UserID = UserID;
            mysqlCSB.Password = Password;

            MySqlConnection con = new MySqlConnection();
            con.ConnectionString = mysqlCSB.ConnectionString;
            MySqlCommand cmd = new MySqlCommand();

            ObservableCollection<Profilact> temp1 = new ObservableCollection<Profilact>();

            con.Open();
            cmd.Parameters.AddWithValue("@UserID", UID);

            cmd.CommandText = "SELECT * FROM profilact WHERE ID_pat=@UserID";//
            cmd.Connection = con;
            cmd.ExecuteNonQuery();
            using (MySqlDataReader dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {
                    temp1.Add(new Profilact
                    {

                        NumPat = dr.GetString("ID_pat"),
                        Date = dr.GetDateTime("date"),
                        NumCab = dr.GetString("noCabinet"),
                        Flura = dr.GetString("flyra"),
                        Syphilis = dr.GetString("sifon"),
                        HIV = dr.GetString("HIV")


                    });
                }
            }
            con.Close();

            return temp1;
        }

        public ObservableCollection<CardPageFour> rentgen(string UID)
        {

            MySqlConnectionStringBuilder mysqlCSB;
            mysqlCSB = new MySqlConnectionStringBuilder();
            mysqlCSB.Server = server;
            mysqlCSB.Database = database;
            mysqlCSB.UserID = UserID;
            mysqlCSB.Password = Password;

            MySqlConnection con = new MySqlConnection();
            con.ConnectionString = mysqlCSB.ConnectionString;
            MySqlCommand cmd = new MySqlCommand();

            ObservableCollection<CardPageFour> temp1 = new ObservableCollection<CardPageFour>();

            con.Open();
            cmd.Parameters.AddWithValue("@UserID", UID);

            cmd.CommandText = "SELECT * FROM rentgen WHERE ID_pat=@UserID";//
            cmd.Connection = con;
            cmd.ExecuteNonQuery();
            using (MySqlDataReader dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {
                    temp1.Add(new CardPageFour
                    {
                        NumList = dr.GetString("ID"),
                        NumPat = dr.GetString("ID_pat"),
                        Date = dr.GetDateTime("date"),
                        Procedure = dr.GetString("doslid"),
                        Doze = dr.GetString("doza"),
                        Mitka = dr.GetString("mitka")


                    });
                }
            }
            con.Close();

            return temp1;
        }
        //bool ConvDispensary(bool num) {

        //    bool dispOut = false;
        //    if (num == "1") { return dispOut = true; }
        //    else if (num == "0") {return dispOut = false; }
        //    return dispOut;
        //}
        bool ConvSex(string bukva)
        {
            bool sex = false;
            if (bukva == "M") { return sex = false; }
            else if (bukva == "F") { return sex = true; }
            return sex;
        }
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




        #region ObservableCollectionRead 

        public ObservableCollection<CardUsers> GetCardUsersList(DateTime _bornDate)
        {

            MySqlConnectionStringBuilder mysqlCSB;
            mysqlCSB = new MySqlConnectionStringBuilder();
            mysqlCSB.Server = server;
            mysqlCSB.Database = database;
            mysqlCSB.UserID = UserID;
            mysqlCSB.Password = Password;

            MySqlConnection con = new MySqlConnection();
            con.ConnectionString = mysqlCSB.ConnectionString;
            MySqlCommand cmd = new MySqlCommand();
            ObservableCollection<CardUsers> temp = new ObservableCollection<CardUsers>();

            con.Open();

            cmd.CommandText = "SELECT * FROM karta";
            cmd.Connection = con;
            cmd.ExecuteNonQuery();
            using (MySqlDataReader dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {
                    temp.Add(new CardUsers
                    {
                        userFIO = dr.GetString("P") + dr.GetString("I") + dr.GetString("B")



                    });
                }
            }
            con.Close();

            return temp;
        }



        /// <summary>
        /// Считывание дненвика с базы
        /// </summary>
        /// <returns></returns>
        //public ObservableCollection<CardPageFive> ReadDileryList()
        //{
        //    ObservableCollection<CardPageFive> InlIst = new ObservableCollection<CardPageFive>();
        //    DataTable dt = new DataTable();
        //    MySqlConnectionStringBuilder mysqlCSB;
        //    mysqlCSB = new MySqlConnectionStringBuilder();
        //    mysqlCSB.Server = server;
        //    mysqlCSB.Database = database;
        //    mysqlCSB.UserID = UserID;
        //    mysqlCSB.Password = Password;
        //    mysqlCSB.ConvertZeroDateTime = true;

        //    string queryString = "SELECT * FROM diary";
        //    using (MySqlConnection con = new MySqlConnection())
        //    {
        //        con.ConnectionString = mysqlCSB.ConnectionString;
        //        MySqlCommand com = new MySqlCommand(queryString, con);
        //        var da = new MySqlDataAdapter(com);

        //        con.Open();
        //        using (MySqlDataReader dr = com.ExecuteReader())
        //        {
        //            while (dr.Read())
        //            {
        //                InlIst.Add(new CardPageFive
        //                {
        //                    ComingDate = dr.GetDateTime("dataZvern").ToString(),
        //                    HealingPlace = dr.GetString("misceLik"),
        //                    Diagnosis = dr.GetString("diagnoz"),
        //                    Stamp = dr.GetString("pryznLik")
        //                });
        //            }
        //        }
        //        con.Close();
        //    }
        //    return InlIst;
        //}

        /// <summary>
        /// Считивание листа записи заключних диагнозов страница карточки 3
        /// </summary>
        /// <returns></returns>
        public ObservableCollection<CardPageThree> DiagList(string UID)
        {
            ObservableCollection<CardPageThree> InlIst = new ObservableCollection<CardPageThree>();

            MySqlConnectionStringBuilder mysqlCSB;
            MySqlConnection con = new MySqlConnection();

            MySqlCommand cmd = new MySqlCommand();
            mysqlCSB = new MySqlConnectionStringBuilder();
            mysqlCSB.Server = server;
            mysqlCSB.Database = database;
            mysqlCSB.UserID = UserID;
            mysqlCSB.Password = Password;

            con.ConnectionString = mysqlCSB.ConnectionString;

            con.Open();
            cmd.Parameters.AddWithValue("@UserID", UID);
            cmd.CommandText = "SELECT * FROM diagnoz WHERE ID_pat=@UserID";//
            cmd.Connection = con;
            cmd.ExecuteNonQuery();
            using (MySqlDataReader dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {
                    InlIst.Add(new CardPageThree
                    {

                        NumPat = dr.GetString("ID_pat"),
                        DataZvern = dr.GetDateTime("dataZvern"),
                        ZaklDiagn = dr.GetString("text_diag"),
                        FDiagn = dr.GetBoolean("diagFirst"),
                        PDiag = dr.GetBoolean("diagProf"),
                        Sign = dr.GetString("pidpLik")


                    });
                }
            }
            con.Close();


            //copyP3 = InlIst;
            return InlIst;
        }

        public ObservableCollection<CardPageFive> diary(string UID)
        {
            ObservableCollection<CardPageFive> InlIst = new ObservableCollection<CardPageFive>();

            MySqlConnectionStringBuilder mysqlCSB;
            MySqlConnection con = new MySqlConnection();

            MySqlCommand cmd = new MySqlCommand();
            mysqlCSB = new MySqlConnectionStringBuilder();
            mysqlCSB.Server = server;
            mysqlCSB.Database = database;
            mysqlCSB.UserID = UserID;
            mysqlCSB.Password = Password;

            con.ConnectionString = mysqlCSB.ConnectionString;

            con.Open();
            cmd.Parameters.AddWithValue("@UserID", UID);
            cmd.CommandText = "SELECT * FROM diary WHERE ID_pat=@UserID";//
            cmd.Connection = con;
            cmd.ExecuteNonQuery();
            using (MySqlDataReader dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {
                    InlIst.Add(new CardPageFive
                    {

                        NumPat = dr.GetString("ID_pat"),
                        Date = dr.GetDateTime("dataZvern"),
                        MisceLik = dr.GetString("misceLik"),
                        Diagnosis = dr.GetString("diagnoz"),
                        PryznLik = dr.GetString("pryznLik")


                    });
                }
            }
            con.Close();


            //copyP3 = InlIst;
            return InlIst;
        }

        public void save2(string UID, string Sugar, string AlergAn, string InfDis, string MedInt, Sheplenya colShepl=null, Profilact colProfilact=null)
        {
            MySqlConnectionStringBuilder mysqlCSB;
            mysqlCSB = new MySqlConnectionStringBuilder();
            mysqlCSB.Server = server;
            mysqlCSB.Database = database;
            mysqlCSB.UserID = UserID;
            mysqlCSB.Password = Password;

            MySqlConnection con = new MySqlConnection();
            con.ConnectionString = mysqlCSB.ConnectionString;
            MySqlCommand cmd = new MySqlCommand();

            CardPageTwo temp1 = new CardPageTwo();

            con.Open();
            cmd.Parameters.AddWithValue("@UserID", UID);
            cmd.Parameters.AddWithValue("@Sugar", Sugar);
            cmd.Parameters.AddWithValue("@InfDis", InfDis);
            cmd.Parameters.AddWithValue("@AlergAn", AlergAn);
            cmd.Parameters.AddWithValue("@MedInt", MedInt);
            cmd.CommandText = "UPDATE signpozn AS SG SET SG.diabet=@Sugar,SG.Infeciya=@InfDis, SG.AlAnam=@AlergAn, SG.AlergiyaLek=@MedInt WHERE SG.ID_pat=@UserID";//
            cmd.Connection = con;
            cmd.ExecuteNonQuery();
            con.Close();
        }


        private ObservableCollection<CardPageThree> copyP3;
        /// <summary>
        ///  Не рабюотает сравненеи обектов колекции( метод для страници карточки 3)
        /// </summary>
        /// <param name="temp"></param>
        public void UpdateP3(ObservableCollection<CardPageThree> temp)
        {
            // copyP3 = DiagList();
            ObservableCollection<CardPageThree> InlIst = new ObservableCollection<CardPageThree>();


            foreach (var orig in temp)
            {
                foreach (var copy in copyP3)
                {
                    if (copyP3.IndexOf(copy) != temp.IndexOf(orig))
                    {
                        InlIst.Add(orig);
                    }
                    //if (orig != copy) 
                }
                //{
                //    InlIst.Add(orig);
                //}


            }

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
                        cmd.CommandText = "INSERT INTO diagnoz(ID, ID_pat, dataZvern, text_diag, diagFirst, diagProf, pidpLik) VALUES(null, 99, @dataZvern, @text_diag, @diagFirst, @diagProf,@pidpLik)";

                        cmd.Parameters.AddWithValue("@dataZvern", result.DataZvern);
                        cmd.Parameters.AddWithValue("@text_diag", result.ZaklDiagn);
                        cmd.Parameters.AddWithValue("@diagFirst", result.FDiagn);
                        cmd.Parameters.AddWithValue("@diagProf", result.PDiag);
                        cmd.Parameters.AddWithValue("@pidpLik", result.Sign);
                        cmd.ExecuteNonQuery();
                        cmd.Parameters.Clear();
                    }


                }
            }
        }
        /// <summary>
        ///  Не робочий метод для записи дненвика в базу( инсерт не подходит)
        /// </summary>
        /// <param name="temp"></param>
        public void InsertDileryBase(ObservableCollection<CardPageFive> temp)
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
                        //"UPDATE Student SET Address = @add, City = @cit Where FirstName = @fn and LastName = @add"
                        cmd.CommandText = "UPDATE `diary` SET `ID_pat`='1',`misceLik`= @healingplace, `diagnoz`= @diagnosis, `pryznLik`= @stamp WHERE 1";

                        // cmd.Parameters.AddWithValue("@comingdate", result.ComingDate);
                        cmd.Parameters.AddWithValue("@healingplace", result.MisceLik);
                        cmd.Parameters.AddWithValue("@diagnosis", result.Diagnosis);
                        cmd.Parameters.AddWithValue("@stamp", result.PryznLik);
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
        /// <summary>
        /// Дальше методы с дата тейблом нужны ли они?
        /// </summary>
        /// <param name="Statement"></param>
        /// <returns></returns>
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
