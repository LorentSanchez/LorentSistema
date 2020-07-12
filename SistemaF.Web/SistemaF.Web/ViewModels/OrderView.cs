using Sistema.Web.Data.Entities;
using Sistema.Web.Data.Orden;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema.Web.ViewModels
{
    public class OrderView
    {
        public Customer customer { get; set; }
        public ProductOrder Product { get; set; }
        public virtual List<ProductOrder> Products { get; set; }

    }
}
