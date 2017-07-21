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

namespace VrachMedcentr
{
    /// <summary>
    /// Логика взаимодействия для EditTime.xaml
    /// </summary>
    public partial class EditTime : Window
    {
        public EditTime()
        {
            InitializeComponent();
           // DataContext = new EditTimesViewModel();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("click");
        }
    }
}
