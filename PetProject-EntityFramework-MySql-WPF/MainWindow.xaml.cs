using PetProject_EntityFramework_MySql_WPF.Entiti;
using System;
using System.Collections.Generic;
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
            
            Frame_One.Navigate(new Emp_Info());
            Frame_One.Visibility = Visibility.Visible;
            Grid_Page_One.Visibility = Visibility.Collapsed;
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

        private void DataGrid_MyDb_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {

           
            if (e.EditAction == DataGridEditAction.Commit)
            {
                
                try
                {
                    // Получаем объект, соответствующий изменяемой ячейке 
                    var editedCell = e.Column.GetCellContent(e.Row);

                    // Получаем объект, соответствующий редактируемой строке 
                    var employe = (Employe)e.Row.DataContext;

                    // Если содержимое ячейки является текстовым блоком, извлекаем из него новое значение
                    context.Entry(employe).State = EntityState.Modified;

                    // Сохраняем изменения в базе данных
                    context.SaveChanges();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка: {ex.Message}");
                }
            }

            // Обновить DataGrid
            DataGrid_MyDb.ItemsSource = context.Employes.Local;
        }

        private void Main_Window_Program_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            context.SaveChanges();
        }

        private void Button_Click_Open(object sender, RoutedEventArgs e)
        {
            //for (var vis = sender as Visual; vis != null; vis = VisualTreeHelper.GetParent(vis) as Visual)
            //{
            //    if (vis is DataGridRow)
            //    {
            //        var row = (DataGridRow)vis;
            //        int id = (row.Item as Employe).EmployeeId;
            //        Employe employe = context.Employes.Where(o => o.EmployeeId == id).FirstOrDefault();

                    
            //        //context.Employes.Remove(employe);
            //        context.SaveChanges();
            //        break;
            //    }

            //}
            Emp_Info emp_Info = new Emp_Info();
            Frame_One.Content = emp_Info;
        }

        private void Button_Add_Person_Click(object sender, RoutedEventArgs e)
        {
            var employe = new Employe()
            {
                FirstName = TextBox_FirstName.Text,
                LastName =  TextBox_LastName.Text
            };
            context.Employes.Add(employe);
            context.SaveChanges();
            TextBox_Resul_Window.Text = $"Id: {employe.EmployeeId} , name: {employe.FirstName}, surname: {employe.LastName}";
        }
    }
}
