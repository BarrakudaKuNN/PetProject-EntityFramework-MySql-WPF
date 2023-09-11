using PetProject_EntityFramework_MySql_WPF.Entiti;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Contexts;
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

namespace PetProject_EntityFramework_MySql_WPF
{
    /// <summary>
    /// Interaction logic for Page_One.xaml
    /// </summary>
    public partial class Page_One : Page
    {
        MyDbConnection context;
        Frame FrameOneTransfer;
        internal Page_One(MyDbConnection сonnect, Frame frame)
        {
            InitializeComponent();
            context = сonnect;
            FrameOneTransfer = frame;
        }
        private void Button_Test_Upload_Click(object sender, RoutedEventArgs e)
        {

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

        //Hardes lines of code
        private void Button_Click_Open(object sender, RoutedEventArgs e)
        {
            try
            {
                ///Сhecl wich line was selected by user
                for (var vis = sender as Visual; vis != null; vis = VisualTreeHelper.GetParent(vis) as Visual)
                {
                    if (vis is DataGridRow)
                    {
                        //Get uniq Id of selected line EmployeeId= our PK
                        var row = (DataGridRow)vis;
                        int id = (row.Item as Employe).EmployeeId;
                        //Search line whith this unqi ID in our MSSQL database. we call to DB trough "context."
                        Employe employe = context.Employes.Where(o => o.EmployeeId == id).FirstOrDefault();

                        //Get our line from Db by her uniq ID and tryig to put it in our new field "record" 

                        var record = context.EmployeInfos.FirstOrDefault(r => r.Id == id);
                        var records = new ObservableCollection<EmployeInfo>();

                        // if we found our line (its exist) we put it in ObservableCollection
                        if (record != null)
                        {
                            records.Add(record);
                        }
                        //if we didnt found our line we create new (empty) we fill only Id
                        //Cuz we have one-to-one realation and Id of new EmployeInfo equal to Id of our selected line 
                        if (record == null)
                        {
                            var employeInfo = new EmployeInfo() { EmployeId = id };
                            context.EmployeInfos.Add(employeInfo);
                            records.Add(employeInfo);
                        }
                        //Navigation block 
                        //We create new Page-MoveToHer-And write our result to DataGrid of "New Page"
                        Emp_Info one = new Emp_Info(context, FrameOneTransfer);
                        FrameOneTransfer.Navigate(one);

                        Frame frame = (Frame)this.FindName("Frame_Main");
                        DataGrid dataGrid = one.FindName("DataGrid_MyDb_Two") as DataGrid;
                        dataGrid.ItemsSource = records;
                        //Save result
                        context.SaveChanges();
                        break;
                    }

                }

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Button_Add_Person_Click(object sender, RoutedEventArgs e)
        {
            var employe = new Employe()
            {
                FirstName = TextBox_FirstName.Text,
                LastName = TextBox_LastName.Text
            };
            context.Employes.Add(employe);
            context.SaveChanges();

            TextBox_Resul_Window.Text = $"Создана запись на Имя: {employe.FirstName} {employe.LastName}";
        }
    }
}
