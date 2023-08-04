using LuxuryWhaches.BisnessLayer.Concreate;
using LuxuryWhaches.DataAcsessLayer.EFRepository;
using Microsoft.AspNetCore.Mvc;

namespace LuxsuryWhatches.ViewComponents
{
	public class LastTreePost: ViewComponent
	{
		ProductManeger pm = new ProductManeger(new EFProductDal());

		public IViewComponentResult Invoke()
		{
			var values = pm.TGetAll();
			return View(values);
		}
	}
}
