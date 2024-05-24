using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        CategoryManager cm = new CategoryManager(new EFCategoryDal()); //CategoryManager içerisine EFCategoryDal'dan parametre gönderiyoruz.

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetCategoryList()
        {
            var categoryValues = cm.GetList();
            return View(categoryValues);
        }

        [HttpGet]
        public ActionResult AddCategory()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddCategory(Category p)
        {
            CategoryValidator categoryValidator = new CategoryValidator();
            ValidationResult results = categoryValidator.Validate(p);  //ValidationResult'tan results olarak bir değişken oluşturdum. categoryValidator sınıfından gelen değerlere göre validasyon yapcak

            if (results.IsValid)  //Validasyon kontrolleri sağlanır ve koşullar uyumluysa
            {
                cm.CategoryAddBL(p); //ekleme işlemini yap
                return RedirectToAction("GetCategoryList");

            }
            else
            {
                foreach (var item in results.Errors) // değilse
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);  // hata mesajı döndür
                }
            }

            return View();
        }

    
    }
}
