using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        public string NumPat { get; set; }
        public string Shugar { get; set; } = "xxxxx";
        public string InfectiousDis { get; set; }
        public string AlergiAnam { get; set; }
        public string IntoleranceToDrugs { get; set; }
        public ObservableCollection<Sheplenya> Sheplennya { get; set; }
        public ObservableCollection<Profilact> Profilactica { get; set; }
        #endregion
        public CardPageTwo()
        {
        }
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
    class Profilact
    {
        public DateTime Date { get; set; }
        public string NumPat { get; set; }
        public string NumCab { get; set; }
        public string Flura { get; set; }
        public string Syphilis { get; set; }
        public string HIV { get; set; }
    }
    class Sheplenya
    {
        public string NazvaShepl { get; set; }
        public string NumPat { get; set; }
        public DateTime Date { get; set; }
        public string Age { get; set; }
        public string Doze { get; set; }
        public string Seria { get; set; }
        public string NazvaPrep { get; set; }
        public string SposibVV { get; set; }
        public bool MReact { get; set; }
        public bool ZReact { get; set; }
        public string MedProt { get; set; }

    }
}
