using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LuxuryWhaches.DataAcsessLayer.Abstract
{
	public interface IGenericDal<T>
	{
		void Insert(T t);
		void Update(T t);
		void Delete(T t);
		List<T> GetAll();
		T GetByID(int id);
		List<T> ListForFilter(Expression<Func<T, bool>> filter);
	}
}
