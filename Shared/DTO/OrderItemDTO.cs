using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using work_01.Shared.Models;

namespace work_01.Shared.DTO
{
	public class OrderItemDTO
	{
		[ForeignKey("Order")]
		public int OrderID { get; set; }
		[ForeignKey("Product")]
		public int ProductID { get; set; }

		public int Quantity { get; set; }

		
	}
}
