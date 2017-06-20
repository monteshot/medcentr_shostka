using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using WPF_Hospital;
using System.Data;
using System.Windows.Input;
namespace VrachMedcentr
{
    class CardPages : INotifyPropertyChanged
    {
        #region Helpers Class Object

        private DateTime thisDay = DateTime.Today;
        private DataTable TestTable = new DataTable();

        //CardPageTwo PageTwo = new CardPageTwo();

        #endregion

        public CardPages()
        {
            Phones = new ObservableCollection<OblickTable>
            {
                new OblickTable { TakenDate="iPhone 7", TakenReason="Apple", RemovedDate="56000", RemovedReason ="fasfasf"},
                new OblickTable {TakenDate="Galaxy S7 Edge", TakenReason="Samsung", RemovedDate ="60000", RemovedReason="fsdfsdfs"},
                new OblickTable {TakenDate="Elite x3", TakenReason="HP", RemovedDate="56000",RemovedReason= "fdsfdsfd"},
                new OblickTable {TakenDate="Mi5S", TakenReason="Xiaomi", RemovedDate="35000" ,RemovedReason="fsdfsdf"}
            };
        }
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

        public ObservableCollection<OblickTable> Phones { get; set; }


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
        /// <summary>
        /// Command From View
        /// </summary>
        private RelayCommand addCommand;
        public RelayCommand AddCommand
        {
            get
            {
                return addCommand ??
                  (addCommand = new RelayCommand(obj =>
                  {
                      Setter();
                      CodeZYCD = "jk;j;k";
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

