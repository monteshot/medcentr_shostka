using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WPF_Hospital;

namespace VrachMedcentr
{
    class test1 : INotifyPropertyChanging
    {
        public string title;
        public string Title
        {
            get { return title; }
            set { title = value; OnPropertyChanged("Title"); }

        }

     


        //  public event PropertyChangedEventHandler PropertyChanged;
        // public event PropertyChangingEventHandler PropertyChanged;
        public event PropertyChangingEventHandler PropertyChanging;

        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanging != null)
                PropertyChanging(this, new PropertyChangingEventArgs(prop));
            
          //  MainWindow mw = Application.Current.Windows.OfType<MainWindow>().FirstOrDefault();
        }
    }
}
