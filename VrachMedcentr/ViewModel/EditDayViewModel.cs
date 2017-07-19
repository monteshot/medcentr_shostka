using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Controls;
using System.Windows;

namespace VrachMedcentr
{
    class EditDayViewModel : INotifyPropertyChanged
    {
        public DateTime selectedDays { get; set; } = DateTime.Today;
        public DocNames docSelected { get; set; }
        public ObservableCollection<Times> docTimes { get; set; }
        public ObservableCollection<DateTime> WorkDays { get; set; }
        conBD con = new conBD();
        List<DateTime> selectedDaysCal = new List<DateTime>();

        private RelayCommand _setSelectedDays;

        public RelayCommand setSelectedDays
        {
            get
            {

                return _setSelectedDays ??
                  (_setSelectedDays = new RelayCommand(obj =>
                  {
                      tempSelected = obj as SelectedDatesCollection;

                  }));
            }

        }
        SelectedDatesCollection tempSelected;

        private RelayCommand _checkDays;

        public RelayCommand checkDays
        {
            get
            {

                return _checkDays ??
                  (_checkDays = new RelayCommand(obj =>
                  {



                      try
                      {
                          foreach (var a in tempSelected as SelectedDatesCollection)
                          {
                              var currTimes = con.getDocTimes(docSelected.docID, docSelected.docTimeId, a);


                              foreach (var time in currTimes)
                              {
                                  string[] parTime = time.Time.Split(new char[] { ':' });

                                  con.addWorkDays(docSelected.docID, "0", false, true, a, parTime[0], parTime[1], "0", "0");
                              }
                          }
                          WorkDays = con.GetListOfWorkingDays(Convert.ToInt32(docSelected.docID));
                      }
                      catch (Exception) { }

                      editDays edDays = new editDays();
                      edDays.Close();

                  }));
            }

        }

        private RelayCommand _uncheckDays;

        public RelayCommand uncheckDays
        {
            get
            {

                return _uncheckDays ??
                  (_uncheckDays = new RelayCommand(obj =>
                  {



                      try
                      {
                          foreach (var a in tempSelected as SelectedDatesCollection)
                          {
                              var currTimes = con.getDocTimes(docSelected.docID, docSelected.docTimeId, a);


                              //foreach (var time in currTimes)
                              //{
                              // string[] parTime = time.Time.Split(new char[] { ':' });

                              con.remWorkDays(docSelected.docID, a);
                              //   }
                          }
                          WorkDays = con.GetListOfWorkingDays(Convert.ToInt32(docSelected.docID));
                      }
                      catch (Exception) { }

                      editDays edDays = new editDays();
                      edDays.Close();

                  }));
            }

        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            var handler = this.PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
