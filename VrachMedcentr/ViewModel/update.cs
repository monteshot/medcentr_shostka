using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace VrachMedcentr
{
    class update
    {
        bool newVerAvailble;
        string remoteVer;
        Version currVer;
        WebClient web = new WebClient();

        public update()
        {
            GetVersion();

        }

        public async void GetVersion()
        {

          

            await PerfTask();
            // getVerUpdate.Start();

        }


        public Task PerfTask()
        {

            return Task.Run(() =>
            {

                try
                {
                  
                    currVer = Assembly.GetExecutingAssembly().GetName().Version;

                    remoteVer = web.DownloadString("https://drive.google.com/uc?export=download&id=0B1PRhPmv7AwwelZaZEs0ZUljcms"); //скоро прямые сслки не будут работать
                    if (remoteVer != currVer.ToString())
                    {
                        newVerAvailble = true;

                    }

                    if (newVerAvailble == true)
                    {
                        HttpWebRequest dwnFile;
                        //пока ничо не делает
                    }
                }
                catch (Exception e) { MessageBox.Show(e.Message); }


            });
        }

    }
}
