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
using System.Windows.Shapes;
using kepkaSQL;
using VrachMedcentr;
using System.Collections;
using System.Reflection;


namespace VrachMedcentr.View
{
    /// <summary>
    /// Логика взаимодействия для StartUPView.xaml
    /// </summary>
    public partial class StartUPView : Window
    {
        public StartUPView()
        {
            InitializeComponent();

            DataContext = new StartUPViewModel();
            var currVer = Assembly.GetExecutingAssembly().GetName().Version;
            Title += " " + currVer; //не выпиливать! дает версию в заголовке аппы
          
        }

        private void Reg_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            
            Environment.Exit(0);
        }
    }
}
