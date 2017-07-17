using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;

namespace VrachMedcentr
{
    class test2 : INotifyPropertyChanged
    {
        public ObservableCollection<test1> Phones { get; set; }
        public test2()
        {
            Phones = new ObservableCollection<test1>
            {
                new test1 { Title="test123".ToString() }

            };
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
