using PetProject_EntityFramework_MySql_WPF.Entiti;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using static System.Net.Mime.MediaTypeNames;

namespace PetProject_EntityFramework_MySql_WPF
{
    internal class MyDbConnection : DbContext
    {
        string connection;
        public MyDbConnection() :base("DbConnectionString")
        {

        }
        
        public DbSet<Employe> Employes { get; set; }
        public DbSet<EmployeInfo> EmployeInfos { get; set;}
    }
}
