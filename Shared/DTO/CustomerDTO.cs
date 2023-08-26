﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using work_01.Shared.Models;

namespace work_01.Shared.DTO
{
	public class CustomerDTO
	{
		[Key]
		public int CustomerID { get; set; }
		[Required, StringLength(50), Display(Name = "Customer Name")]
		public string CustomerName { get; set; } = default!;
		[Required, StringLength(250)]
		public string Address { get; set; } = default!;
		[Required, StringLength(50), EmailAddress]
		public string Email { get; set; } = default!;

		public bool CanDelete { get; set; }
	}
}
