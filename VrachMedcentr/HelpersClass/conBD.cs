using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfControls;

namespace VrachMedcentr
{
    class conBD
    {
        string server;
        string database;
        string UserID;
        string Password;
        private string stat;

        public conBD()
        {
            server = "shostka.mysql.ukraine.com.ua";
            database = "shostka_odc";
            UserID = "shostka_odc";
            Password = "Cpu1234Pro";
        }

        #region Get doctors Specialization and Names fow TreeView

        /// <summary>
        ///  Find All Specialization  and make doctor list
        /// </summary>
        /// <returns></returns>
        public List<DoctorsList> getList()
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

            List<DoctorsList> temp = new List<DoctorsList>();
            // List<DoctorsList.DocNames> Docname1= new List<DoctorsList.DocNames>();

            con.Open();
            cmd.CommandText = "SELECT * FROM ekfgq_ttfsp_sprspec";
            cmd.Connection = con;
            cmd.ExecuteNonQuery();
            using (MySqlDataReader dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {
                    temp.Add(new DoctorsList
                    {
                        specf = dr.GetString("name"),
                        idspecf = dr.GetInt32("id")
                        // Likar = GetDoctrosNames(dr.GetString("id"))



                    });
                }
            }
            con.Close();
            // GetDoctrosNames(5);
            return temp;
        }

