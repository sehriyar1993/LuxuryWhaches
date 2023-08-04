using LuxuryWhaches.DataAcsessLayer.Abstract;
using LuxuryWhaches.DataAcsessLayer.Concreate;
using LuxuryWhaches.DataAcsessLayer.Repository;
using LuxuryWhaches.EntityLayer.Concreate;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuxuryWhaches.DataAcsessLayer.EFRepository
{
	public class EFProductDal:GenericRepository<Product>, IProductDal
	{
		public List<Product> ListProductWithCategory()
		{
			using(var context = new Context())
			{
				return context.Products.Include(m=>m.Category).Include(m=>m.Brand).ToList();
			}
		}
	}
}
