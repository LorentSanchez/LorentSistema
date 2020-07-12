using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Sistema.Web.Data.Entities;

namespace Sistema.Web.Data.Orden
{
    public class ProductOrder : Article
    {
        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = false)]
        public float Quantity { get; set; }

        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:n2}", ApplyFormatInEditMode = false)]
        public decimal Value { get { return (decimal)Price * (decimal)Stock; } }
    }
}
