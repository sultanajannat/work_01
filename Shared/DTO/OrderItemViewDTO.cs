using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace work_01.Shared.DTO
{
	public class OrderItemViewDTO
	{
		
		public int OrderID { get; set; }
		public string ProductName { get; set; } = default!;
		
		
		[Required]
		public decimal Price { get; set; }
		[Required]
		public int Quantity { get; set; }
	}
}
