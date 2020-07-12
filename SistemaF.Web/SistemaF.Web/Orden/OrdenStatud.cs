using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema.Web.Data.Orden
{
    public class OrdenStatud
    {
        public enum OrderStatus
        {
            Created,
            InProgress,
            Shipped,
            Delivered
        }
    }
}
