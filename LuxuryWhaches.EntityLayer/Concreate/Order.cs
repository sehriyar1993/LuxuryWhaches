using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuxuryWhaches.EntityLayer.Concreate
{
	public class Order
	{
		[Key]
		public int OrderID { get; set; }
		public string Status { get; set; }
		public double OrderCost { get; set; }
		public DateTime OrderDate { get; set; }
		public string ProductGender { get; set; }
		public string ProductName { get; set; }
		public string DiscountedPrice { get; set; }
		public string ProductImage1 { get; set; }

		public int ProductID { get; set; }
		public Product Product { get; set; }

		public int AppUserId { get; set; }
		public AppUser AppUser { get; set; }
	}
}
