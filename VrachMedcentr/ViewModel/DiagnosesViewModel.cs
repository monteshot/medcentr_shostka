using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VrachMedcentr
{
    class DiagnosesViewModel : INotifyPropertyChanged
    {

        public ObservableCollection<object> Diag { get; set; }

        private RelayCommand Add;
        public RelayCommand AddCommand
        {
            get
            {
                return Add ??
                  (Add = new RelayCommand(obj =>
                  {
                      Diag.Add(new TestDiagnoz { Galobu = "alahacbar", AnMorbi = " Torrrr" });
                  }));
            }
        }
        public DiagnosesViewModel()
        {
            Diag = new ObservableCollection<object>
            {
                new TestDiagnoz{ Galobu ="fsafa", AnMorbi="fasfaffs"},
                new CardPageTwo{ Shugar = "сахар"}
            };
        }

        public event PropertyChangedEventHandler PropertyChanged = (sender, e) =>
        {
        };
    }
}
