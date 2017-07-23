using kepkaSQL;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;

using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

using System.Windows.Input;
using VrachMedcentr.HelpersClass.MyHalpers;

namespace VrachMedcentr
{
    class regViewModel : INotifyPropertyChanged
    {
        /// <summary>
        /// Здесь лежат все приватные переменные для роскрития сетеров 
        /// </summary>
        #region Private Variables


        private string comboboxtext;
        private string selectedFIO;
        private bool timehour;
        private DateTime dateDoctorAcepting;
        private ObservableCollection<string> OneTimeUsers = new ObservableCollection<string>();// переменная для представления ФИО юзверей в комбобоксе  
        private ObservableCollection<Times> OneTimeDoctorTimes = new ObservableCollection<Times>();
        private ObservableCollection<Users> ListOfUsers;//переменная для считыванья списка юзверей единожди при запуске програмы
        public ObservableCollection<DateTime> Otemp { get; set; }
        private Users SelectedUser;
        #endregion

        #region Public Variables


        public DoctorsList SelectedDoc { get; set; }
        //   public Times SelectedTime { get; set; }
        public ObservableCollection<Appointments> Appointments { get; set; }
        public List<DoctorsList> ListOfSpecf { get; set; }
        public ObservableCollection<DocNames> ListOfDocNames { get; set; }

        public ObservableCollection<Times> DoctorTimes { get; set; }
        // public ObservableCollection<Times> DoctorTimes { get; set; }
        public ObservableCollection<string> Users { get; set; }
        public ObservableCollection<DateTime> WorkingDays { get; set; }
        private Users _SSelectedUser;
        public Users SSelectedUser
        {
            get
            {
                return _SSelectedUser;
            }
            set
            {
                _SSelectedUser = value;
                MessageBox.Show(_SSelectedUser.userFIO);
            }
        }

        public string teststring { get; set; }//тесовый стринг
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
                    // IsTextSearchEnabled = false;
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
        /// При изменении состояния чек бокса при True-отображаеться росписнаие по талонам при false - росписание по времени
        /// </summary>
        public bool TimeHour
        {
            get { return timehour; }
            set
            {
                timehour = value;
                int i = 0;
                if (TimeHour == true)
                {
                    try
                    {
                        //int i = 0;
                        ObservableCollection<Times> temp = new ObservableCollection<Times>();

                        foreach (var a in DoctorTimes)
                        {
                            i++;
                            temp.Add(new Times { Status = a.Status, Time = "Talon №" + i.ToString(), TimeProperties = a.TimeProperties });
                        }
                        DoctorTimes = temp;

                    }

                    catch (Exception)
                    {
                        MessageBox.Show("Для лікаря " + SelectedDocNames.docName + " графік прийому відсутній");
                    }
                }
                else
                {
                    try
                    {
                        RefreshDocTimes();
                    }
                    catch
                    {
                        // MessageBox.Show("Лікар не вибраний");
                    }
                }
            }
        }

        public Times SelectedTime { get; set; }//выбраное время

        public DateTime DateDoctorAcepting
        {
            get
            {
                return dateDoctorAcepting;
            }
            set
            {
                dateDoctorAcepting = value;
                int i = 0;
                try
                {
                    if (TimeHour == false)
                    {
                        RefreshDocTimes();
                    }
                    if (TimeHour == true)
                    {
                        if (WorkingDays.Contains(value))
                        {
                            try
                            {
                                //int i = 0;
                                ObservableCollection<Times> temp = new ObservableCollection<Times>();
                                ObservableCollection<Times> tempList = con.getDocTimes(SelectedDocNames.docID, SelectedDocNames.docTimeId, DateDoctorAcepting);
                                foreach (var a in tempList)
                                {
                                    i++;
                                    temp.Add(new Times { Status = a.Status, Time = "Талон №" + i.ToString(), TimeProperties = a.TimeProperties });
                                }
                                DoctorTimes = temp;

                            }

                            catch (Exception)
                            {
                                MessageBox.Show("Для лікаря " + SelectedDocNames.docName + " графік прийому відсутній");
                            }
                        }
                        else
                        {
                            RefreshDocTimes();
                        }
                    }
                    Appointments = con.GetAppointments(SelectedDocNames.docID, value);

                }
                catch { }


            }
        }


