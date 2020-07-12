using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema.Web.Data.Entities
{
    public class Seller
    {
        /// NO VI SU RELACION EN LAS FOTO PERO ENTIENDO QUE LO PUEDES RELACIONAR CON SUPLIDOR Y ARTICULOS 
        [Key]
        public int Seller_Id { get; set; }

        [Display(Name = "Codigo")]
        public string Codigo_Vendedor { get; set; }

        [Display(Name = "Nombre")]
        [MaxLength(50, ErrorMessage = "The {0} field can not have more than {1} characters.")]
        [Required(ErrorMessage = "The field {0} is mandatory.")]
        public string Seller_Name { get; set; }

        [Display(Name = "Apellido")]
        [MaxLength(50, ErrorMessage = "The {0} field can not have more than {1} characters.")]
        [Required(ErrorMessage = "The field {0} is mandatory.")]
        public string Seller_Lastname { get; set; }
        
		//-----Relacion Document-----
        [Display(Name = "Documento")]
        [ForeignKey("Document")]
        public int Document_Id { get; set; }
        public Document Document { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage = "The {0} field can not have more than {1} characters.")]
        [Display(Name = "Numero De Documento")]
        public string DocumentRef { get; set; }


        [MaxLength(20, ErrorMessage = "The {0} field can not have more than {1} characters.")]
        [Display(Name = "Teléfono")]
        public string Phone { get; set; }

        [MaxLength(20, ErrorMessage = "The {0} field can not have more than {1} characters.")]
        [Display(Name = "Celular")]
        public string Cellphone { get; set; }

        [MaxLength(50, ErrorMessage = "The {0} field can not have more than {1} characters.")]
        [Display(Name = "Email")]
        public string Email { get; set; }


    }
}
