using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema.Web.Data.Entities
{
    public class Moneda
    {
        /// relacionado con forma de pago (FormPago)
       [Key]
        public int Moneda_Id { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = "The {0} field can not have more than {1} characters.")]
        [Display(Name ="Moneda Nombre")]
        public string Name_moneda { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = "The {0} field can not have more than {1} characters.")]
        [Display(Name = "Valor")]
        public string Tasa_moneda { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = "The {0} field can not have more than {1} characters.")]
        [Display(Name = "Monedas")]
        public string Nmoneda { get; set; }
		
        public ICollection<FormPago> FormPagos { get; set; }



    }
}
