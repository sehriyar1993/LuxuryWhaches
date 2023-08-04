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
	public class OrderManager:IOrderServices
	{
		IOrderDal _orderDal;

		public OrderManager(IOrderDal orderDal)
		{
			_orderDal = orderDal;
		}

		public void TDelete(Order t)
		{
			_orderDal.Delete(t);
		}

		public List<Order> TGetAll()
		{
			return _orderDal.GetAll();	
		}

		public Order TGetByID(int id)
		{
			return _orderDal.GetByID(id);
		}

		public void TInsert(Order t)
		{
			_orderDal.Insert(t);
		}

		public List<Order> TListForFilter(Expression<Func<Order, bool>> filter)
		{
			throw new NotImplementedException();
		}

		public void TUpdate(Order t)
		{
			_orderDal.Update(t);
		}
	}
}
