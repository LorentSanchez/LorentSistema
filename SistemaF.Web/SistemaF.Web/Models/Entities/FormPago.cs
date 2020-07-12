using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema.Web.Data.Entities
{
    public class FormPago
    {/// Relacionado con moneda 
        
        [Key]
        public int Id_Pago { get; set; }

        ///Efectivo 
        [Required]
        [Display(Name = "Forma De Pago")]
        public string pago_Name { get; set; }


        //-----Relacion Moneda-----
		[Display(Name = "Moneda")]
        [ForeignKey("Moneda")]
        public int Moneda_Id { get; set; }
        public Moneda Moneda { get; set; }
    }
}
