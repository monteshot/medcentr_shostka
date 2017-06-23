using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using kepkaSQL;
using System.Collections.Generic;

namespace VrachMedcentr
{
    class CardPages : INotifyPropertyChanged
    {
        #region Helpers Class Object

        private DateTime thisDay = DateTime.Today;
        private DataTable TestTable = new DataTable();
        private connect con = new connect();
               
        //CardPageTwo PageTwo = new CardPageTwo();

        #endregion
        #region Constructor

        public CardPages()
        {
            Dilery = new ObservableCollection<CardPageFive>
            {
                new CardPageFive{ ComingDate  = "fasfafsa", HealingPlace="fasfas", Diagnosis="podox", Stamp="fasdfas"}
            };
        }
        #endregion
      
        #region Data_pages
        /// <summary>
        /// Page 1
        /// </summary>
        public string CodeZYCD { get; set; }
        public string CodeZKPO { get; set; }
        public string NumberPacient { get; set; }
        public string CodePacient { get; set; }
        public DateTime DateCardWriten { get => thisDay; set => thisDay = value; }
        public string Sername { get; set; }
        public string Name { get; set; }
        public string FathersName { get; set; }
        public bool SexFaMale { get; set; }
        public bool SexMale { get; set; }
        public string Adress { get; set; }
        public string LeavingPlace { get; set; }
        public string WorkingPlace { get; set; }
        public bool DispersedGroupYes { get; set; }
        public bool DispersedGroupNo { get; set; }
        public string PreferentNumber { get; set; }
        public DataTable AccountingTable { get; set; }
        /// <summary>
        /// data ObservableCollection
        /// </summary>
        public ObservableCollection<OblickTable> Phones { get; set; }
        public ObservableCollection<CardPageFive> Dilery { get; set; }
        
        public ObservableCollection<CardPageThree> Diagnosis { get; set; }
    

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
        private RelayCommand read;
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
        public RelayCommand DileryInsert
        {
            get
            {
                return insert ??
                  (insert = new RelayCommand(obj =>
                  {
                      Dilery.Add(new CardPageFive { ComingDate = "0.10231", HealingPlace = "hospital", Diagnosis = "live", Stamp = "podps" });
                    //  con.UpdateDileryBase(Dilery);
                      Setter();
                  }));
            }
        }
        public RelayCommand DileryRead
        {
            get
            {
                return read ??
                  (read = new RelayCommand(obj =>
                  {

                      Dilery = con.ReadDileryList();
                  }));
            }
        }
      
        public RelayCommand ReadP3
        {
            get
            {
                return readP3 ??
                  (read = new RelayCommand(obj =>
                  {

                      Diagnosis = con.DiagList();
                  }));
            }
        }

        public RelayCommand UpdateP3
        {
            get
            {
                return readP3 ??
                  (read = new RelayCommand(obj =>
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

        public RelayCommand LoadListOfDoc
        {
            get
            {
                return readP3 ??
                  (read = new RelayCommand(obj =>
                  {
                     // ListOfDoctors = con.UpdateP3();

                  }));
            }
        }
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

