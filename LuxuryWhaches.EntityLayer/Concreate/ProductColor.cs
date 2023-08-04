using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuxuryWhaches.EntityLayer.Concreate
{
	public class ProductColor
	{
		[Key]
		public int ProductColorID { get; set; }
		public string ProductColorName { get; set; }
		public bool ProductColorStatus { get; set; }
		public List<Product> Products { get; set; }

	}
}
