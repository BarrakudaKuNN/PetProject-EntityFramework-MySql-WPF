using PetProject_EntityFramework_MySql_WPF.Entiti;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml;
using static System.Net.Mime.MediaTypeNames;

namespace PetProject_EntityFramework_MySql_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MyDbConnection context;
        public MainWindow()
        {
            InitializeComponent();
            
        }
        private void Main_Window_Program_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            
        }
        private void Main_Window_Program_Loaded(object sender, RoutedEventArgs e)
        {
            //context = new MyDbConnection();
            //context.Employes.Load();
            //DataGrid_MyDb.ItemsSource = context.Employes.Local;
        }

        private void Button_Connect_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                context = new MyDbConnection();
                context.Database.CreateIfNotExists();
                context.Database.Initialize(true);
                context.Employes.Load();
                Page_One one = new Page_One(context, Frame_Main);
                Frame_Main.Navigate(one);

                Frame frame = (Frame)this.FindName("Frame_Main");
                DataGrid dataGrid = one.FindName("DataGrid_MyDb") as DataGrid;
                dataGrid.ItemsSource = context.Employes.Local;
                Grid_Login_Sreen.Visibility = Visibility.Collapsed;
            
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Add_infoButton_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
