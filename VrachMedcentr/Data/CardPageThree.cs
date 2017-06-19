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
        public DataTable page3 { get; set; }

        #endregion

        #region Helpers method

        public ICommand Test3
        {
            get
            {
                return new ActionCommand3(() =>
                {
                    DataZvern = "fasfasf";

                    page3 = con.Dpage3("SELECT * FROM diagnoz");
                });
            }
        }


        #endregion
        #region Event
        /// <summary>
        ///  Property changed event
        /// </summary>
        /// 

        public event PropertyChangedEventHandler PropertyChanged = (sender, e) =>
        {
        };

        #endregion
    }
    public class ActionCommand3 : ICommand
    {
        private readonly Action action;

        public ActionCommand3(Action action)
        {
            this.action = action;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            action();
        }
    }
}
