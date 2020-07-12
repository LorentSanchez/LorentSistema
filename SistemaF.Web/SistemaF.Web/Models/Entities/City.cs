using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema.Web.Data.Entities
{
    public class City
    {
        [Key]
        public int City_Id { get; set; }

        [Required]
        [MaxLength(30)]
        [Display(Name = "Ciudad")]
        public string City_Name { get; set; }

        //-----Relacion State-----
		[Display(Name = "Estado")]
        [ForeignKey("State")]
        public int State_Id { get; set; }
        public State State { get; set; }

        public ICollection<Neighborhood> Neighborhoods { get; set; }

    }
}
