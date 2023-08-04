using LuxuryWhaches.BisnessLayer.Concreate;
using LuxuryWhaches.DataAcsessLayer.EFRepository;
using Microsoft.AspNetCore.Mvc;

namespace LuxsuryWhatches.ViewComponents
{
	public class Category : ViewComponent
	{
		CategoryManeger categoryManeger = new CategoryManeger(new EFCategoryDAl());

		public IViewComponentResult Invoke()
		{
			var values = categoryManeger.TGetAll();
			return View(values);
		}
	}
}
