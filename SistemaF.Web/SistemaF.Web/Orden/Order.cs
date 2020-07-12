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
		public int Id { get; set; }

		[Required]
		[Display(Name = "Order date")]
		[DisplayFormat(DataFormatString = "{0:yyyy/MM/dd hh:mm tt}", ApplyFormatInEditMode = false)]
		public DateTime OrderDate { get; set; }

		[Display(Name = "Delivery date")]
		[DisplayFormat(DataFormatString = "{0:yyyy/MM/dd hh:mm tt}", ApplyFormatInEditMode = false)]
		public DateTime? DeliveryDate { get; set; }
		[Key]
		
		public int ClientID { get; set; }
		public OrdenStatud OrderStatud { get; set; }

		
		public virtual ICollection<OrderDetail> OrderDetails { get; set; }

		public int supplierID { get; set; }

		public Customer Customers { get; set; }

		public IEnumerable<OrderDetail> Items { get; set; }

		[DisplayFormat(DataFormatString = "{0:N2}")]
		public double Quantity { get { return this.Items == null ? 0 : this.Items.Sum(i => i.Quantity); } }

		[DisplayFormat(DataFormatString = "{0:C2}")]
		public decimal Value { get { return this.Items == null ? 0 : this.Items.Sum(i => i.Value); } }

	}
}
