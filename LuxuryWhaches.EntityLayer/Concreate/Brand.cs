using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuxuryWhaches.EntityLayer.Concreate
{
	public class Brand
	{
		[Key]
		public int BrandID { get; set; }
		public string BrandName { get; set; }
		public bool BrandStatus { get; set; }
		public List<Product> Products { get; set; }

	}
}
