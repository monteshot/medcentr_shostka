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
            
            string connectionstring = "SERVER=shostka.mysql.ukraine.com.ua;DATABASE=shostka_medcentr;UID=shostka_medcentr;PASSWORD=Cpu25Pro;";
            MySqlConnection connect = new MySqlConnection(connectionstring);
            MySqlCommand cmd = new MySqlCommand("SELECT *  FROM by_ds_app_services", connect);
            connect.Open();
            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());
            connect.Close();

            //TestGrid.DataContext = dt;


        }

        private void Button1_Click(object sender, RoutedEventArgs e)
        {


        }

        private void MenuFile_Click(object sender, RoutedEventArgs e)
        {
            //Textbox1.Text = First.Name;
        }
        int i = 6;
        private void AddNewPage(object sender, RoutedEventArgs e)
        {
            i++;
            PacientCard.Items.Add(new TabItem
            {
                Header = new TextBlock { Text = i.ToString() } // установка заголовка вкладки

            });
        }


    }
}
