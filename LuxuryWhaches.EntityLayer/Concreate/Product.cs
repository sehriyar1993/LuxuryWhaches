using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuxuryWhaches.EntityLayer.Concreate
{
	public class Product
	{
        [Key]
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public string ProductGender { get; set; }
        public double ProductPrice { get; set; }
        public double CellPrice { get; set; }
        public double ProductSize { get; set; }
        public double ProductStock { get; set; }
        public string DiscountedPrice { get; set; }
        public string ProductAbout { get; set; }
        public string ProductModel{ get; set; }
        public string ProductImage1{ get; set; }
        public string ProductImage2{ get; set; }
        public string ProductImage3{ get; set; }
        public bool ProductStatus{ get; set; }

        public int CategoryID { get; set; }
        public Category Category { get; set; }

		public int BrandID { get; set; }
		public Brand Brand { get; set; }

		public int ProductColorID { get; set; }
		public ProductColor ProductColor { get; set; }

        public List<Order> Orders { get; set; }
	}
}
