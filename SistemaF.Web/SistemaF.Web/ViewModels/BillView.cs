using Sistema.Web.Data.OrdenTemp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema.Web.ViewModels
{
    public class BillView
    {
        public Order Order { get; set; }



        public OrderDetail OrderDetail { get; set; }
        public virtual List<OrderDetail> OrderDetails { get; set; }
    }
}
