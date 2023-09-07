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
        
          var employe = new Employe()
          {
                    FirstName = "Vladislav",
                    LastName = "Pizdabolov"
          };
          context.Employes.Add(employe);
          context.SaveChanges();
          TextBox_Resul_Window.Text = $"Id: {employe.EmployeeId} , name: {employe.FirstName}, surname: {employe.LastName}";
            
         
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

            // получаем измененный объект Employe из текущей строки
            

            if (e.EditAction == DataGridEditAction.Commit)
            {
                // Получаем объект, соответствующий редактируемой ячейке 
                var editedCell = e.Column.GetCellContent(e.Row);
                
                // Если содержимое ячейки является текстовым блоком, извлекаем из него новое значение
                if (editedCell is TextBox textBlock)
                {
                    //TextBox_Resul_Window.Text = textBlock.Text;
                    // Здесь вы можете отправить изменения в базу данных, используя Entity Framework.
                    // Например, вы можете извлечь объект, который соответствует строке в DataGrid,
                    // изменить его свойство, соответствующее столбцу, и вызвать метод SaveChanges()
                    // для применения изменений в базе данных.
                }
            }
            context.SaveChanges();
            // Обновить DataGrid
            DataGrid_MyDb.ItemsSource = context.Employes.Local;
        }
    }
}
