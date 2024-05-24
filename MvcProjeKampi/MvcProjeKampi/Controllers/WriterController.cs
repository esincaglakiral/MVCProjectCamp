using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using PagedList;
using PagedList.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class WriterController : Controller
    {
        // GET: Writer

        WriterManager wm = new WriterManager(new EFWriterDal());
        WriterValidator writerValidator = new WriterValidator();

        [Authorize]
        public ActionResult Index(int pager = 1)
        {
            var WriterValues = wm.GetList().ToPagedList(pager, 8);
            return View(WriterValues);
        }

        [HttpGet]
        public ActionResult AddWriter()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddWriter(Writer wr)
        {
            ValidationResult results = writerValidator.Validate(wr);  

            if (results.IsValid)  //Validasyon kontrolleri sağlanır ve koşullar uyumluysa
            {
                wm.WriterAddBL(wr); //ekleme işlemini yap
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


        public ActionResult DeleteWriter(int id)
        {
            var WriterValues = wm.GetByID(id);
            wm.WriterDeleteBL(WriterValues);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult EditWriter(int id)
        {
            var WriterValues = wm.GetByID(id);
            return View(WriterValues);
        }

        [HttpPost]
        public ActionResult EditWriter(Writer wr)
        {

            ValidationResult results = writerValidator.Validate(wr);

            if (results.IsValid)  //Validasyon kontrolleri sağlanır ve koşullar uyumluysa
            {
                wm.WriterUpdateBL(wr); //ekleme işlemini yap
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
    }
}