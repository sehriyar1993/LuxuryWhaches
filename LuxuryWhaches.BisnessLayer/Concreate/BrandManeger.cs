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
	public class BrandManeger:IBrandServices
	{
		IBrandDal _brandDal;

		public BrandManeger(IBrandDal brandDal)
		{
			_brandDal = brandDal;
		}

		public void TDelete(Brand t)
		{
			_brandDal.Delete(t);
		}

		public List<Brand> TGetAll()
		{
			return _brandDal.GetAll();
		}

		public Brand TGetByID(int id)
		{
			return _brandDal.GetByID(id);
		}

		public void TInsert(Brand t)
		{
			_brandDal.Insert(t);
		}

		public List<Brand> TListForFilter(Expression<Func<Brand, bool>> filter)
		{
			throw new NotImplementedException();
		}

		public void TUpdate(Brand t)
		{
			_brandDal.Update(t);
		}
	}
}
