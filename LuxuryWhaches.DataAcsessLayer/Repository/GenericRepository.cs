using LuxuryWhaches.DataAcsessLayer.Abstract;
using LuxuryWhaches.DataAcsessLayer.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LuxuryWhaches.DataAcsessLayer.Repository
{
	public class GenericRepository<T> : IGenericDal<T> where T : class
	{
		public void Delete(T t)
		{
			using var c = new Context();
			c.Remove(t);
			c.SaveChanges();
		}

		public List<T> GetAll()
		{
			using var c = new Context();
			return c.Set<T>().ToList();
		}

		public T GetByID(int id)
		{
			using var c = new Context();
			return c.Set<T>().Find(id);
		}

		public void Insert(T t)
		{
			using var c = new Context();
			c.Add(t);
			c.SaveChanges();
		}

		public List<T> ListForFilter(Expression<Func<T, bool>> filter)
		{
			using var c = new Context();
			return c.Set<T>().Where(filter).ToList();
		}

		public void Update(T t)
		{
			using var c = new Context();
			c.Update(t);
			c.SaveChanges();
		}
	}
}
