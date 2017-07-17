using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace VrachMedcentr
{
    class update : INotifyPropertyChanged
    {
        string updateString = "http://localhost/MED/Medcentr_Setup.msi";
        string verString = "http://localhost/MED/ver.txt";
        string batString = "http://localhost/MED/update.bat";
        string vbsString = "http://localhost/MED/start.vbs";
        bool newVerAvailble;
        string remoteVer;
        Version currVer;
        string executionDirectory =  Environment.CurrentDirectory;// Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
        WebClient web = new WebClient();

        public update()
        {
            getVersion();
            
        }
        private RelayCommand _downloadPacket;
        public RelayCommand downloadPacket
        {
            get
            {
                return _downloadPacket ??
                  (_downloadPacket = new RelayCommand(obj =>
                  {

                      //SelectedDocNames.docBool = TimeHour;                   
                      // ListOfDocNames = con.GetDoctrosNames(SelectedSpecf.idspecf.ToString());
                      try
                      {
                          GetInstaller();

                      }
                      catch
                      {

                      }




                  }));
            }
        }

        public async void getVersion()
        {

            try
            {
                currVer = Assembly.GetExecutingAssembly().GetName().Version;
                remoteVer = await web.DownloadStringTaskAsync(verString);
                if (remoteVer != currVer.ToString())
                { 
                    newVerAvailble = true;
                    var result = MessageBox.Show("Завантажити оновлення програмного пакету?", "Доступне оновлення програми", MessageBoxButton.YesNo, MessageBoxImage.Question);
                    if (result == MessageBoxResult.No) { }
                    if (result == MessageBoxResult.Yes)
                    {
                        MessageBox.Show("Починається завантаження програми\n" +
                            "Для продовження натисніть \"ОК\"" +
                            "\nПрограма встановлення автоматично запуститься", "Відбувається завантаження", MessageBoxButton.OK, MessageBoxImage.Information);
                        GetInstaller();
                    }
                }
                else { newVerAvailble = false; }

            }
            catch { }
        }
     
       
        public async void GetInstaller()
        {
            try
            {
                await web.DownloadFileTaskAsync(new Uri(vbsString), executionDirectory + "\\start.vbs");
                await web.DownloadFileTaskAsync(new Uri(batString), executionDirectory + "\\update.bat");
                await web.DownloadFileTaskAsync(new Uri(updateString), executionDirectory + "\\Medcentr_Setup.msi");


            }
            catch (Exception e)
            {// сдесь вылазит эсепшен по невозможности веб клиенту работать асинхронно, но он, сука, работает!
                // MessageBox.Show(e.Message);
            }
            finally
            {

                Process.Start(executionDirectory + "\\start.vbs");
                Environment.Exit(0);
            }

        }



        //public Task GetVersionTask()
        //{

        //    return Task.Run(() =>
        //    {

        //        try
        //        {

        //            currVer = Assembly.GetExecutingAssembly().GetName().Version;

        //            //   remoteVer = web.DownloadString("https://drive.google.com/uc?export=download&id=0B1PRhPmv7AwwelZaZEs0ZUljcms"); //скоро прямые сслки не будут работать
        //            if (remoteVer != currVer.ToString())
        //            {
        //                newVerAvailble = true;

        //            }

        //            //if (newVerAvailble == true)
        //            //{
        //            //    HttpWebRequest dwnFile;
        //            //    //пока ничо не делает
        //            //}
        //        }
        //        catch (Exception e) { MessageBox.Show(e.Message); }


        //    });
        //}
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            var handler = this.PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
