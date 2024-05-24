﻿using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MvcProjeKampi.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        // GET: Login
        AdminManager adm = new AdminManager(new EFAdminDal());
        Context context = new Context();

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Admin admin)
        {

            var adminUserInfo = context.Admins.FirstOrDefault(x => x.AdminUserName == admin.AdminUserName &&
                                                                   x.AdminPassword == admin.AdminPassword);
            if (adminUserInfo != null)
            {
                FormsAuthentication.SetAuthCookie(adminUserInfo.AdminUserName, false);
                Session["AdminUserName"] = adminUserInfo.AdminUserName;

                Session["AdminName"] = adminUserInfo.AdminUserName;
                return RedirectToAction("Index", "AdminCategory");
            }
            else
            {
                ViewBag.ErrorMessage = "Kullanıcı Adı veya Şifreniz Yanlış!";
                return RedirectToAction("Index");
            }



        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Headings", "Default");
        }

       
    }
}