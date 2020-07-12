using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema.Web.Data.Entities
{
    public class Country
    {
        [Key]
        public int Country_Id { get; set; }

        [Required]
        [MaxLength(30)]
        [Display(Name = "Nombre De Pais")]
        public string Country_Name { get; set; }

        public ICollection<State> States { get; set; }
    }
}
