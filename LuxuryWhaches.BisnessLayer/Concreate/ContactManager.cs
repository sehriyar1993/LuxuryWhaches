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
	public class ContactManager:IContactServices
	{
		IContactDal _contactDal;

		public ContactManager(IContactDal contactDal)
		{
			_contactDal = contactDal;
		}

		public void TDelete(Contact t)
		{
			_contactDal.Delete(t);	
		}

		public List<Contact> TGetAll()
		{
			return _contactDal.GetAll();
		}

		public Contact TGetByID(int id)
		{
			return _contactDal.GetByID(id);
		}

		public void TInsert(Contact t)
		{
			_contactDal.Insert(t);
		}

		public List<Contact> TListForFilter(Expression<Func<Contact, bool>> filter)
		{
			throw new NotImplementedException();
		}

		public void TUpdate(Contact t)
		{
			_contactDal.Update(t);
		}
	}
}
