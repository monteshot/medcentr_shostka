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

namespace VrachMedcentr
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            connect con = new connect();
            likariDGV.DataContext= con.query("SELECT * FROM by_ds_app_services");
            textbox1_Copy.Text = con.selectSTR("name","Офтальмолог");
         //  textbox1.Text= con.selectARR("name", "Офтальмолог",1);
            patDGV.DataContext= con.selectONE("name", "Офтальмолог",1);
            //patDGV.Items.Add(con.selectARR("name", "Офтальмолог", 1));
        }

        
    }
}
