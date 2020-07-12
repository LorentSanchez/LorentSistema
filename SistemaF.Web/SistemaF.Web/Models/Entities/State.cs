using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema.Web.Data.Entities
{
    public class State
    {
        [Key]
        public int State_Id { get; set; }

        [Required]
        [MaxLength(30)]
        [Display(Name = "Nombre De Estado")]
        public string State_Name { get; set; }
		
        //-----Relacion Country-----
		[Display(Name = "País")]
        [ForeignKey("Country")]
        public int Country_Id { get; set; }
        public Country Country { get; set; }
		
        public ICollection<City> Cities { get; set; }
    }
}
