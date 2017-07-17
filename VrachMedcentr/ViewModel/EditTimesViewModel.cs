using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace VrachMedcentr
{
    class EditTimesViewModel : INotifyPropertyChanged
    {
        #region Public variables

        public ObservableCollection<Times> docTimes { get; set; }
        public ObservableCollection<DocNames> docBool { get; set; }
        public DocNames docSelected { get; set; }
        public Times SelectedTime { get; set; }


        #endregion

        #region Halpers object


        conBD con = new conBD();

        #endregion


        #region Halpers Command and methods


        private RelayCommand _submitTimes;
        public RelayCommand SubmitTimes
        {
            get
            {

                return _submitTimes ??
                  (_submitTimes = new RelayCommand(obj =>
                  {

                      string result = "";
                      string z = "";
                      string prive = "";
                      bool permitToBase = true;

                      try
                      {

                          foreach (var a in docTimes)
                          {

                              //if (a.Time.Count<char>() < 5 && a.Time.Count<char>()>3)
                              //{
                              //    permitToBase = false;
                              //    break;
                              //}
                              if (a.Time == "") { continue; }
                              if (a.PublickPrivate == true)
                              {

                                  z += a.Time + "\r";

                                  if (a.Time == null || a.Time == "")
                                  {
                                      z = z.Substring(0, z.Length - 1);
                                  }
                              }
                              else
                              {

                                  prive += a.Time + "\r";

                                  if (a.Time == null || a.Time == "")
                                  {
                                      prive = prive.Substring(0, z.Length - 1);
                                  }
                              }

                          }
                      }
                      catch
                      {
                          MessageBox.Show("Перевірте пральність введення данних");
                      }
                      
                      //Проверка на наличие времени
                      //if (prive != "" && prive != null)
                      //{
                      //    prive = prive.Substring(0, prive.Length - 1);
                      //}
                      //if (z != "" && z != null)
                      //{
                      //    z = z.Substring(0, z.Length - 1);
                      //}

                      if (permitToBase == true)
                      {
                          con.updateCurr(z, prive, docSelected.docTimeId);
                          MessageBox.Show("Розклад лікаря " + docSelected.docName + " змінено", "Розклад змінено", MessageBoxButton.OK, MessageBoxImage.Question);
                      }
                      else
                      {
                          MessageBox.Show("Розклад лікаря " + docSelected.docName + " НЕ змінено.\nПеревірте правильність данних та спробуйте ще раз", "Помилка", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                      }






                  }));
            }

        }

        private RelayCommand _addTimes;
        public RelayCommand addTimes
        {
            get
            {

                return _addTimes ??
                  (_addTimes = new RelayCommand(obj =>
                  {

                      docTimes.Add(new Times { Time = "" });
                      NotifyPropertyChanged();


                  }));
            }

        }
        /// <summary>
        /// команда удаления записи в качесте obj передаеться пораметр команды с общим Binding
        /// </summary>
        private RelayCommand _remTimes;

        public RelayCommand remTimes
        {
            get
            {

                return _remTimes ??
                  (_remTimes = new RelayCommand(obj =>
                  {

                      try
                      {

                          docTimes.Remove(obj as Times);

                      }
                      catch (Exception) { }



                  }));
            }

        }

        //public RelayCommand remTimes
        //{
        //    get
        //    {

        //        return _remTimes ??
        //          (_remTimes = new RelayCommand(obj =>
        //          {

        //              try
        //              {
        //                  foreach (var a in docTimes)
        //                  {
        //                      if (a.Time == SelectedTime.Time)
        //                      {
        //                          docTimes.Remove(a);
        //                      }
        //                  }
        //              }
        //              catch (Exception) { }

        //              //   docTimes.Add(new Times { Time = "" });


        //              //MessageBox.Show("deleted");

        //          }));
        //    }

        //}


        /// <summary>
        /// дальше мусор 
        /// </summary>
        public ObservableCollection<Times> temperory { get; set; }

        private RelayCommand _ClosingWindow;
        public RelayCommand ClosingWindow
        {
            get
            {

                return _ClosingWindow ??
                  (_ClosingWindow = new RelayCommand(obj =>
                  {


                      // MessageBox.Show("closed");

                      //temperory = con.getDocTimes(a.SelectedDocNames.docID, a.SelectedDocNames.docTimeId, a.DateDoctorAcepting);


                  }));
            }

        }
        #endregion

        void NotifyPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
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
