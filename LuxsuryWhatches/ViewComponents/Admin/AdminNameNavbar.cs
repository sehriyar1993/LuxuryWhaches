using LuxuryWhaches.DataAcsessLayer.Concreate;
using Microsoft.AspNetCore.Mvc;

namespace LuxsuryWhatches.ViewComponents.Admin
{
	public class AdminNameNavbar:ViewComponent
	{
		Context c = new Context();
		public IViewComponentResult Invoke()
		{
			var user = User.Identity.Name;
			ViewBag.username = c.Users.Where(x=>x.UserName ==  user).Select(x=>x.Name).FirstOrDefault();
			ViewBag.usersurname = c.Users.Where(x=>x.UserName ==  user).Select(x=>x.Surname).FirstOrDefault();
			ViewBag.userimage = c.Users.Where(x=>x.UserName ==  user).Select(x=>x.ImageUrl).FirstOrDefault();
			ViewBag.usermail = c.Users.Where(x=>x.UserName ==  user).Select(x=>x.Email).FirstOrDefault();
			return View();
		}
	}
}
