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
        public MyDbConnection():base("")
        {

        }
    }
}
