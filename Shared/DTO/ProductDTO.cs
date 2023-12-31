﻿using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using work_01.Shared.Models;

namespace work_01.Shared.DTO
{
	public class ProductDTO
	{
		public int ProductID { get; set; }

		public string ProductName { get; set; } = default!;
		[Required, Column(TypeName = "money"), DisplayFormat(DataFormatString = "{0:0.00}")]
		public decimal Price { get; set; }
		[Required, StringLength(150)]
		public string Picture { get; set; } = default!;
		public bool IsAvailable { get; set; }

		

	}
}
