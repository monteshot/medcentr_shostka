using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using kepkaSQL;
namespace VrachMedcentr
{
    class CardPageFour : INotifyPropertyChanged
    {
        // public DataView page4 { get; set; }
        public DateTime Date { get; set; }
        public string NumList { get; set; }
        public string Procedure { get; set; }
        public string Mitka { get; set; }
        public string NumPat { get; set; }
        public string Doze { get; set; }
        //connect con = new connect();
        //private RelayCommand addCommand;
        //public RelayCommand AddCommand4
        //{
        //    get
        //    {
        //        return addCommand ??
        //          (addCommand = new RelayCommand(obj =>
        //          {

        //              //page4 = con.Dpage4("SELECT * FROM rentgen");

        //          }));
        //    }
        //}
        public event PropertyChangedEventHandler PropertyChanged = (sender, e) =>
        {
        };
    }

}

