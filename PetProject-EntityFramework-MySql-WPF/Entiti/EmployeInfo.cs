using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetProject_EntityFramework_MySql_WPF.Entiti
{
    internal class EmployeInfo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
       public string Adress { get; set; }
       public string City { get; set; }
       public string PhoneNumber { get; set; }
       public int EmployeId { get; set; }

        public virtual Employe Employe { get; set; }
    }
}
