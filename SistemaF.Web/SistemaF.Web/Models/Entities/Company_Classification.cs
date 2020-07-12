using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Sistema.Web.Data.Entities
{
    public class Company_Classification
    {
        [Key]
        [Display(Name = "Código")]
        public int CompanyClass_Id { get; set; }


        [Display(Name = "Clasificación de Compañías")]
        [MaxLength(50, ErrorMessage = "The {0} field can not have more than {1} characters.")]
        [Required(ErrorMessage = "The field {0} is mandatory.")]
        public string CompanyClass_Name { get; set; }
        /*
        [Display(Name = "Descripción")]
        [MaxLength(100, ErrorMessage = "The {0} field can not have more than {1} characters.")]
        [Required(ErrorMessage = "The field {0} is mandatory.")]
        public string Description { get; set; }
        */

        public ICollection<Company> Companies { get; set; }
    }
}
