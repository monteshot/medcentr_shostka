using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using kepkaSQL;
using System.Collections.Generic;
using System.Windows;
using System.Linq;
using WPF_Hospital;
using System;

namespace VrachMedcentr
{
    class CardPages : INotifyPropertyChanged
    {
        #region Helpers Class Object
        private DateTime _dateBorn;
        private string comboboxtext;
        private string selectedFIO;
        private DateTime thisDay = DateTime.Today;
        private DataTable TestTable = new DataTable();
        private connect con = new connect();
        //private ObservableCollection<CardPageOne> ListOfUsers;//что это?
        CardPageTwo PageTwo = new CardPageTwo();

        private CardPageOne _KARTA;

        private Appointments _AppSelectedUser;
        public Appointments AppSelectedUser
        {
            get
            {
                return _AppSelectedUser;
            }
            set
            {
                _AppSelectedUser = value;
                string r = "fafsafs";
            }
        }
        public CardPageOne KARTA
        {
            get
            {

                return _KARTA;

            }
            set
            {
                _KARTA = value;
                NumberPacient = _KARTA.NumberPacient;

            }
        }
        public CardPageTwo Card2 { get; set; }
        public ObservableCollection<Sheplenya> Shepl { get; set; }
        public ObservableCollection<Profilact> Profilact { get; set; }
        public ObservableCollection<CardPageThree> Card3 { get; set; }
        public ObservableCollection<CardPageFour> Card4 { get; set; }
        public ObservableCollection<CardPageFive> Card5 { get; set; }
        #endregion


        #region Constructor

        public CardPages()
        {

               NumCard("473");

        }

        //    foreach (var a in ListOfUsers)
        //    {
        //        OneTimeUsers.Add(a.userFIO);
        //    }   

        //}
        #endregion
        public void updScr()
        {
            MainWindow MW = new MainWindow();
            MW.Shelpennya.UpdateLayout();

        }
        public void NumCard(string inp) //вызывать этот метод по клику на пациента
        {
            KARTA = con.karta(inp);
            Card2 = con.signPozn(inp);
            Shepl = con.shepl(inp);
            Profilact = con.profilact(inp);
            Card3 = con.DiagList(inp);
            Card4 = con.rentgen(inp);
            Card5 = con.diary(inp);

            // updScr();
        }
        #region Data_pages
        /// <summary>
        /// Page 1
        /// </summary>
        public string CodeZYCD { get; set; }




        public string PreferentNumber { get; set; }
        public DataTable AccountingTable { get; set; }

        public string CodeZKPO { get; set; }
        public string NumberPacient { get; set; }
        public string CodePacient { get; set; }
        public DateTime dateBirth { get; set; } = DateTime.Today;
        public DateTime DateCardWriten { get => thisDay; set => thisDay = value; }
        public string Sername { get; set; }
        public string Name { get; set; }
        public string FathersName { get; set; }
        public bool Sex { get; set; }

        //public bool SexFaMale { get; set; }
        //public bool SexMale { get; set; }

        public string Adress { get; set; }
        public string LeavingPlace { get; set; }
        public string WorkingPlace { get; set; }
        public bool Dispensary { get; set; }

        //public bool DispersedGroupYes { get; set; }
        //public bool DispersedGroupNo { get; set; }
        /// <summary>
        /// data ObservableCollection
        /// </summary>
        /// 
      //  public CardPageOne KARTA { get; set; }
        public ObservableCollection<OblickTable> Phones { get; set; }
        public ObservableCollection<CardPageFive> Dilery { get; set; }
        public ObservableCollection<CardPageThree> Diagnosis { get; set; }
        private ObservableCollection<string> OneTimeUsers = new ObservableCollection<string>();// переменная для представления ФИО юзверей в комбобоксе  
        public ObservableCollection<string> Users { get; set; }
        public string S_FirstName { get; set; }
        public string S_LastName { get; set; }
        private Users SelectedUser;

        private ObservableCollection<Users> ListOfUsers;//переменная для считыванья списка юзверей единожди при запуске програмы
        private ObservableCollection<CardUsers> ListOfUsers1 = new ObservableCollection<CardUsers>();
        public DateTime S_DateBorn
        {
            get
            {
                return _dateBorn;
            }
            set
            {
                _dateBorn = value;
                //for (int i = 0; i < 100; i++)
                //{
                //    ListOfUsers1.Add(new CardUsers { userFIO = i.ToString() + "Valera" + value.ToString() });
                //}
                ListOfUsers1 = con.GetCardUsersList(value);

                foreach (var a in ListOfUsers1)
                {
                    OneTimeUsers.Add(a.userFIO);
                }
                Users = OneTimeUsers;
            }

        }
        /// <summary>
        /// умный поиск по комбобоксу
        /// </summary>
        public string ComboboxText
        {
            get
            {
                return comboboxtext;
            }
            set
            {

                if (value != "")
                {
                    comboboxtext = value;
                    //ComboBoxDropDown = true;
                    //IsTextSearchEnabled = false;
                    var FiltredUsers = from Users in OneTimeUsers where Users.Contains(value) select Users;
                    ObservableCollection<string> temps = new ObservableCollection<string>();
                    foreach (var a in FiltredUsers)
                    {
                        temps.Add(a);
                    }
                    Users = temps;
                    if (!Users.Contains(value))
                    {
                        SelectedUser = new Users { userFIO = value, userId = "007", userMail = "registratura@coworking.com", userPhone = "8-800-555-35-35" };
                    }


                }
                else
                {
                    comboboxtext = value;
                    //ComboBoxDropDown = false;
                    //IsTextSearchEnabled = false;
                    Users = OneTimeUsers;
                }
            }
        }

