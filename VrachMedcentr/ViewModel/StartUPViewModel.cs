using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Navigation;
using VrachMedcentr;
using kepkaSQL;
using WPF_Hospital;
using System.Collections;
using System.Reflection;
using VrachMedcentr.View;
using System.Windows.Input;
using System.Collections.ObjectModel;
using System.Diagnostics;
using static WPF_Hospital.MainWindow;

namespace VrachMedcentr
{
    class StartUPViewModel
    {
        #region Constructor

        public StartUPViewModel()
        {
            PresentationTraceSources.DataBindingSource.Listeners.Add(new BindingErrorTraceListener());
            PresentationTraceSources.DataBindingSource.Switch.Level = SourceLevels.Off;
            tempDocNamesList = con.GetDoctorsNamesFORStartup();
            startupDocNamesList = new ObservableCollection<string>();
            foreach (var a in tempDocNamesList)
            {
                startupDocNamesList.Add(a.docName);
            }

        }

        #endregion

        #region Publick Variables

        public ObservableCollection<string> startupDocNamesList { get; set; }
        private ObservableCollection<DocNames> tempDocNamesList = new ObservableCollection<DocNames>();
        public conBD con = new conBD();

        #endregion
        private DocNames SelectedDocObj;
        private string _SelectedDocString;
        public string SelectedDocString
        {
            get
            {
                return _SelectedDocString;
            }
            set
            {
                _SelectedDocString = value;
                //SelectedDocObj = tempDocNamesList.Where(x=>x.docName)

                
                //azazaz
            }
        }

        private RelayCommand _Likar_app;
        public RelayCommand Likar_app
        {
            get
            {

                return _Likar_app ??
                  (_Likar_app = new RelayCommand(obj =>
                  {
                      DocView docView = new DocView();
                     
                      regViewModel reg = new regViewModel();
                      //reg.SelectedDocNames = SelectedDoc;
                      docView.DataContext = reg;
                      try
                      {
                          docView.Show();

                      }
                      catch { }


                  }));
            }

        }
        private RelayCommand _Reg_app;
        public RelayCommand Reg_app
        {
            get
            {

                return _Reg_app ??
                  (_Reg_app = new RelayCommand(obj =>
                  {
                      MainWindow regs = new MainWindow();
                      StartUPView sUPv = new StartUPView();
                      regViewModel reg = new regViewModel();
                      regs.DataContext = reg;
                      try
                      {
                          regs.Show();

                      }
                      catch { }



                  }));
            }

        }
        public void Close()
        {
            this.Close();
        }
        public bool CanClose { get; set; }
        private RelayCommand _Close_app;
        public RelayCommand Close_app
        {
            get
            {

                return _Close_app ??
                  (_Close_app = new RelayCommand(obj =>
                  {
                      this.Close();



                  }));
            }

        }


    }
}
