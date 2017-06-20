using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace VrachMedcentr
{
    class CardPageTwo //: INotifyPropertyChanged
    {
        #region VuiwData_page2

        public string Shugar { get; set; } = "gsdgsgdg";
        public string InfectiousDis { get; set; }
        public string AlergiAnam { get; set; }
        public string IntoleranceToDrugs { get; set; }

        #endregion

        #region Helpers Method
        public void TesterMethod()
        {
            Shugar = "sfafasfaf";
            //PropertyChanged
        }
        private RelayCommand saveToBase;
        public RelayCommand SaveToBase
        {
            get
            {
                return saveToBase ??
                  (saveToBase = new RelayCommand(obj =>
                  {
                      TesterMethod();
                  }));
            }
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
