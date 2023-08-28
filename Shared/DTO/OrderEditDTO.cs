using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using work_01.Shared.Models;

namespace work_01.Shared.DTO
{
	public class OrderEditDTO
	{
		public int OrderID { get; set; }
		[Required, Column(TypeName = "date"), Display(Name = "Order Date"), DisplayFormat(DataFormatString = "{yyyy-MM-dd}", ApplyFormatInEditMode = true)]
		public DateTime OrderDate { get; set; }
		[Required, Column(TypeName = "date"), Display(Name = "DeliveryDate Date"), DisplayFormat(DataFormatString = "{yyyy-MM-dd}", ApplyFormatInEditMode = true)]
		public DateTime DeliveryDate { get; set; }
		[Required, EnumDataType(typeof(Status))]
		public Status Status { get; set; }

		[ForeignKey("Customer"), Required, Display(Name = "Customer")]
		public int CustomerID { get; set; }
		public Customer Customer { get; set; } = default!;
		public virtual ICollection<OrderItemDTO> OrderItems { get; set; } = new List<OrderItemDTO>();
	}
}
