using PetProject_EntityFramework_MySql_WPF.Entiti;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetProject_EntityFramework_MySql_WPF
{
    internal class MyDbConnection : DbContext
    {
        public MyDbConnection():base("DbConnectionString")
        {

        }

        public DbSet<Employe> Employes { get; set; }
        public DbSet<EmployeInfo> EmployeInfos { get; set;}
    }
}
