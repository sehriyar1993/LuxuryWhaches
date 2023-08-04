using LuxuryWhaches.BisnessLayer.Concreate;
using LuxuryWhaches.DataAcsessLayer.Concreate;
using LuxuryWhaches.DataAcsessLayer.EFRepository;
using LuxuryWhaches.EntityLayer.Concreate;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using X.PagedList;

namespace LuxsuryWhatches.Controllers
{
	[AllowAnonymous]

	public class DefaultController : Controller
	{
		private readonly UserManager<AppUser> _userManager;

		ProductManeger pm = new ProductManeger(new EFProductDal());

		public DefaultController(UserManager<AppUser> userManager)
		{
			_userManager = userManager;
		}

		public async Task<IActionResult> Index()
		{
			if (User.Identity.IsAuthenticated)
			{
				var user = await _userManager.FindByNameAsync(User.Identity.Name);
				ViewBag.UserId = user.Id;
			}
			else
			{

			}
			var values = pm.TGetAll();
			return View(values);
		}
		public async Task<IActionResult> ProductDetails(int id)
		{
			if (User.Identity.IsAuthenticated)
			{
				var user = await _userManager.FindByNameAsync(User.Identity.Name);
				ViewBag.UserId = user.Id;
			}
			else
			{

			}
			var values = pm.TGetByID(id);
			return View(values);
		}
		public async Task<IActionResult> Product(string searchString, int page = 1)
		{
			if (User.Identity.IsAuthenticated)
			{
				var user = await _userManager.FindByNameAsync(User.Identity.Name);
				ViewBag.UserId = user.Id;
			}
			else
			{

			}
			if (searchString != null)
				searchString = searchString.ToLower();
			ViewData["CurrentFilter"]= searchString;
			var values = from x in pm.TGetAll().OrderByDescending(x=>x.ProductID) select x;
			if(!string.IsNullOrEmpty(searchString))
			{
				values=values.Where(m=>m.ProductName.ToLower().Contains(searchString) ||m.ProductModel.ToLower().Contains(searchString) || m.ProductAbout.ToLower().Contains(searchString));
			}
			//var values = pm.TGetAll();
			return View(values.ToPagedList(page, 12));

		}

		public async Task<IActionResult> ProductMen(int page = 1)
		{
			if (User.Identity.IsAuthenticated)
			{
				var user = await _userManager.FindByNameAsync(User.Identity.Name);
				ViewBag.UserId = user.Id;
			}
			else
			{

			}
			var values = pm.TGetAll();
			return View(values.Where(x=>x.ProductGender == "Kişi").ToPagedList(page, 12));
		}
		public async Task<IActionResult> ProductWomen(int page = 1)
		{
			if (User.Identity.IsAuthenticated)
			{
				var user = await _userManager.FindByNameAsync(User.Identity.Name);
				ViewBag.UserId = user.Id;
			}
			else
			{

			}
			var values = pm.TGetAll();
			return View(values.Where(x => x.ProductGender == "Qadın").ToPagedList(page, 12));
		}

        public async Task<IActionResult> GetproductWithcategoryIdWoman(int id,int page = 1)
        {
			if (User.Identity.IsAuthenticated)
			{
				var user = await _userManager.FindByNameAsync(User.Identity.Name);
				ViewBag.UserId = user.Id;
			}
			else
			{

			}
			var values = pm.TListForFilter(x=>x.CategoryID == id);
            return View(values.Where(x => x.ProductGender == "Qadın").ToPagedList(page, 12));
        }
		public async Task<IActionResult> GetproductWithcategoryIdMan(int id, int page = 1)
		{
			if (User.Identity.IsAuthenticated)
			{
				var user = await _userManager.FindByNameAsync(User.Identity.Name);
				ViewBag.UserId = user.Id;
			}
			else
			{

			}
			var values = pm.TListForFilter(x => x.CategoryID == id);
			return View(values.Where(x => x.ProductGender == "Kişi").ToPagedList(page, 12));
		}
        public async Task<IActionResult> GetProductForBrandWoman(int id, int page = 1)
        {
			if (User.Identity.IsAuthenticated)
			{
				var user = await _userManager.FindByNameAsync(User.Identity.Name);
				ViewBag.UserId = user.Id;
			}
			else
			{

			}
			var values = pm.TListForFilter(x => x.BrandID == id);
            return View(values.Where(x => x.ProductGender == "Qadın").ToPagedList(page, 12));
        }
        public async Task<IActionResult> GetProductForBrandMan(int id, int page = 1)
        {
			if (User.Identity.IsAuthenticated)
			{
				var user = await _userManager.FindByNameAsync(User.Identity.Name);
				ViewBag.UserId = user.Id;
			}
			else
			{

			}
			var values = pm.TListForFilter(x => x.BrandID == id);
            return View(values.Where(x => x.ProductGender == "Kişi").ToPagedList(page, 12));
        }
		public async Task<IActionResult> ProductCategory(int id, int page = 1)
		{
			if (User.Identity.IsAuthenticated)
			{
				var user = await _userManager.FindByNameAsync(User.Identity.Name);
				ViewBag.UserId = user.Id;
			}
			else
			{

			}
			var values = pm.TListForFilter(x => x.CategoryID == id);
			return View(values.ToPagedList(page, 12));
		}
		public async Task<IActionResult> ProductBrand(int id, int page = 1)
		{
			if (User.Identity.IsAuthenticated)
			{
				var user = await _userManager.FindByNameAsync(User.Identity.Name);
				ViewBag.UserId = user.Id;
			}
			else
			{

			}
			var values = pm.TListForFilter(x => x.BrandID == id);
			return View(values.ToPagedList(page, 12));
		}
		
	}
}
