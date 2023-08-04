using LuxuryWhaches.BisnessLayer.Concreate;
using LuxuryWhaches.DataAcsessLayer.Concreate;
using LuxuryWhaches.DataAcsessLayer.EFRepository;
using LuxuryWhaches.EntityLayer.Concreate;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LuxsuryWhatches.Controllers
{
	[Authorize(Roles = "Admin")]
	public class AdminColorController : Controller
    {
        ColorManager cm = new ColorManager(new EFColorDal());
        public IActionResult Index()
        {
            var values = cm.TGetAll();
            return View(values);
        }
        [HttpGet]
        public IActionResult Add()
        {

            return View();
        }
        [HttpPost]
        public IActionResult Add(ProductColor c)
        {
            c.ProductColorStatus = true;
            cm.TInsert(c);
            return RedirectToAction("Index");

        }
        public IActionResult Delete(int id)
        {
            var values = cm.TGetByID(id);
            cm.TDelete(values);
            return RedirectToAction("Index");

        }
        public IActionResult ChangeToFolse(int id)
        {
            Context c = new Context();
            var values = c.ProductColors.Find(id);
            values.ProductColorStatus = false;
            c.Update(values);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult ChangeToTrue(int id)
        {
            Context c = new Context();
            var value = c.ProductColors.Find(id);
            value.ProductColorStatus = true;
            c.Update(value);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]

        public IActionResult Update(int id)
        {
            var values = cm.TGetByID(id);
            return View(values);
        }
        [HttpPost]
        public IActionResult Update(ProductColor c)
        {
            cm.TUpdate(c);
            return RedirectToAction("Index");

        }
    }
}
