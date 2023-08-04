using LuxuryWhaches.BisnessLayer.Abstract;
using LuxuryWhaches.DataAcsessLayer.Abstract;
using LuxuryWhaches.EntityLayer.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LuxuryWhaches.BisnessLayer.Concreate
{
	public class ProductManeger:IProductServices
	{
		IProductDal _productDal;

		public ProductManeger(IProductDal productDal)
		{
			_productDal = productDal;
		}

		public void TDelete(Product t)
		{
			_productDal.Delete(t);
		}

		public List<Product> TGetAll()
		{
			return _productDal.GetAll();
		}

		public Product TGetByID(int id)
		{
			return _productDal.GetByID(id);
		}

		public void TInsert(Product t)
		{
			_productDal.Insert(t);
		}

		public List<Product> TListForFilter(Expression<Func<Product, bool>> filter)
		{
			return _productDal.ListForFilter(filter);
		}

		public List<Product> TListProductWithCategory()
		{
			return _productDal.ListProductWithCategory();
		}

		public void TUpdate(Product t)
		{
			_productDal.Update(t);
		}
	}
}
