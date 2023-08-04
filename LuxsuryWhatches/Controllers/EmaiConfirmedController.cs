using LuxsuryWhatches.Models;
using LuxuryWhaches.EntityLayer.Concreate;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace LuxsuryWhatches.Controllers
{
	[AllowAnonymous]

	public class EmaiConfirmedController : Controller
	{
		private readonly UserManager<AppUser> _userManager;

		public EmaiConfirmedController(UserManager<AppUser> userManager)
		{
			_userManager = userManager;
		}

		[HttpGet]
		public IActionResult Index()
		{
			var valueb = TempData["Mail"];
			ViewBag.Value = valueb;	
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> Index(ComfirmMailViewModel p)
		{
			var user = await _userManager.FindByEmailAsync(p.Mail);
			if(user.ComfirmCode == p.ComfirmCode)
			{
				user.EmailConfirmed = true;
				await _userManager.UpdateAsync(user);
				return RedirectToAction("SingIn", "Profile");
			}
			return View();
		}
	}
}
