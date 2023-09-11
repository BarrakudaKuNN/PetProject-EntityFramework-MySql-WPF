using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetProject_EntityFramework_MySql_WPF.Entiti
{
    internal class Employe
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EmployeeId { get; set; }
        
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public virtual ICollection<EmployeInfo> EmployeInfos { get; set; }
    }
}
