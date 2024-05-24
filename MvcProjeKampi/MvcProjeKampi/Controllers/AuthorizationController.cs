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
    public class AuthorizationController : Controller
    {
        // GET: Authorization
        AdminManager admn = new AdminManager(new EFAdminDal());
        public ActionResult Index()
        {
            var adminValues = admn.GetAll();
            return View(adminValues);
        }
        [HttpGet]
        public ActionResult AddAdmin()
        {
            return View();

        }
        [HttpPost]
        public ActionResult AddAdmin(Admin p)
        {
            admn.Add(p);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult EditAdmin(int id)
        {
            var adminvalue = admn.GetById(id);
            return View(adminvalue);
        }

        [HttpPost]
        public ActionResult EditAdmin(Admin admin)
        {
            admn.Update(admin);
            return RedirectToAction("Index");
        }

        public ActionResult DeleteAdmin(int id)
        {
            var result = admn.GetById(id);
            admn.Delete(result);
            return RedirectToAction("Index");
        }
    }
}