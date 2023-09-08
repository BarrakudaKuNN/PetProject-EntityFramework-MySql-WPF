using PetProject_EntityFramework_MySql_WPF.Entiti;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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

namespace PetProject_EntityFramework_MySql_WPF
{
    /// <summary>
    /// Interaction logic for Emp_Info.xaml
    /// </summary>
    public partial class Emp_Info : Page
    {
        MyDbConnection context;
        Frame FrameOneTransfer;
        internal Emp_Info(MyDbConnection connection, Frame frame)
        {
            InitializeComponent();
            context= connection;
            FrameOneTransfer = frame;
        }

        private void Button_Delete_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_Open(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Add_Person_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Test_Upload_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DataGrid_MyDb_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            if (e.EditAction == DataGridEditAction.Commit)
            {
                //MyDbConnection myDbConnection;
                //try
                //{
                //    // Получаем объект, соответствующий изменяемой ячейке 
                //    var editedCell = e.Column.GetCellContent(e.Row);

                //    // Получаем объект, соответствующий редактируемой строке 
                //    var employeInfo = (EmployeInfo)e.Row.DataContext;

                //    // Если содержимое ячейки является текстовым блоком, извлекаем из него новое значение
                //    context.Entry(employeInfo).State = EntityState.Modified;

                //    // Сохраняем изменения в базе данных
                //}
                //catch (Exception ex)
                //{
                //    MessageBox.Show($"Ошибка: {ex.Message}");
                //}
                try
                {
                    var employeInfo = (EmployeInfo)e.Row.DataContext;

                    // Получаем новое значение из ячейки и применяем его к соответствующему свойству объекта employeInfo
                    ////Вытасківаем значение EmployeInfo из таблицы и ложим в переменную
                    ////И приводим стоку к классу EmployeInfo
                    var newEmployeInfo = (EmployeInfo)e.Row.DataContext;
                    ////Вытаскиваем новое знаечени из ячейки и кладём в новую переменную cellTExt
                    var cellText = (TextBox)e.EditingElement;
                    var value = cellText.Text;
                    ////Вытаскиваем название столбца ячейки которую мы меняем
                    var columnName = e.Column.SortMemberPath;
                    ////Выбираем это же значение (название столбца) но только вытаскиваем его из нашего объекта класса
                    var propertyName = employeInfo.GetType().GetProperty(columnName);
                    ////Самое сложное
                    ////Устанавливаем новое значение свойству объекта employeInfo;
                    propertyName.SetValue(newEmployeInfo, Convert.ChangeType(value, propertyName.PropertyType));

                    // Обновляем состояние объекта employeInfo и сохраняем изменения в базе данных
                    context.Entry(employeInfo).State = EntityState.Modified;
                    context.SaveChanges();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка: {ex.Message}");
                }
            }
            context.SaveChanges();
        }

        private void Button_Back_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