        //       public string teststring { get; set; }
        //     public ObservableCollection<Times> DoctorTimes { get; set; }
        private DoctorsList _SelectedSpecf;
        public DoctorsList SelectedSpecf
        {
            get { return _SelectedSpecf; }
            set
            {
                _SelectedSpecf = value;

                ListOfDocNames = con.GetDoctrosNames(value.idspecf.ToString());
            }
        }
        private DocNames _SelectedDocNames;
        public DocNames SelectedDocNames
        {
            get { return _SelectedDocNames; }
            set
            {
                _SelectedDocNames = value;

                //подавляем екзепшены так как при выборе специальности DocNames становиться null
                try
                {
                    Otemp = con.GetListOfWorkingDays(Convert.ToInt32(value.docID));
                    TimeHour = con.GetDocTimeTalonStatus(Convert.ToInt32(value.docID));
                    WorkingDays = con.GetListOfWorkingDays(Convert.ToInt32(value.docID));
                    //if (SelectedDocNames.docTimeId == "0" && SelectedDocNames.docTimeId == null || WorkingDays.Contains(DateDoctorAcepting)==false)
                    RefreshDocTimes();
                    Appointments = con.GetAppointments(SelectedDocNames.docID, DateDoctorAcepting);//  DateTime.Parse("2017-07-07"));
                    // TimeHour = value.docBool; // присваивать значение с статуса врача
                    // КОСТІЛЬ ПЕРЕДЕЛАТЬ ИЗМЕНИТЬ СЧИТІВАНЬЕ ЛИСТА С СПЕЦИФИКАЦИЯМИ И ВРАЧАМИ (Спросить у ИЛЬИ)

                }
                catch { }
            }
        }


        #endregion

        #region Helpers object
        conBD con = new conBD();

        #endregion

        #region Constructor

        public regViewModel()
        {


            DateDoctorAcepting = DateTime.Today;
            ListOfSpecf = con.getList();
            ListOfUsers = con.GetUsers();


            Users = OneTimeUsers;


            foreach (var a in ListOfUsers)
            {
                OneTimeUsers.Add(a.userFIO);
            }
            DoctorTimes = new ObservableCollection<Times>();
            try
            {
                DoctorTimes = con.getDocTimes(SelectedDocNames.docID, SelectedDocNames.docTimeId, DateDoctorAcepting);
                OneTimeDoctorTimes = DoctorTimes;
            }
            catch { }


        }

        #endregion

        //  public DoctorsList.DocNames sas { get; set; }
        //  WPF_Hospital.MainWindow a = new WPF_Hospital.MainWindow();


        #region Helpers method and command

        /// <summary>
        /// Метод для обновления росписания врача с проверкой на робочи/не робочий день
        /// </summary>
        private void RefreshDocTimes()
        {
            try
            {

                if (con.CheckDoctorList(SelectedDocNames.docTimeId))
                {
                    if (SelectedDocNames.docTimeId == "0" || WorkingDays.Contains(DateDoctorAcepting) == false)
                    {

                        DoctorTimes = new ObservableCollection<Times>();
                        DoctorTimes.Add(new Times { Time = "Не робочій день", Status = "Red" });
                    }
                    else
                    {
                        DoctorTimes = con.getDocTimes(SelectedDocNames.docID, SelectedDocNames.docTimeId, DateDoctorAcepting);
                    }
                }
                else
                {
                    DoctorTimes = null;
                    if (SelectedDocNames != null || con.CheckDoctorList(SelectedDocNames.docTimeId))
                    {
                        MessageBox.Show("Для лікаря " + SelectedDocNames.docName + " графік прийому відсутній", "Прийом відсутній", MessageBoxButton.OK, MessageBoxImage.Information);
                        edDaysMethod();
                    }
                }

            }
            catch (Exception e)
            {
                //Розкомнетить для отладки
                //MessageBox.Show(e.ToString());
            }
        }


        public void edTimesMethod()
        {
            EditTime TimeEditing = new EditTime();

            EditTimesViewModel VMEditTime = new EditTimesViewModel();
            TimeEditing.DataContext = VMEditTime;
            VMEditTime.docSelected = SelectedDocNames;
            ObservableCollection<Times> BackUPdocTimes = new ObservableCollection<Times>(); // не менять на лист, ибо не будет обновлятся вью расписания
            try
            {
                DoctorTimes = con.getDocTimes(SelectedDocNames.docID, SelectedDocNames.docTimeId, DateDoctorAcepting);
                foreach (var a in DoctorTimes)
                {
                    BackUPdocTimes.Add(new Times { Time = a.Time, Status = a.Status });
                }

                VMEditTime.docTimes = DoctorTimes;
                //DoctorTimes = VMEditTime.temperory;

            }
            catch (Exception) { }
            try { TimeEditing.ShowDialog(); }
            catch { }

            //следующая команда срабатывает после закрытия диалогового окна
            // СУПЕР КОСТЫЛЬ СДЕЛАТЬ БЫ ПОЛЮДСКИ (роботает по принцыпу -  строчка выполняеться после того как закрлось окно редактирвоанья)
            // сделать бы нормлаьную передачу данных и команд между формами.
            try
            {
                WorkingDays = con.GetListOfWorkingDays(Convert.ToInt32(SelectedDocNames.docID));

                if (con.CheckDoctorList(SelectedDocNames.docTimeId))
                {
                    if (SelectedDocNames.docTimeId == "0" || WorkingDays.Contains(DateDoctorAcepting) == false)
                    {

                        DoctorTimes = new ObservableCollection<Times>();
                        DoctorTimes.Add(new Times { Time = "Не робочій день", Status = "Red" });
                    }
                    else
                    {
                        DoctorTimes = con.getDocTimes(SelectedDocNames.docID, SelectedDocNames.docTimeId, DateDoctorAcepting);
                    }
                }
                else
                {
                    DoctorTimes = null;

                }

                TimeHour = SelectedDocNames.docBool;
                //DoctorTimes = con.getDocTimes(SelectedDocNames.docID, SelectedDocNames.docTimeId, DateDoctorAcepting);
            }
            catch (Exception) { }
        }

