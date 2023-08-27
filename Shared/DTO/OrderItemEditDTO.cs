using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace work_01.Shared.DTO
{
	public class OrderItemEditDTO
	{
		[Key]
		public int OrderID { get; set; }
		[Required]
		public int ProductID { get; set; }
		[Required]
		public decimal Price { get; set; }
		[Required]
		public int Quantity { get; set; }
	}
}
