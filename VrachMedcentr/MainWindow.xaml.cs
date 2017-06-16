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
using VrachMedcentr.Data;

namespace WPF_Hospital
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
       // Card First = new Card("Valera");
        public MainWindow()
        {
            InitializeComponent();
        
            connect con = new connect();
            ///page1.DataContext = con.query("SELECT * FROM by_ds_app_services");
            //string connectionstring = "SERVER=shostka.mysql.ukraine.com.ua;DATABASE=shostka_medcentr;UID=shostka_medcentr;PASSWORD=Cpu25Pro;";
            //MySqlConnection connect = new MySqlConnection(connectionstring);
            //MySqlCommand cmd = new MySqlCommand("SELECT *  FROM by_ds_app_services", connect);
            //connect.Open();
            //DataTable dt = new DataTable();
            //dt.Load(cmd.ExecuteReader());
            //connect.Close();            
          
           
            //TestGrid.DataContext = dt;


        }

        private void Button1_Click(object sender, RoutedEventArgs e)
        {
           
            
        }

        private void MenuFile_Click(object sender, RoutedEventArgs e)
        {
            //Textbox1.Text = First.Name;
        }
        int i = 5;
        private void AddNewPage(object sender, RoutedEventArgs e)
        {
            
            i++;
            PacientCard.Items.Add(new TabItem
            {
                Header = new TextBlock { Text = i.ToString() }, // установка заголовка вкладки
                Name = "Page"+i.ToString()
            });
        }

        private void AddNewPage(object sender, MouseButtonEventArgs e)
        {
            i++;
            PacientCard.Items.Add(new TabItem
            {
                Header = new TextBlock { Text = i.ToString() } // установка заголовка вкладки

            });
        }

        private void Delate(object sender, RoutedEventArgs e)
        {
             int count = PacientCard.SelectedIndex;
            PacientCard.Items.RemoveAt(count);
        }

        private void sadada(object sender, RoutedEventArgs e)
        {
            CardPageOne one = test.DataContext as CardPageOne;
            one.Setter("fasfa");
        }
    }
}
