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
    public class AdminCategoryController : Controller
    {
        // GET: AdminCategory
        CategoryManager cm = new CategoryManager(new EFCategoryDal()); //CategoryManager içerisine EFCategoryDal'dan parametre gönderiyoruz.

       [Authorize(Roles ="A")]  //Sadece A (Admin) rolüne sahip kişiler giriş yapabilecektr
        public ActionResult Index()
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
                return RedirectToAction("Index");

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

        public ActionResult DeleteCategory(int id)
        {
            var categoryvalue = cm.GetByID(id);
            cm.CategoryDeleteBL(categoryvalue);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult EditCategory(int id)
        {
            var categoryvalue = cm.GetByID(id);
            return View(categoryvalue);
        }

        [HttpPost]
        public ActionResult EditCategory(Category p)
        {
            cm.CategoryUpdateBL(p);
            return RedirectToAction("Index");

        }


  
    }
}