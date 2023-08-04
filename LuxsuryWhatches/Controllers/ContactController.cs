using LuxuryWhaches.BisnessLayer.Concreate;
using LuxuryWhaches.DataAcsessLayer.EFRepository;
using LuxuryWhaches.EntityLayer.Concreate;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LuxsuryWhatches.Controllers
{
	[AllowAnonymous]
	public class ContactController : Controller
	{
		NewsletterManager nm = new NewsletterManager(new EFNewsletterDal());
		ContactManager cm = new ContactManager(new EFContactDal());
		[HttpGet]
		public IActionResult Index()
		{
			return View();
		}
		[HttpPost]
		public IActionResult Index(Contact c)
		{
			c.ContactStatus = true;
			c.ContactDate = DateTime.Parse(DateTime.Now.ToLongDateString());
			cm.TInsert(c);
			return RedirectToAction("Index");
		}
		[HttpGet]
		public IActionResult NewsLetterSend()
		{
			return View();
		}
		[HttpPost]
		public IActionResult NewsLetterSend(NewsLetter c)
		{
			c.Status = true;
			nm.TInsert(c);
			return RedirectToAction("Index");
		}
	}
}
