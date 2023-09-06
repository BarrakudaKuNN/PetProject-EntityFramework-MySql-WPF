using PetProject_EntityFramework_MySql_WPF.Entiti;
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

namespace PetProject_EntityFramework_MySql_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

        }

        private void Button_Test_Upload_Click(object sender, RoutedEventArgs e)
        {
            #region UploadToDB code
            //using(var context = new MyDbConnection())
            //{
            //    var employe = new Employe()
            //    {
            //        FirstName = "Vladislav",
            //        LastName = "Pizdabolov"
            //    };
            //    context.Employes.Add(employe);
            //    context.SaveChanges();

            //    TextBox_Resul_Window.Text = $"Id: {employe.EmployeeId} , name: {employe.FirstName}, surname: {employe.LastName}";
            //}
            #endregion
        }
    }
}
