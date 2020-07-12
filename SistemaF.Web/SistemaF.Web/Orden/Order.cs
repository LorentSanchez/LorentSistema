using Sistema.Web.Data.Entities;
using Sistema.Web.Data.Orden;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema.Web.Data.OrdenTemp
{
    public class Order
    {
        [Key]
        public int OrderID { get; set; }
        public DateTime OrderDate { get; set; }

      
        public OrdenStatud OrderStatuds { get; set; }

        public virtual Customer Customers { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }

        public int supplier_Id { get; set; }
    }
}
