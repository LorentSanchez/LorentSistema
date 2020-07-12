using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Principal;
using System.Threading.Tasks;

namespace Sistema.Web.Data.Entities
{
    public class Article
    {// verifica la relacion 
        [Key]
        public int Article_Id { get; set; }
		
        [Required]
        [Display(Name = "Artículo")]
        public string Article_Name { get; set; }

        public double Price { get; set; }

        public bool IsAvailabe { get; set; }
        public int Stock { get; set; }

        //-----Relacion ArticleClassification-----
        [Display(Name = "Tipo Artículo")]
        [ForeignKey("ArticleClassification")]
        public int ArtC_Id { get; set; }
        public ArticleClassification ArticleClassification { get; set; }

        //-----Relacion Brand-----
		[Display(Name = "Marca")]
        [ForeignKey("Brand")]
        public int Brand_Id { get; set; }
        public Brand Brand { get; set; }
    }
}
