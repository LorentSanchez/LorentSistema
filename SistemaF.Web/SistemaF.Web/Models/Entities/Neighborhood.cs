using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema.Web.Data.Entities
{
    public class Neighborhood
    {
        [Key]
        public int Neighborhood_Id { get; set; }

        [Required]
        [MaxLength(30)]
        [Display(Name = "Municipio")]
        public string Neighborhood_Name { get; set; }
		
        //-----Relacion City-----
		[Display(Name = "Ciudad")]
        [ForeignKey("City")]
        public int City_Id { get; set; }
        public City City { get; set; }
		
		
        public ICollection<Supplier> Suppliers { get; set; }
        public ICollection<Company> Companies { get; set; }
    }
}
