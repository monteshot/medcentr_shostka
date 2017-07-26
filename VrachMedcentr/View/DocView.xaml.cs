using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MySql.Data.MySqlClient;
using System.Data;
using kepkaSQL;
using VrachMedcentr;
using System.Collections;
using System.Reflection;
using System.Diagnostics;

using WPF_Hospital;
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
          //  DataContext = new DocViewModel();
            var currVer = Assembly.GetExecutingAssembly().GetName().Version;
            Title += " Версія: " + currVer;
            //не выпиливать! дает версию в заголовке аппы
            //   DocViewModel a = new DocViewModel();
            //
         //   DataContext = new DocViewModel();
        }
    }
}
