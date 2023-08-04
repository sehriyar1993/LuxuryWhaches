using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LuxuryWhaches.BisnessLayer.Abstract
{
	public interface IGenericServices<T>
	{
		void TInsert(T t);
		void TUpdate(T t);
		void TDelete(T t);
		List<T> TGetAll();
		T TGetByID(int id);
		List<T> TListForFilter(Expression<Func<T, bool>> filter);
	}
}
