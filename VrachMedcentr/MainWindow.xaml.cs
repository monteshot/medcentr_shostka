﻿using System;
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
         //   DataContext = new test1();
            //DataTable dt;
            //dt = con.query("SELECT * FROM karta");
            ////textDich.Text= dataDich.Columns[0].Header.ToString();
            //dataDich.DataContext = dt;
            //var selected = dt.Select("ID='2'");
            //textDich.Text = selected[0].ItemArray[5].ToString();
            //textDich.Text = selected[0].ItemArray[3].ToString()+" " + selected[0].ItemArray[4].ToString()+" " + selected[0].ItemArray[5].ToString() ;
            ////string connectionstring = "SERVER=shostka.mysql.ukraine.com.ua;DATABASE=shostka_medcentr;UID=shostka_medcentr;PASSWORD=Cpu25Pro;";
            //MySqlConnection connect = new MySqlConnection(connectionstring);
            //MySqlCommand cmd = new MySqlCommand("SELECT *  FROM by_ds_app_services", connect);
            //connect.Open();
            //DataTable dt = new DataTable();
            //dt.Load(cmd.ExecuteReader());
            //connect.Close();

            //TestGrid.DataContext = dt;

            
        }
        connect con = new connect();      
       

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

        private void AddNewPage(object sender, MouseButtonEventArgs e)
        {
            i++;
            PacientCard.Items.Add(new TabItem
            {
                Header = new TextBlock { Text = i.ToString() } // установка заголовка вкладки

            });
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //MainWindow mw = Application.Current.Windows.OfType<MainWindow>().FirstOrDefault();
            test1 vw = new test1();
            vw.title = "8szdgzdsf";
            //mw.DataContext = vw;
            DataContext = vw;
        }
    }
}