        private RelayCommand _conf;

        public RelayCommand Conf
        {
            get
            {
                return _conf ??
                  (_conf = new RelayCommand(obj =>
                  {
                      try
                      {
                          string mess = "Ви дійсно хочете записати на прийом пацієнта " + SelectedUser.userFIO + " до лікаря " + SelectedDocNames.docName;
                          string capt = "Запис на прийом до лікаря " + SelectedDocNames.docName;

                          if (SelectedTime.Status == "Green")
                          {
                              var result = MessageBox.Show(mess, capt, MessageBoxButton.YesNo, MessageBoxImage.Question);

                              if (result == MessageBoxResult.No) { }
                              if (result == MessageBoxResult.Yes)
                              {
                                  //запись на прием хере!

                                  string temp1 = ComboboxText;
                                  string[] temp = SelectedTime.Time.Split(new char[] { ':' });
                                  con.INsertTheApointment(SelectedUser.userId, Convert.ToInt32(SelectedDocNames.docID), SelectedUser.userFIO, SelectedUser.userPhone, SelectedUser.userMail,
                                      SelectedSpecf.specf, SelectedDocNames.docName, SelectedDocNames.docEmail, DateDoctorAcepting, temp[0], temp[1], SelectedDocNames.docCab);
                                  Appointments = con.GetAppointments(SelectedDocNames.docID, DateDoctorAcepting);
                                  DoctorTimes = con.getDocTimes(SelectedDocNames.docID, SelectedDocNames.docTimeId, DateDoctorAcepting);
                                  OneTimeDoctorTimes = DoctorTimes;


                              }

                          }
                          //Appointments = con.GetAppointments(SelectedDoctor.docID, DateDoctorAcepting);
                          // teststring = SelectedDoctor.docID;
                          else
                          {
                              MessageBox.Show("Час зайнято");
                          }
                      }
                      catch
                      {
                          MessageBox.Show("Перевірте правильність введення данних");
                      }

                  }));
            }
        }
        private RelayCommand _EditTimes;
        public RelayCommand EditTimes
        {
            get
            {
                return _EditTimes ??
                  (_EditTimes = new RelayCommand(obj =>
                  {
                      edTimesMethod();
                  }));
            }
        }
        connect localDB = new connect();
        string S_LastName { get; set; }
        string S_FirstName { get; set; }
        DateTime S_DateBorn { get; set; }
        private RelayCommand _SearchUsers;
        public RelayCommand SearchUsers
        {
            get
            {
                return _SearchUsers ??
                  (_SearchUsers = new RelayCommand(obj =>
                  {
                     
                      localDB.karta(S_FirstName, S_LastName, S_DateBorn);


                      //SearchUsersCard SearchView = new SearchUsersCard();
                      //selectedSearchVM sSVM = new selectedSearchVM();


                      //SearchView.DataContext = sSVM;
                      //// sSVM = SelectedDocNames;

                      //ObservableCollection<Times> BackUPdocTimes = new ObservableCollection<Times>(); // не менять на лист, ибо не будет обновлятся вью расписания



                      //try { SearchView.ShowDialog(); }
                      //catch { }




                  }));
            }
        }
        public void edDaysMethod()
        {
            editDays daysEditing = new editDays();

            EditDayViewModel VMEditDays = new EditDayViewModel();
            daysEditing.DataContext = VMEditDays;
            VMEditDays.docSelected = SelectedDocNames;

            ObservableCollection<Times> BackUPdocTimes = new ObservableCollection<Times>(); // не менять на лист, ибо не будет обновлятся вью расписания
            try
            {
                foreach (var a in DoctorTimes)
                {
                    BackUPdocTimes.Add(new Times { Time = a.Time, Status = a.Status });
                }

                VMEditDays.docTimes = BackUPdocTimes;
                VMEditDays.WorkDays = WorkingDays;
                //DoctorTimes = VMEditTime.temperory;

            }
            catch (Exception) { }
            // ObservableCollection<Times> BackUPdocTimes = new ObservableCollection<Times>(); // не менять на лист, ибо не будет обновлятся вью расписания
            //try
            //{
            //    foreach (var a in DoctorTimes)
            //    {
            //        BackUPdocTimes.Add(new Times { Time = a.Time, Status = a.Status });
            //    }

            //    VMEditTime.docTimes = BackUPdocTimes;
            //    //DoctorTimes = VMEditTime.temperory;

            //}
            //catch (Exception) { }
            try { daysEditing.ShowDialog(); }
            catch { }
        }
        private RelayCommand _editDays;
        public RelayCommand editDays
        {
            get
            {
                return _editDays ??
                  (_editDays = new RelayCommand(obj =>
                  {


                      edDaysMethod();


                  }));
            }
        }


