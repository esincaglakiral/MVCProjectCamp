using BusinessLayer.Concrete;
using DataAccessLayer.Concrete.Repositories;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class StatisticController : Controller
    {
        CategoryManager cm = new CategoryManager(new EFCategoryDal());
        HeadingManager hm = new HeadingManager(new EFHeadingDal()); // HeadingManager ve EFHeadingDal eklendi

        public ActionResult Index()
        {
            var categories = cm.GetList();
            var headings = hm.GetList(); // Tüm başlıkları almak için

            // 1) Toplam kategori sayısı
            ViewBag.TotalCategoryCount = categories.Count();

            // 2) Başlık tablosunda "yazılım" kategorisine ait başlık sayısı
            var softwareCategoryHeadingsCount = headings
                .Count(h => h.Category.CategoryName.ToLower() == "yazılım");
            ViewBag.SoftwareCategoryHeadingsCount = softwareCategoryHeadingsCount;

            // 3) Yazar adında 'a' harfi geçen yazar sayısı
            var writerNamesWithA = headings
                .Select(h => h.Writer.WriterName.ToLower())
                .Where(name => name.Contains("a"))
                .Distinct() // Tekrar eden isimleri almayı önlemek için
                .Count();
            ViewBag.WritersWithAInNameCount = writerNamesWithA;

            // 4) En fazla başlığa sahip kategori adı
            var categoryWithMostHeadings = headings
                .GroupBy(h => h.Category.CategoryName)
                .OrderByDescending(g => g.Count())
                .Select(g => g.Key)
                .FirstOrDefault();
            ViewBag.CategoryWithMostHeadings = categoryWithMostHeadings;

            // 5) Kategori tablosunda durumu true olan kategoriler ile false olan kategoriler arasındaki sayısal fark
            var trueCategoryCount = categories.Count(c => c.CategoryStatus);
            var falseCategoryCount = categories.Count(c => !c.CategoryStatus);
            ViewBag.CategoryStatusDifference = Math.Abs(trueCategoryCount - falseCategoryCount);

            return View();
        }
    }
}