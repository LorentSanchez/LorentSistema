using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema.Web.Data.Entities
{
    public class Position
    {
        [Key]
        public int Position_Id { get; set; }

        [Display(Name = "Título Posición")]
        [MaxLength(100, ErrorMessage = "The {0} field can not have more than {1} characters.")]
        [Required(ErrorMessage = "The field {0} is mandatory.")]
        public string Position_Name { get; set; }

        public ICollection<Employee> Employees { get; set; }
    }
}
