using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class AboutController : Controller
    {
        // GET: About
        AboutManager abm = new AboutManager(new EFAboutDal());

        [Authorize]
        public ActionResult Index()
        {
            var aboutValue = abm.GetList();
            return View(aboutValue);
        }

        [HttpGet]
        public ActionResult AddAbout()
        {
            return View();
        }


        [HttpPost]
        public ActionResult AddAbout(About about)
        {
            abm.AboutAddBL(about);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult EditAbout(int id)
        {
            var about = abm.GetByID(id);
            return View(about);
        }

        [HttpPost]
        public ActionResult EditAbout(About about)
        {
            abm.AboutUpdateBL(about);
            return RedirectToAction("Index");
        }

        public ActionResult DeleteAbout(int id)
        {
            var about = abm.GetByID(id);
            abm.AboutDeleteBL(about);
            return RedirectToAction("Index");
        }

        public PartialViewResult AboutPartial()
        {
            return PartialView();
        }



    }
}