        /// <summary>
        /// Выбор юзера по выбраному фио из комбобокса
        /// </summary>
        public string SelectedFIO
        {
            get
            {
                return selectedFIO;
            }
            set
            {
                selectedFIO = value;
                comboboxtext = value;
                //Возможно нужна проверка на полное совпадение если таково бредусмотрено базой
                foreach (var a in ListOfUsers)
                {
                    if (a.userFIO == value)
                    {
                        SelectedUser = a;
                    }
                }



            }
        }

        public bool ComboBoxDropDown { get; set; } = false;

        public bool IsTextSearchEnabled { get; set; } = false;
        /// <summary>
        /// комнада для теста биндингов вложеных дата контекстов
        /// </summary>
        private RelayCommand _TestCP;
        public RelayCommand TestCP
        {
            get
            {
                return _TestCP ??
                  (_TestCP = new RelayCommand(obj =>
                  {
                      KARTA = con.karta("473");
                  }));
            }
        }
        private RelayCommand _SearchPat;
        public RelayCommand SearchPat
        {
            get
            {
                return _SearchPat ??
                  (_SearchPat = new RelayCommand(obj =>
                  {
                      // KARTA = con.karta(sSelectedUser.IDUser);
                      // KARTA= con.karta();
                      //KARTA = con.karta(S_FirstName, S_LastName, S_DateBorn);
                      //KARTA = con;
                      //MessageBox.Show(S_FirstName+" "+ S_LastName);
                      //    MessageBox.Show(SUser.IDUser);
                      _KARTA = con.karta(SUser.IDUser);
                      // MessageBox.Show(KARTA.Name + " " + KARTA.Sername);
                  }));
            }
        }
        //  Appointments SELUSER { get; set; }
        connect localDB = new connect();
        private Appointments _SUser;
        public Appointments SUser
        {
            get { return _SUser; }
            set
            {
                _SUser = value;

                NumCard(_SUser.IDUser);// вроде работает но UI не меняется
                MessageBox.Show("Вытянул с базы:\n" + KARTA.Name + " " + KARTA.Sername);// работает
            }
        }



        //private Appointments _SelectedUser;
        //public Appointments sSelectedUser
        //{
        //    get
        //    {
        //        return _SelectedUser;
        //    }
        //    set
        //    {
        //        _SelectedUser = value;

        //        // CardPages CP = new CardPages();
        //        //   CP._SSelectedUser = _SSelectedUser;
        //        //   KARTA = localDB.karta(_SelectedUser.IDUser);
        //        // CP._SSelectedUser = _SSelectedUser;
        //        //_SSelectedUser.IDUser;
        //        //   MessageBox.Show(_SelectedUser.IDUser);
        //    }
        //}

        /// <summary>
        /// Page 2
        /// </summary>
        public string Shugar { get; set; } = "gsdgsgdg";
        public string InfectiousDis { get; set; }
        public string AlergiAnam { get; set; }
        public string IntoleranceToDrugs { get; set; }

        //public string SShuger { get => PageTwo.Shugar; set => PageTwo.Shugar=value; }
        #endregion

        #region Helpers method



        #region Private Command
        /// <summary>
        /// Command From View
        /// </summary>

        private RelayCommand insert;
        private RelayCommand dileryread;
        private RelayCommand readP3;
        private RelayCommand addCommand;

        #endregion
        //какаето тестовая команда
        public RelayCommand AddCommand
        {
            get
            {
                return addCommand ??
                  (addCommand = new RelayCommand(obj =>
                  {
                      //Setter();
                      CodeZYCD = "jk;j;k";
                  }));
            }
        }

        /// <summary>
        /// Command for Dilery
        /// </summary>
        //public RelayCommand DileryInsert
        //{
        //    get
        //    {
        //        return insert ??
        //          (insert = new RelayCommand(obj =>
        //          {
        //              Dilery.Add(new CardPageFive { ComingDate = "0.10231", HealingPlace = "hospital", Diagnosis = "live", Stamp = "podps" });
        //              //con.UpdateDileryBase(Dilery);
        //              Setter();
        //          }));
        //    }
        //}
        //public RelayCommand DileryRead
        //{

        //    get
        //    {
        //        return dileryread ??
        //          (dileryread = new RelayCommand(obj =>
        //          {
        //             // Dilery = con.ReadDileryList();
        //              Setter();
        //          }));
        //    }

        //}

        //public RelayCommand DileryRead
        //{
        //    get
        //    {
        //        return read ??
        //          (read = new RelayCommand(obj =>
        //          {
        //              Dilery = con.ReadDileryList();
        //              Setter();
        //          }));
        //    }
        //}

        public RelayCommand ReadP3
        {
            get
            {
                return readP3 ??
                  (readP3 = new RelayCommand(obj =>
                  {

                      //   Diagnosis = con.DiagList();
                  }));
            }
        }

        public RelayCommand UpdateP3
        {
            get
            {
                return readP3 ??
                  (readP3 = new RelayCommand(obj =>
                  {
                      con.UpdateP3(Diagnosis);

                  }));
            }
        }



        //public RelayCommand InsertP3
        //{
        //    get
        //    {
        //        return insert ??
        //          (insert = new RelayCommand(obj =>
        //          {
        //              Dinery.Add(new CardPageThree { ComingDate = "0.10231", HealingPlace = "hospital", Diagnosis = "live", Stamp = "podps" });
        //              con.Tetslist1(Dinery);
        //          }));
        //    }
        //}


        public void Setter()

        {

            Adress = "fasfasf";
        }


        #endregion

        #region Event
        /// <summary>
        ///  Property changed event
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged = (sender, e) =>
        {
        };

        #endregion


    }

}

