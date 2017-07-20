using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace VrachMedcentr.View
{
    /// <summary>
    /// Логика взаимодействия для DocView.xaml
    /// </summary>
    public partial class DocView : Window
    {
        public DocView()
        {
            InitializeComponent();
            var currVer = Assembly.GetExecutingAssembly().GetName().Version;
            Title += " Версія: " + currVer; //не выпиливать! дает версию в заголовке аппы

        }
    }
}
