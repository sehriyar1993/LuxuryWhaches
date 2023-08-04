using LuxuryWhaches.BisnessLayer.Concreate;
using LuxuryWhaches.DataAcsessLayer.Concreate;
using LuxuryWhaches.DataAcsessLayer.EFRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace LuxsuryWhatches.Controllers
{
	[Authorize(Roles = "Admin")]
	public class AdminDashboardController : Controller
	{
		ProductManeger product = new ProductManeger(new EFProductDal());
		Context c = new Context();
		public async Task<IActionResult> Index()
		{
			
			var client = new HttpClient();
			var request = new HttpRequestMessage
			{
				Method = HttpMethod.Get,
				RequestUri = new Uri("https://currency-exchange.p.rapidapi.com/exchange?from=USD&to=AZN&q=1.0"),
				Headers =
	{
		{ "X-RapidAPI-Key", "91f0b3875emsh29d9702062a63e5p118be4jsn91c12885f9ee" },
		{ "X-RapidAPI-Host", "currency-exchange.p.rapidapi.com" },
	},
			};
			using (var response = await client.SendAsync(request))
			{
				response.EnsureSuccessStatusCode();
				var body = await response.Content.ReadAsStringAsync();
				ViewBag.currency = body;
			}
			ViewBag.user = c.Users.Count();
			ViewBag.cateqory = c.Categories.Count();
			ViewBag.product = c.Products.Count();
			ViewBag.brend = c.Brands.Count();
			var values = product.TGetAll();
			return View(values);
		}
	}
}
