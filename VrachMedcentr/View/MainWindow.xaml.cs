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

namespace WPF_Hospital
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        VrachMedcentr.View.StartUPView start = new VrachMedcentr.View.StartUPView();

        /// <summary>
        /// ПОЛЕЗНЕЙШАЯ ХРЕНЬ! Выявляет ошибки байдиннга
        /// </summary>

        #region Binding Error Shower
        public class BindingErrorTraceListener : TraceListener
        {
            private readonly StringBuilder _messageBuilder = new StringBuilder();

            public override void Write(string message)
            {
                _messageBuilder.Append(message);
            }

            public override void WriteLine(string message)
            {
                Write(message);

                MessageBox.Show(_messageBuilder.ToString(), "Binding error", MessageBoxButton.OK, MessageBoxImage.Warning);
                _messageBuilder.Clear();
            }
        }
        // Вставлять в любой файл пригодный для компиляции 
        //      PresentationTraceSources.DataBindingSource.Listeners.Add(new BindingErrorTraceListener());
        //      PresentationTraceSources.DataBindingSource.Switch.Level = SourceLevels.Error;
        #endregion
        public MainWindow()
        {
            InitializeComponent();

            var currVer = Assembly.GetExecutingAssembly().GetName().Version;
            Title += " Версія: " + currVer; //не выпиливать! дает версию в заголовке аппы

            connect con = new connect();
            CardPages CP = new CardPages();

            // ниже идут датаконтесты, которые были подвязаны во CardPages !!!!!!!НУЖНО ПЕРЕДЕЛАТЬ!!!!!
            page1.DataContext = CP.KARTA;
            page2.DataContext = CP.Card2;// Сигнаьны позначик
            Shelpennya.UpdateLayout();
            Shelpennya.ItemsSource = CP.Shepl;// щеплення на той же странице шо и позначки
            Profilact.ItemsSource = CP.Profilact; // профосмотры на той же странице шо и позначки
            DPage3.ItemsSource = CP.Card3; // личток заключительных дигнозов
            DPage4.ItemsSource = CP.Card4; //рентген
            DPage5.ItemsSource = CP.Card5;
            Registratyra.DataContext = new regViewModel();
            Testersitem.DataContext = new DiagnosesViewModel();
            // Update.DataContext = new update();
            update updater = new update();
            //upd.GetVersion();






            //Regis.DataContext = new regViewModel();// может еще нам нужно будет
            //Card3.DataContext= new CardPageThree();
            //Card4.DataContext = new CardPageFour();
            // Card5.DataContext = new CardPageFive();
            // DPage3.DataContext = new CardPageThree();
            //  con.query(-)
            //this.DataContext = new CardPageOne();



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

        //  public DoctorsList.DocNames bab;

        public interface ISuggestionProvider
        {
            IEnumerable GetSuggestions(string filter);
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
                Name = "Page" + i.ToString()
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
        //     regViewModel rvm = new regViewModel();
        private void Regis_Selected(object sender, RoutedEventArgs e)
        {


            //rvm.docIdBehind((DoctorsList.DocNames)Regis.SelectedItem);

            //rvm.docIdBehind(Regis.SelectedItem);

            //  var a = (DoctorsList.DocNames)Regis.SelectedItem;
        }

        private void Regis_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {

            // bab =(DoctorsList.DocNames) Regis.SelectedItem;
            //rvm.docIdBehind(a.docID);

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(Reg.ItemsSource);
            //PropertyGroupDescription groupDescription = new PropertyGroupDescription("specf");
            //view.GroupDescriptions.Add(groupDescription);
        }






        // CardPageOne one = new CardPageOne();


    }

}
