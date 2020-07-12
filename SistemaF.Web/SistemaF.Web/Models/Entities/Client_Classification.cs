using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Sistema.Web.Data.Entities
{
    public class Client_Classification
    {
        [Key]
        [Display(Name = "Código")]
        public int ClientClass_Id { get; set; }


        [Display(Name = "Clasificación de Clientes")]
        [MaxLength(50, ErrorMessage = "The {0} field can not have more than {1} characters.")]
        [Required(ErrorMessage = "The field {0} is mandatory.")]
        public string ClientClass_Name { get; set; }
        /*
        [Display(Name = "Descripción")]
        [MaxLength(100, ErrorMessage = "The {0} field can not have more than {1} characters.")]
        [Required(ErrorMessage = "The field {0} is mandatory.")]
        public string Description { get; set; }
        */

        public ICollection<Customer> Customers { get; set; }
    }
}
