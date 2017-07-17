using System;
using System.Drawing;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace VrachMedcentr
{
    /// <summary>
    /// Class for displaying time
    /// </summary>
    class Times
    {
        private bool _PublickPrivate;

        public string Time { get; set; }
        public string Status { get; set; }// Отображает занято время или нет с помощью цвета задаваемого стрингом

        //public bool PublickPrivate { get; set; }
        public bool PublickPrivate
        {
            get
            {
                return _PublickPrivate;
            }
            set
            {
                _PublickPrivate = value;
                if(value==true)
                {
                    TimeProperties = "На сайті";
                }
                else
                {
                    TimeProperties = "В регістратурі";
                }

            }
        }


        public string TimeProperties { get; set; }

       
    }
}