        /// <summary>
        ///  Find DocNames For each specialization
        /// </summary>
        /// <param name="specialization"></param>
        /// <returns></returns>
        public ObservableCollection<DocNames> GetDoctrosNames(string specialization)
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
            ObservableCollection<DocNames> temp = new ObservableCollection<DocNames>();
            con.Open();
            cmd.CommandText = "SELECT * FROM ekfgq_ttfsp_spec WHERE idsprspec = @IDSpecialization";//',9,'
            cmd.Parameters.AddWithValue("@IDSpecialization", "," + specialization + ",");
            cmd.Connection = con;
            cmd.ExecuteNonQuery();
            using (MySqlDataReader dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {
                    temp.Add(new DocNames
                    {

                        docName = dr.GetString("name"),
                        docID = dr.GetString("id"),
                        docBool = GetDocTimeTalonStatus(Convert.ToInt32(dr.GetString("id"))),
                        docEmail = dr.GetString("specmail"),
                        docTimeId = dr.GetString("idsprtime"),
                        docCab = dr.GetString("number_cabinet")


                    });
                }
            }
            con.Close();
            return temp;
        }

        public ObservableCollection<DocNames> GetDoctorsNamesFORStartup()
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
            ObservableCollection<DocNames> temp = new ObservableCollection<DocNames>();
         //   DocNames temp1 = new DocNames();
            con.Open();
            cmd.CommandText = "SELECT * FROM ekfgq_ttfsp_spec";//',9,'

            cmd.Connection = con;
            cmd.ExecuteNonQuery();
            using (MySqlDataReader dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {
                    temp.Add(new DocNames
                    {

                        docName = dr.GetString("name"),
                        docID = dr.GetString("id"),
                        docBool = GetDocTimeTalonStatus(Convert.ToInt32(dr.GetString("id"))),
                        docEmail = dr.GetString("specmail"),
                        docTimeId = dr.GetString("idsprtime"),
                        docCab = dr.GetString("number_cabinet")


                    });
                }
            }
            con.Close();
            return temp;
        }
        public bool GetDocTimeTalonStatus(int _docid)
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
            bool parametr = false;
            con.Open();
            cmd.CommandText = "SELECT * FROM talon_time WHERE doctor_id = @IDSpecialist";//',9,'
            cmd.Parameters.AddWithValue("@IDSpecialist", _docid);
            cmd.Connection = con;
            cmd.ExecuteNonQuery();
            using (MySqlDataReader dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {
                    if (dr.GetInt32("parametr") == 0)
                    {
                        parametr = false;
                    }
                    else
                    {
                        parametr = true;
                    }
                }
            }
            con.Close();
            return parametr;
        }
        #endregion

        #region GET DOCTORS TIMES
        public ObservableCollection<Times> getDocTimes(string docId, string docTimeId, DateTime date)
        {

            MySqlConnectionStringBuilder mysqlCSB;
            mysqlCSB = new MySqlConnectionStringBuilder();
            mysqlCSB.Server = server;
            mysqlCSB.Database = database;
            mysqlCSB.UserID = UserID;
            mysqlCSB.Password = Password;
            // string getDocTime = null;

            List<string> getDocPubTime = null;
            List<string> getDocPrivateTime = null;
            MySqlConnection con = new MySqlConnection();
            con.ConnectionString = mysqlCSB.ConnectionString;
            MySqlCommand cmd = new MySqlCommand();

            ObservableCollection<Times> temp = new ObservableCollection<Times>();


            con.Open();
            cmd.CommandText = "SELECT * FROM ekfgq_ttfsp_sprtime WHERE id = @docId";//',9,'
            cmd.Parameters.AddWithValue("@docId", docTimeId);
            cmd.Connection = con;
            cmd.ExecuteNonQuery();
            using (MySqlDataReader dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {
                    //getDocTime = dr.GetString("timehm");
                    getDocPubTime = getParseTime(dr.GetString("timehm"));
                    getDocPrivateTime = getParseTime(dr.GetString("timeprv"));
                    // getDocTimes= dr.GetString("timehm");

                }
            }


            con.Close();



            foreach (var a in getDocPubTime)
            {
                if (a != "" && a != null)
                {
                    temp.Add(new Times { Time = a, Status = GetStat(a, date, docId), PublickPrivate = true });
                }
            }

            foreach (var a in getDocPrivateTime)
            {
                if (a != "" && a != null)
                {
                    temp.Add(new Times { Time = a, Status = GetStat(a, date, docId), PublickPrivate = false });
                }
            }


            updateCurrList = getDocPubTime;
            DocID = docId;
            return temp;
        }
        /// <summary>
        /// Function for check aveliable list of doctors shedule
        /// </summary>
        /// <param name="_doctimeid"></param>
        /// <returns></returns>
        public bool CheckDoctorList(string _doctimeid)
        {
            MySqlConnectionStringBuilder mysqlCSB;
            mysqlCSB = new MySqlConnectionStringBuilder();
            mysqlCSB.Server = server;
            mysqlCSB.Database = database;
            mysqlCSB.UserID = UserID;
            mysqlCSB.Password = Password;
            // string getDocTime = null;

            bool temp;
            MySqlConnection con = new MySqlConnection();
            con.ConnectionString = mysqlCSB.ConnectionString;
            MySqlCommand cmd = new MySqlCommand();



            con.Open();
            cmd.CommandText = "SELECT EXISTS (SELECT * FROM ekfgq_ttfsp_sprtime WHERE id = @docId)";//',9,'
            cmd.Parameters.AddWithValue("@docId", _doctimeid);
            cmd.Connection = con;
            cmd.ExecuteNonQuery();
            var i = cmd.ExecuteScalar();
            if (Convert.ToInt32(i) == 1)
            {
                temp = true;
            }
            else
            {
                temp = false;
            }

            con.Close();

            return temp;
        }

        List<string> updateCurrList;
        string DocID;

        public void updateCurr(string publickTime, string privaTetime, string DocID)
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


            con.Open();
            //Recording publick times to base
            cmd.CommandText = "UPDATE ekfgq_ttfsp_sprtime SET timehm=@publickTime WHERE id = @docId";//',9,'
            cmd.Parameters.AddWithValue("@publickTime", publickTime);
            cmd.Parameters.AddWithValue("@docId", DocID);
            cmd.Connection = con;
            cmd.ExecuteNonQuery();

            //Recording  private times to base
            cmd.CommandText = "UPDATE ekfgq_ttfsp_sprtime SET timeprv=@privaTetime WHERE id = @docId";//',9,'
            cmd.Parameters.AddWithValue("@privaTetime", privaTetime);
            cmd.Connection = con;
            cmd.ExecuteNonQuery();

        }


        public List<string> getParseTime(string time)
        {
            List<string> tempTime = new List<string>();
            string[] cutTime = time.Split(new char[] { '\r' });
            foreach (var a in cutTime) { tempTime.Add(a); }
            return tempTime;
        }
        public string GetStat(string time, DateTime date, string docId)
        {
            MySqlConnectionStringBuilder mysqlCSB;
            mysqlCSB = new MySqlConnectionStringBuilder();
            mysqlCSB.Server = server;
            mysqlCSB.Database = database;
            mysqlCSB.UserID = UserID;
            mysqlCSB.Password = Password;
            string[] parTime = time.Split(new char[] { ':' });
            string result = "";
            MySqlConnection con = new MySqlConnection();
            con.ConnectionString = mysqlCSB.ConnectionString;
            MySqlCommand cmd = new MySqlCommand();
            // List<Times> temp = new List<Times>();
            con.Open();
            cmd.CommandText = "SELECT * FROM ekfgq_ttfsp_dop WHERE id_specialist = @docId AND date=@dateDB AND hours=@Hours AND minutes=@Mins";//',9,'
            cmd.Parameters.AddWithValue("@docId", docId);
            cmd.Parameters.AddWithValue("@dateDB", date);
            cmd.Parameters.AddWithValue("@Hours", parTime[0]);
            cmd.Parameters.AddWithValue("@Mins", parTime[1]);
            cmd.Connection = con;
            cmd.ExecuteNonQuery();

            using (MySqlDataReader dr = cmd.ExecuteReader())
            {
                //while (dr.Read())
                //{

                if (dr.HasRows == true) { result = "Red"; }
                if (dr.HasRows == false) { result = "Green"; }
                // a = dr.GetString("rfio");
                //  }
            }
            con.Close();


            return result;
        }
        #endregion
        public ObservableCollection<DateTime> GetListOfWorkingDays(int _docId)
        {
            MySqlConnectionStringBuilder mysqlCSB;
            mysqlCSB = new MySqlConnectionStringBuilder();
            mysqlCSB.Server = server;
            mysqlCSB.Database = database;
            mysqlCSB.UserID = UserID;
            mysqlCSB.Password = Password;
            mysqlCSB.ConvertZeroDateTime = true;

            MySqlConnection con = new MySqlConnection();
            con.ConnectionString = mysqlCSB.ConnectionString;
            MySqlCommand cmd = new MySqlCommand();

            int i = 0;

            ObservableCollection<DateTime> temp = new ObservableCollection<DateTime>();

            con.Open();
            cmd.CommandText = "SELECT dttime FROM ekfgq_ttfsp WHERE idspec = @DocID";
            cmd.Parameters.AddWithValue("@DocID", _docId);

            cmd.Connection = con;
            cmd.ExecuteNonQuery();
            using (MySqlDataReader dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {
                    i++;
                    temp.Add(dr.GetDateTime("dttime"));




                }
            }
            con.Close();

            return temp;
        }

        public static long ConvertToUnixTime(DateTime datetime)
        {
            DateTime sTime = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

            return (long)(datetime - sTime).TotalSeconds;
        }
        public void addWorkDays(string idSpec, string idUser, bool recetion, bool published, DateTime dttime, string hrtime, string mntime, string ordering, string checked_out)
        {

            MySqlConnectionStringBuilder mysqlCSB;
            mysqlCSB = new MySqlConnectionStringBuilder();
            mysqlCSB.Server = server;
            mysqlCSB.Database = database;
            mysqlCSB.UserID = UserID;
            mysqlCSB.Password = Password;
            string Id = null;
            MySqlConnection con = new MySqlConnection();
            con.ConnectionString = mysqlCSB.ConnectionString;
            MySqlCommand cmd = new MySqlCommand();

            con.Open();
            cmd.CommandText = "INSERT INTO ekfgq_ttfsp(id, idspec,iduser,reception, published, dttime,hrtime,mntime,ordering,checked_out,ttime)" +
                " VALUES(@ID,@idSpec,@idUser,@reception,@published,@dttime,@hrtime,@mntime,@ordering,@checked_out,@ttime)";
            var ttime = ConvertToUnixTime(dttime);
            cmd.Parameters.AddWithValue("@ID", Id);
            cmd.Parameters.AddWithValue("@idSpec", idSpec);
            cmd.Parameters.AddWithValue("@idUser", idUser);
            cmd.Parameters.AddWithValue("@reception", recetion);
            cmd.Parameters.AddWithValue("@published", published);
            cmd.Parameters.AddWithValue("@dttime", dttime);
            cmd.Parameters.AddWithValue("@hrtime", hrtime);
            cmd.Parameters.AddWithValue("@mntime", mntime);
            cmd.Parameters.AddWithValue("@ordering", ordering);
            cmd.Parameters.AddWithValue("@checked_out", checked_out);
            cmd.Parameters.AddWithValue("@ttime", ttime);
            cmd.Connection = con;
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void remWorkDays(string idSpec, DateTime dttime)
        {

            MySqlConnectionStringBuilder mysqlCSB;
            mysqlCSB = new MySqlConnectionStringBuilder();
            mysqlCSB.Server = server;
            mysqlCSB.Database = database;
            mysqlCSB.UserID = UserID;
            mysqlCSB.Password = Password;
            string Id = null;
            MySqlConnection con = new MySqlConnection();
            con.ConnectionString = mysqlCSB.ConnectionString;
            MySqlCommand cmd = new MySqlCommand();

            con.Open();
            cmd.CommandText = "DELETE FROM ekfgq_ttfsp WHERE idspec =@idSpec AND dttime=@dttime";
            cmd.Parameters.AddWithValue("@idSpec", idSpec);
            cmd.Parameters.AddWithValue("@dttime", dttime);
            cmd.Connection = con;
            cmd.ExecuteNonQuery();
            con.Close();
        }
        /// <summary>
        ///  Поллучение записей на конкретную дату для выбраного доктора
        /// </summary>
        /// <param name="docId">ІD доктора</param>
        /// <param name="TimeAppointments"> Дата для поиска</param>
        /// <returns></returns>

        public ObservableCollection<Appointments> GetAppointments(string docId, DateTime TimeAppointments)
        {
            MySqlConnectionStringBuilder mysqlCSB;
            mysqlCSB = new MySqlConnectionStringBuilder();
            mysqlCSB.Server = server;
            mysqlCSB.Database = database;
            mysqlCSB.UserID = UserID;
            mysqlCSB.Password = Password;
            mysqlCSB.ConvertZeroDateTime = true;

            MySqlConnection con = new MySqlConnection();
            con.ConnectionString = mysqlCSB.ConnectionString;
            MySqlCommand cmd = new MySqlCommand();

            int i = 0;

            ObservableCollection<Appointments> temp = new ObservableCollection<Appointments>();

            con.Open();
            cmd.CommandText = "SELECT * FROM ekfgq_ttfsp_dop WHERE id_specialist = @DocID AND date = @Date";
            cmd.Parameters.AddWithValue("@DocID", docId);
            cmd.Parameters.AddWithValue("@Date", TimeAppointments);
            cmd.Connection = con;
            cmd.ExecuteNonQuery();
            using (MySqlDataReader dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {
                    i++;
                    temp.Add(new Appointments
                    {
                        NumberZP = i,
                        Pacient = dr.GetString("rfio"),
                        TimeAppomination = dr.GetString("hours") + " : " + dr.GetString("minutes"),
                        Comment = "Коментар відсутній",// добавить коментарий при записис?
                        NotComing = false//вытащить с базы когда добавит димас

                    });
                }
            }
            con.Close();

            return temp;
        }

        public ObservableCollection<Users> GetUsers()
        {
            MySqlConnectionStringBuilder mysqlCSB;
            mysqlCSB = new MySqlConnectionStringBuilder();
            mysqlCSB.Server = server;
            mysqlCSB.Database = database;
            mysqlCSB.UserID = UserID;
            mysqlCSB.Password = Password;
            mysqlCSB.ConvertZeroDateTime = true;


            MySqlConnection con = new MySqlConnection();
            con.ConnectionString = mysqlCSB.ConnectionString;
            MySqlCommand cmd = new MySqlCommand();

            ObservableCollection<Users> temp = new ObservableCollection<Users>();
            con.Open();
            cmd.CommandText = "SELECT * FROM ekfgq_users";
            cmd.Connection = con;
            cmd.ExecuteNonQuery();



            using (MySqlDataReader dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {

                    temp.Add(new Users
                    {
                        userId = dr.GetString("id"),
                        userFIO = dr.GetString("name"),
                        userMail = dr.GetString("email"),
                        userPhone = dr.GetString("phone")

                    });

                }
            }
            con.Close();

            return temp;
        }


        #region INSERT IN TO BASE

        /// <summary>
        /// Запись в таблицу ekfgq_ttfsp_dop для отображения записаного талончика.
        ///  Всё что с перфиксом "_" на прямую идет в команд параметр остальные переменные переприсваиваються внутри
        /// </summary>
        /// <param name="Iduser"></param>
        /// <param name="FIOuser"></param>
        /// <param name="Userphone"></param>
        /// <param name="UserMail"></param>
        /// <param name="_date"></param>
        /// <param name="_hours"></param>
        /// <param name="_minutes"></param>
        public void INsertTheApointment(string Iduser, int _id_specialist, string FIOuser, string Userphone, string UserMail, string _specializations_name, string _specialist_name, string _specialist_email, DateTime _date, string _hours, string _minutes, string _number_cabinet = "0")
        {
            MySqlConnectionStringBuilder mysqlCSB;
            mysqlCSB = new MySqlConnectionStringBuilder();
            mysqlCSB.Server = server;
            mysqlCSB.Database = database;
            mysqlCSB.UserID = UserID;
            mysqlCSB.Password = Password;
            mysqlCSB.ConvertZeroDateTime = true;

            string tempOrder = GetNumberOrder();
            string[] tempArray = tempOrder.Split(new char[] { '-' });
            tempOrder = tempArray[0];
            #region private variables for SQLparametrs
            // int idrec; где его взять и что єто вообще
            int _iduser = Convert.ToInt32(Iduser);

            int _ordering = GetOrdering();
            string _rfio = FIOuser;
            string _rphone = Userphone;
            string _info = _date.ToShortDateString() + " " + _hours + ":" + _minutes + " <br /><u>ФИО: </u> " + _rfio + " <br /><u>Телефон: </u>" + _rphone;
            string _ipuser = "111.111.111.111";//рандомно взятый с базы
            string _rmail = UserMail;
            string _number_order = (Convert.ToInt32(tempOrder) + 1).ToString() + "-REG";
            int _cdate = 1485730860;//константа с базы
            string _office_name = "Поликлиника №4";
            //   string _specializations_name = "Терапевт";// с клача врача
            //  string _specialist_name = "витащить с класа врача";
            //   string _specialist_email = "витащить с класа врача";
            string _order_password = "V9EFJP";// скопировано с  базы возможно нужно генерировать
            string _office_address = "м.Шостка, вул. Щедрина, 1 Телефони:\r+ 38(05449) 3 - 28 - 95,\r+38(05449) 3 - 23 - 52";
            //   int _number_cabinet = 4;
            #endregion


            UpdateInToBase(_iduser, _rfio, _rphone, _info, _ipuser, _rmail, _id_specialist, _date, _hours, _minutes);
            using (MySqlConnection con = new MySqlConnection(mysqlCSB.ConnectionString))
            {
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    cmd.Connection = con;

                    con.Open();


                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText =
                    "INSERT INTO ekfgq_ttfsp_dop(iduser, id_specialist, ordering, rfio, rphone, info, ipuser, rmail, number_order, cdate, date, hours, minutes, office_name, specializations_name, specialist_name, specialist_email, order_password, office_address, number_cabinet) " +
                    "VALUES(@iduser, @id_specialist, @ordering, @rfio, @rphone, @info, @ipuser, @rmail, @number_order, @cdate, @date, @hours, @minutes, @office_name, @specializations_name, @specialist_name, @specialist_email, @order_password, @office_address, @number_cabinet)";

                    #region Command Parametrs

                    cmd.Parameters.AddWithValue("@iduser", _iduser);
                    cmd.Parameters.AddWithValue("@id_specialist", _id_specialist);
                    cmd.Parameters.AddWithValue("@ordering", _ordering);
                    cmd.Parameters.AddWithValue("@rfio", _rfio);
                    cmd.Parameters.AddWithValue("@rphone", _rphone);
                    cmd.Parameters.AddWithValue("@info", _info);
                    cmd.Parameters.AddWithValue("@ipuser", _ipuser);
                    cmd.Parameters.AddWithValue("@rmail", _rmail);
                    cmd.Parameters.AddWithValue("@number_order", _number_order);
                    cmd.Parameters.AddWithValue("@cdate", _cdate);
                    cmd.Parameters.AddWithValue("@date", _date);
                    cmd.Parameters.AddWithValue("@hours", _hours);
                    cmd.Parameters.AddWithValue("@minutes", _minutes);
                    cmd.Parameters.AddWithValue("@office_name", _office_name);
                    cmd.Parameters.AddWithValue("@specializations_name", _specializations_name);
                    cmd.Parameters.AddWithValue("@specialist_name", _specialist_name);
                    cmd.Parameters.AddWithValue("@specialist_email", _specialist_email);
                    cmd.Parameters.AddWithValue("@order_password", _order_password);
                    cmd.Parameters.AddWithValue("@office_address", _office_address);
                    cmd.Parameters.AddWithValue("@number_cabinet", _number_cabinet);

                    #endregion

                    cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();



                }
            }


        }

        /// <summary>
        /// Обновление  таблицы ekfgq_ttfsp для отобреженя занятого талона на сайте
        /// </summary>
        public void UpdateInToBase(int _iduser, string _rfio, string _rphone, string _info, string _ipuser, string _rmail, int _idspec, DateTime _dttime, string _hours, string _minutes)
        {

            MySqlConnectionStringBuilder mysqlCSB;
            mysqlCSB = new MySqlConnectionStringBuilder();
            mysqlCSB.Server = server;
            mysqlCSB.Database = database;
            mysqlCSB.UserID = UserID;
            mysqlCSB.Password = Password;
            mysqlCSB.ConvertZeroDateTime = true;




            using (MySqlConnection con = new MySqlConnection(mysqlCSB.ConnectionString))
            {
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    cmd.Connection = con;

                    con.Open();


                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "UPDATE ekfgq_ttfsp SET iduser=@iduser, reception='1', rfio=@rfio, rphone=@rphone, info=@info, ipuser=@ipuser, rmail=@rmail" +
                        " WHERE idspec=@idspec AND dttime=@dttime AND hrtime=@hrtime AND mntime=@mntime";

                    #region Command Parametrs

                    cmd.Parameters.AddWithValue("@iduser", _iduser);
                    cmd.Parameters.AddWithValue("@rfio", _rfio);
                    cmd.Parameters.AddWithValue("@rphone", _rphone);
                    cmd.Parameters.AddWithValue("@info", _info);
                    cmd.Parameters.AddWithValue("@ipuser", _ipuser);
                    cmd.Parameters.AddWithValue("@rmail", _rmail);
                    cmd.Parameters.AddWithValue("@idspec", _idspec);
                    cmd.Parameters.AddWithValue("@dttime", _dttime);
                    cmd.Parameters.AddWithValue("@hrtime", _hours);
                    cmd.Parameters.AddWithValue("@mntime", _minutes);

                    #endregion

                    cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();



                }
            }


        }
        /// <summary>
        /// получение  максимального значнеия поредяка для записи в базу
        /// </summary>
        /// <returns></returns>
        private int GetOrdering()
        {
            MySqlConnectionStringBuilder mysqlCSB;
            mysqlCSB = new MySqlConnectionStringBuilder();
            mysqlCSB.Server = server;
            mysqlCSB.Database = database;
            mysqlCSB.UserID = UserID;
            mysqlCSB.Password = Password;
            mysqlCSB.ConvertZeroDateTime = true;

            MySqlConnection con = new MySqlConnection();
            con.ConnectionString = mysqlCSB.ConnectionString;
            MySqlCommand cmd = new MySqlCommand();

            int i = 0;

            con.Open();
            cmd.CommandText = "SELECT ordering FROM ekfgq_ttfsp_dop WHERE ordering = (SELECT MAX(ordering) FROM  ekfgq_ttfsp_dop )";
            cmd.Connection = con;
            cmd.ExecuteNonQuery();
            using (MySqlDataReader dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {
                    i = Convert.ToInt32(dr.GetString("ordering"));
                }
            }
            con.Close();

            return i + 1;
        }

        /// <summary>
        /// Получение  последнего "number order" для записи в базу
        /// </summary>
        private int _ILimit = 1;
        private string GetNumberOrder()
        {
            MySqlConnectionStringBuilder mysqlCSB;
            mysqlCSB = new MySqlConnectionStringBuilder();
            mysqlCSB.Server = server;
            mysqlCSB.Database = database;
            mysqlCSB.UserID = UserID;
            mysqlCSB.Password = Password;
            mysqlCSB.ConvertZeroDateTime = true;

            MySqlConnection con = new MySqlConnection();
            con.ConnectionString = mysqlCSB.ConnectionString;
            MySqlCommand cmd = new MySqlCommand();

            string temp = null;
            con.Close();
            con.Open();
            cmd.CommandText = "SELECT number_order FROM ekfgq_ttfsp_dop ORDER BY id DESC LIMIT @ILimit";
            cmd.Parameters.AddWithValue("@ILimit", _ILimit);
            cmd.Connection = con;
            cmd.ExecuteNonQuery();
            using (MySqlDataReader dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {

                    temp = dr.GetString("number_order");
                }
            }

            con.Close();
            //проверка если номер порядка пустой возьми на одну запись больше
            if (temp == "")
            {
                _ILimit = _ILimit + 1;

                temp = GetNumberOrder();
            }

            return temp;



        }
        /// <summary>
        /// Обновление поля в таблице которое отвечает за отображенье приема врача (По времени/По талонам)
        /// </summary>
        /// <param name="_docid"></param>
        /// <param name="_parametr"> Росписнаие : True - по талонам false - по времени</param>
        public void InsertTalonTime(int _docid, bool _parametr)
        {
            MySqlConnectionStringBuilder mysqlCSB;
            mysqlCSB = new MySqlConnectionStringBuilder();
            mysqlCSB.Server = server;
            mysqlCSB.Database = database;
            mysqlCSB.UserID = UserID;
            mysqlCSB.Password = Password;
            mysqlCSB.ConvertZeroDateTime = true;




            using (MySqlConnection con = new MySqlConnection(mysqlCSB.ConnectionString))
            {
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    cmd.Connection = con;

                    con.Open();


                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "UPDATE talon_time SET parametr=@parametr" +
                        " WHERE doctor_id=@doctor_id ";

                    #region Command Parametrs


                    cmd.Parameters.AddWithValue("@parametr", _parametr);
                    cmd.Parameters.AddWithValue("@doctor_id", _docid);

                    #endregion

                    cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();



                }
            }
        }

        #endregion


        public conBD(string Server, string Database, string userid, string pass)
        {
            server = Server;
            database = Database;
            UserID = userid;
            Password = pass;
        }


    }
}
