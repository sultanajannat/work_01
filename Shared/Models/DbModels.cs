using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace work_01.Shared.Models
{
	public enum Status
	{
       Pending=1,
	   Deliver,
	   Cancelled


    }
	public class Customer
	{
        public int CustomerID { get; set; }
		[Required,StringLength(50),Display(Name = "Customer Name")]
        public string CustomerName { get; set; } = default!;
		[Required, StringLength(250)]
		public string Address { get; set; } = default!;
		[Required, StringLength(50),EmailAddress]
		public string Email { get; set; } = default!;

		public virtual ICollection<Order> Orders { get; set; }=new List<Order>();
	}
	public class Order
	{
        public int OrderID { get; set; }
		[Required,Column(TypeName ="date"),Display(Name ="Order Date"),DisplayFormat(DataFormatString ="{yyyy-MM-dd}",ApplyFormatInEditMode =true)]
        public DateTime OrderDate { get; set; }
		[Required, Column(TypeName = "date"), Display(Name = "DeliveryDate Date"), DisplayFormat(DataFormatString = "{yyyy-MM-dd}", ApplyFormatInEditMode = true)]
		public DateTime DeliveryDate { get; set; }
		[Required,EnumDataType(typeof(Status))]
        public Status Status { get; set; }

		[ForeignKey("Customer"),Required,Display(Name ="Customer")]
		public int CustomerID { get; set; }
		public Customer Customer { get; set; } = default!;
		public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();


	}
	public class Product
	{
		public int ProductID { get; set; }

		public string ProductName { get; set; } = default!;

		//public string ProductDescription { get; set; }

		//public string ProductCategoryID { get; set;}

		//public string ProductCategoryName { get; set;}

		//public string ProductCategoryDescription { get; set;}
		[Required,Column(TypeName ="money"),DisplayFormat(DataFormatString ="{0:0.00}")]
		public decimal Price { get; set; }
		[Required,StringLength(150)]
        public string Picture { get; set; } = default!;
		public bool IsAvailable { get; set; }

		public virtual ICollection<OrderItem> OrderItems { get; set; }=new List<OrderItem>();

	}
	public class OrderItem
	{
		[ForeignKey("Order")]
		public int OrderID { get; set; }
		[ForeignKey("Product")]
		public int ProductID { get; set; }

		public int Quantity { get; set; }

		public virtual Order Order { get; set; } = default!;

		public virtual Product Product { get; set; } = default!;
	}
}
