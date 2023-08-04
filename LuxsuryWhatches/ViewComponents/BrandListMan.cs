using LuxuryWhaches.BisnessLayer.Concreate;
using LuxuryWhaches.DataAcsessLayer.EFRepository;
using Microsoft.AspNetCore.Mvc;

namespace LuxsuryWhatches.ViewComponents
{
	public class BrandListMan : ViewComponent
	{
		BrandManeger bm = new BrandManeger(new EFBrandDal());

		public IViewComponentResult Invoke()
		{
			var values = bm.TGetAll();
			return View(values);
		}
	}
}
