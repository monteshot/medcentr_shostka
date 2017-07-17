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
        public string Time { get; set; }
        public string Status { get; set; }// Отображает занято время или нет с помощью цвета задаваемого стрингом
        public BitmapImage TimeProperties { get; set; } = new BitmapImage(new Uri("/Resources/Hospital.jpg",UriKind.Relative)) { CreateOptions = BitmapCreateOptions.IgnoreImageCache };
    }
}