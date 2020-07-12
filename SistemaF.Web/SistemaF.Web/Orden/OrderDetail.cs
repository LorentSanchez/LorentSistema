using Sistema.Web.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema.Web.Data.OrdenTemp
{
    public class OrderDetail
    {
        
        [Key]
        public int OrderDetail_Id { get; set; }
        public int OrderID { get; set; }

        public int ArtC_Id { get; set; }

        public string Descripcion { get; set; }

        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = false)]
        public int OrderPrice { get; set; }

        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:n2}", ApplyFormatInEditMode = false)]
        public float Cantidad { get; set; }

        public virtual Order Orders { get; set; }
        [DisplayFormat(DataFormatString = "{0:C2}")]
        public decimal Valor { get { return this.OrderPrice * (decimal)this.Cantidad; } }



    }
}
