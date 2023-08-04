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
	public class NewsletterManager:INewsLetterServices
	{
		INewsLetterdal _newsletterDal;

		public NewsletterManager(INewsLetterdal newsletterDal)
		{
			_newsletterDal = newsletterDal;
		}

		public void TDelete(NewsLetter t)
		{
			_newsletterDal.Delete(t);
		}

		public List<NewsLetter> TGetAll()
		{
			return _newsletterDal.GetAll();
		}

		public NewsLetter TGetByID(int id)
		{
			return _newsletterDal.GetByID(id);
		}

		public void TInsert(NewsLetter t)
		{
			_newsletterDal.Insert(t);
		}

		public List<NewsLetter> TListForFilter(Expression<Func<NewsLetter, bool>> filter)
		{
			throw new NotImplementedException();
		}

		public void TUpdate(NewsLetter t)
		{
			_newsletterDal.Update(t);
		}
	}
}
