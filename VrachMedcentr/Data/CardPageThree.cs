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
using System.Data;
using kepkaSQL;
using WPF_Hospital;
namespace VrachMedcentr
{
    class CardPageThree : INotifyPropertyChanged
    {
        #region Helpers Class Object

        #endregion

        #region Data_page3
        connect con = new connect();

        public string DataZvern { get; set; }
        public string ZaklDiagn { get; set; }
        public string FDiagn { get; set; }
        public string PDiag { get; set; }
        public string Sign { get; set; }
        public DataView page3 { get; set; }
        public DataSet page3ds { get; set; }
        #endregion

        #region Helpers method

        private RelayCommand addCommand;
        public RelayCommand AddCommand3
        {
            get
            {
                return addCommand ??
                  (addCommand = new RelayCommand(obj =>
                  {
                      MainWindow a = new MainWindow();
                     // try { page3 = page3.Table.DefaultView; } catch (Exception) { }
                     
                      page3 = con.Dpage3();
                     

                  }));
            }
        }
        /// <summary>
        /// апдейт
        /// </summary>
        private RelayCommand updateComm;
        public RelayCommand UpdateComm3
        {
            get
            {
                return updateComm ??
                  (updateComm = new RelayCommand(obj =>
                  {
                     
                      con.UpdateDB();
                     // page3 = null;
                      //page3 = con.Dpage3("SELECT * FROM diagnoz");

                  }));
            }
        }

        #endregion
        #region Event
        /// <summary>
        ///  Property changed event
        /// </summary>
        /// 
        ///
  
          
     
        public event PropertyChangedEventHandler PropertyChanged = (sender, e) =>
        {
        };

        #endregion
    }
    
}
