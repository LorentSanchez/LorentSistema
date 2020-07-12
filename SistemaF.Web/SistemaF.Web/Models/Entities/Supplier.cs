using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema.Web.Data.Entities
{
    public class Supplier
    {
        //relacionar clasificacion suplidor , tipo document y municipio 
        [Key]
        public int Supplier_Id { get; set; }

        [Required]
        [Display(Name = "Suplidor")]
        public string Supplier_Name { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = "The {0} field can not have more than {1} characters.")]
        [Display(Name = "Numero De Referencia")]
        public string Numero { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = "The {0} field can not have more than {1} characters.")]
        [Display(Name = "Clasificacion De Suplidor")]
        public string SupplierC { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage = "The {0} field can not have more than {1} characters.")]
        [Display(Name = "Telefono")]
        public string phone { get; set; }
		
        //-----Relacion Neighborhood-----
		[Display(Name = "Municipio")]
        [ForeignKey("Neighborhood")]
        public int Neighborhood_Id { get; set; }
        public Neighborhood Neighborhood { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = "The {0} field can not have more than {1} characters.")]
        [Display(Name = "Email")]
        public string correo { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = "The {0} field can not have more than {1} characters.")]
        [Display(Name = "Conctato")]
        public string name_contacta { get; set; }

    }
}
