using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using WPF_Hospital;
using System.Windows.Input;
namespace VrachMedcentr
{
    class CardPageOne : INotifyPropertyChanged
    {
        #region Helpers Class Object
        private DateTime thisDay = DateTime.Today;
        private DataTable TestTable = new DataTable();
        private string codeZYCD;
        //CardPageTwo PageTwo = new CardPageTwo();

        #endregion

        #region Data_page1

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

        public string PreferentNumber { get; set; }
        public DataTable AccountingTable { get; set; }
        public string CodeZYCD1 { get => codeZYCD; set => codeZYCD = value; }
        public string Contingency { get; set; }

        #endregion

        #region Helpers method

        //private RelayCommand addCommand;
        //public RelayCommand AddCommand
        //{
        //    get
        //    {
        //        return addCommand ??
        //          (addCommand = new RelayCommand(obj =>
        //          {

        //              // Setter();
        //          }));
        //    }
        //}

        //    public CardPageOne KARTA { get; set; }

        public void Setter()

        {

            Adress = "fasfasf";
        }
        public CardPageOne()
        {
            //KARTA = new CardPageOne
            //{
            //    Name = "aaaaaaaaaa",
            //    Sername = "bbbbbbbbbbb",
            //    DateCardWriten = DateTime.Today
            //};
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

