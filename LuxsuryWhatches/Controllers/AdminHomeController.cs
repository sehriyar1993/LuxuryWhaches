using LuxuryWhaches.BisnessLayer.Concreate;
using LuxuryWhaches.DataAcsessLayer.EFRepository;
using LuxuryWhaches.EntityLayer.Concreate;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using X.PagedList;

namespace LuxsuryWhatches.Controllers
{
	[Authorize(Roles = "Admin")]
	public class AdminHomeController : Controller
	{
		ProductManeger pm = new ProductManeger(new EFProductDal());
		CategoryManeger cm = new CategoryManeger(new EFCategoryDAl());
		BrandManeger bm = new BrandManeger(new EFBrandDal());
		ColorManager color = new ColorManager(new EFColorDal());
		public IActionResult Index(string searchString, int page = 1)
		{
            if (searchString != null)
                searchString = searchString.ToLower();
            ViewData["CurrentFilter"] = searchString;
            var values = from x in pm.TListProductWithCategory().OrderByDescending(x => x.ProductID) select x;
            if (!string.IsNullOrEmpty(searchString))
            {
                values = values.Where(m => m.ProductName.ToLower().Contains(searchString) || m.ProductModel.ToLower().Contains(searchString) || m.ProductAbout.ToLower().Contains(searchString));
            }
            //var values = pm.TListProductWithCategory();
            return View(values.ToPagedList(page, 12));
		}
		public IActionResult DeleteProduct(int id)
		{
			var values = pm.TGetByID(id);
			pm.TDelete(values);
			return RedirectToAction("Index");
		}
		[HttpGet]
		public IActionResult AddProduct()
		{
			List<SelectListItem> values = (from x in cm.TGetAll()
										   select new SelectListItem
										   {
											   Text = x.CategoryName,
											   Value = x.CategoryID.ToString(),
										   }).ToList();
			ViewBag.cat = values;
			List<SelectListItem> value = (from x in bm.TGetAll()
										  select new SelectListItem
										  {
											  Text = x.BrandName,
											  Value = x.BrandID.ToString(),
										  }).ToList();
			ViewBag.brend = value;
			List<SelectListItem> colorproduct = (from x in color.TGetAll()
										  select new SelectListItem
										  {
											  Text = x.ProductColorName,
											  Value = x.ProductColorID.ToString(),
										  }).ToList();
			ViewBag.color = colorproduct;
			return View();
		}
		[HttpPost]
		public IActionResult AddProduct(Product product)
		{
			product.ProductStatus = true;
			pm.TInsert(product);
			return RedirectToAction("Index");

		}
		[HttpGet]
		public IActionResult UpdateProduct(int id)
		{
			List<SelectListItem> values = (from x in cm.TGetAll()
										   select new SelectListItem
										   {
											   Text = x.CategoryName,
											   Value = x.CategoryID.ToString(),
										   }).ToList();
			ViewBag.cat = values;
			List<SelectListItem> value = (from x in bm.TGetAll()
										  select new SelectListItem
										  {
											  Text = x.BrandName,
											  Value = x.BrandID.ToString(),
										  }).ToList();
			ViewBag.brend = value;
			List<SelectListItem> colorproduct = (from x in color.TGetAll()
												 select new SelectListItem
												 {
													 Text = x.ProductColorName,
													 Value = x.ProductColorID.ToString(),
												 }).ToList();
			ViewBag.color = colorproduct;
			var pro = pm.TGetByID(id);
			return View(pro);
		}
		[HttpPost]
		public IActionResult UpdateProduct(Product product)
		{
			pm.TUpdate(product);
			return RedirectToAction("Index");

		}
	}
}
