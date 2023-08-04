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
	public class CategoryManeger:ICategoryServices
	{
		ICategoryDal _categoryDAl;

		public CategoryManeger(ICategoryDal categoryDAl)
		{
			_categoryDAl = categoryDAl;
		}

		public void TDelete(Category t)
		{
			_categoryDAl.Delete(t);
		}

		public List<Category> TGetAll()
		{
			return _categoryDAl.GetAll();
		}

		public Category TGetByID(int id)
		{
			return _categoryDAl.GetByID(id);
		}

		public void TInsert(Category t)
		{
			_categoryDAl.Insert(t);
		}

		public List<Category> TListForFilter(Expression<Func<Category, bool>> filter)
		{
			throw new NotImplementedException();
		}

		public void TUpdate(Category t)
		{
			_categoryDAl.Update(t);
		}
	}
}