        /// <summary>
        /// команда на биндинг события для изменения сосотояния чекбокса с ЗАНЕСЕНИЕМ ИЗМЕЕНИЙ В БАЗУ
        /// </summary>
        private RelayCommand _CheckBoxChenged;
        public RelayCommand CheckBoxChenged
        {
            get
            {
                return _CheckBoxChenged ??
                  (_CheckBoxChenged = new RelayCommand(obj =>
                  {

                      //SelectedDocNames.docBool = TimeHour;                   
                      // ListOfDocNames = con.GetDoctrosNames(SelectedSpecf.idspecf.ToString());
                      try
                      {
                          con.InsertTalonTime(Convert.ToInt32(SelectedDocNames.docID), TimeHour);

                      }
                      catch
                      {

                      }




                  }));
            }
        }
        private RelayCommand _test;
        public RelayCommand Test
        {
            get
            {
                return _test ??
                  (_test = new RelayCommand(obj =>
                  {
                      //CheckBoxChanged();
                      MessageBox.Show("sasdasdasd");
                      string fasfgafs = "fasgfa";
                  }));
            }
        }


        #endregion


        //}
        #region ICommand region for Selected Item in treView
        //   private static object _selectedItem = null;
        // This is public get-only here but you could implement a public setter which
        // also selects the item.
        // Also this should be moved to an instance property on a VM for the whole tree, 
        // otherwise there will be conflicts for more than one tree.

        //private ICommand _selectedItemChangedCommand;
        //public ICommand SelectedItemChangedCommand
        //{
        //    get
        //    {
        //        DoctorsList.DocNames SelectedDoctor = new DoctorsList.DocNames();
        //        if (_selectedItemChangedCommand == null)
        //            teststring = SelectedDoctor.docID;
        //        _selectedItemChangedCommand = new RelayCommand(args => SelectedItemChanged(args));

        //        return _selectedItemChangedCommand;
        //    }
        //}
        public string docIdBackup { get => docIdPrivate; set { } }
        private string docIdPrivate;
        public void docIdBehind(DocNames s)
        {
            docIdBackup = s.docID;
            docIdPrivate = s.docID;

            // return null;
        }

        //public void SelectedItemChanged(object args)

        //{


        //    SelectedItem = args;
        //    try
        //    {

        //        DateDoctorAcepting = DateTime.Today;
        //        DoctorsList.DocNames SelectedDoctor = new DoctorsList.DocNames();
        //        SelectedDoctor = (DoctorsList.DocNames)args;
        //        //    Appointments = con.GetAppointments(SelectedDoctor.docID, DateTime.Today);
        //        //IDLik = SelectedDoctor.docID;

        //        teststring = SelectedDoctor.docID;
        //        //  docIdBackup = (string)SelectedItem;
        //        // docIdBackup = teststring;
        //    }
        //    catch { }



        //}

        //public object SelectedItem
        //{
        //    get { return _selectedItem; }
        //    private set
        //    {
        //        if (_selectedItem != value)
        //        {
        //            //  DoctorTimes = con.getDocTimes( , DateDoctorAcepting);
        //            _selectedItem = value;
        //        }

        //    }
        //}


        //private bool _isSelected;
        //public bool IsSelected
        //{
        //    get { return _isSelected; }
        //    set
        //    {
        //        if (_isSelected != value)
        //        {
        //            _isSelected = value;
        //            this.OnPropertyChanged("IsSelected");
        //            if (_isSelected)
        //            {
        //                SelectedItem = this;
        //            }
        //        }
        //    }
        //}
        #endregion

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            var handler = this.PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

