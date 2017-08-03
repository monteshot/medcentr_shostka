using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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

using kepkaSQL;
using WPF_Hospital;
namespace VrachMedcentr
{
    class CardPageThree
    {
        #region Helpers Class Object

        #endregion

        #region Data_page3

        public string NumPat { get; set; }
        public DateTime DataZvern { get; set; } = DateTime.Today;
        public string ZaklDiagn { get; set; }
        public bool FDiagn { get; set; }
        public bool PDiag { get; set; }
        public string Sign { get; set; }
      //  public DataView page3 { get; set; }

        //public void Comparer(CardPageThree temp)
        //{
        //    if (temp)
        //        }

        #endregion



    }

}
