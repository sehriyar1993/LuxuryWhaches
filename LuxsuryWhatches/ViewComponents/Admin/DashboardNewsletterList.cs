using LuxuryWhaches.BisnessLayer.Concreate;
using LuxuryWhaches.DataAcsessLayer.EFRepository;
using Microsoft.AspNetCore.Mvc;

namespace LuxsuryWhatches.ViewComponents.Admin
{
	public class DashboardNewsletterList : ViewComponent
	{
		NewsletterManager cm = new NewsletterManager(new EFNewsletterDal());
		public IViewComponentResult Invoke()
		{
			var values = cm.TGetAll();
			return View(values);
		}
	}
}
