using PetProject_EntityFramework_MySql_WPF.Entiti;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
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
        private void Button_Test_Upload_Click(object sender, RoutedEventArgs e)
        {
            #region UploadToDB code
            
                var employe = new Employe()
                {
                    FirstName = "Vladislav",
                    LastName = "Pizdabolov"
                };
                context.Employes.Add(employe);
                context.SaveChanges();
                TextBox_Resul_Window.Text = $"Id: {employe.EmployeeId} , name: {employe.FirstName}, surname: {employe.LastName}";
            
            #endregion


            //using (var context = new MyDbConnection())
            //{
            //    var slaves = context.Employes.ToList();
            //    DataGrid_MyDb.ItemsSource = slaves;
            //}

        }

      
        private void Button_Delete_Click(object sender, RoutedEventArgs e)
        {
            
                for (var vis = sender as Visual; vis != null; vis = VisualTreeHelper.GetParent(vis) as Visual)
                {
                if (vis is DataGridRow)
                {
                    var row = (DataGridRow)vis;
                    int id = (row.Item as Employe).EmployeeId;
                    Employe employe = context.Employes.Where(o => o.EmployeeId == id).FirstOrDefault();

                    context.Employes.Remove(employe);
                    context.SaveChanges();
                    break;
                }
              
            }
        }

        private void Main_Window_Program_Loaded(object sender, RoutedEventArgs e)
        {
            context = new MyDbConnection();
            context.Employes.Load();
            DataGrid_MyDb.ItemsSource = context.Employes.Local;
            
        }
    }
}
