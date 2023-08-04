using LuxuryWhaches.BisnessLayer.Concreate;
using LuxuryWhaches.DataAcsessLayer.EFRepository;
using LuxuryWhaches.EntityLayer.Concreate;
using Microsoft.AspNetCore.Mvc;

namespace LuxsuryWhatches.Controllers
{
	public class OrderController : Controller
	{

		OrderManager om = new OrderManager(new EFOrderDal());
		[HttpGet]
		public IActionResult Index()
		{
			return View();
		}
		[HttpPost]
		public IActionResult Index(Order p)
		{
			p.OrderCost = 1;
			p.Status = "Təsdiq Gözləyir";
			p.OrderDate= DateTime.Parse(DateTime.Now.ToShortDateString());
			om.TInsert(p);
			return RedirectToAction("Index", "Default");
		}
		public IActionResult OrderBag() 
		{ 
			var values = om.TGetAll();
			return View(values.Where(x=>x.Status== "Təsdiq Gözləyir"));	
		}
		public IActionResult OrderBagApproval()
		{
			var values = om.TGetAll();
			return View(values.Where(x => x.Status == "Təsdilənmiş"));
		}
		public IActionResult OrderBagDedline()
		{
			var values = om.TGetAll();
			return View(values.Where(x => x.Status == "Müddəti Bitmiş"));
		}
		public IActionResult OrderDelete(int id)
		{
			var values = om.TGetByID(id);
			om.TDelete(values);
			return RedirectToAction("OrderBag");
		}
	}
}
