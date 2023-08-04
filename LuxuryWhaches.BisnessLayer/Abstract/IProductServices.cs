using LuxuryWhaches.EntityLayer.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuxuryWhaches.BisnessLayer.Abstract
{
	public interface IProductServices:IGenericServices<Product>
	{
		List<Product> TListProductWithCategory();

	}
}
