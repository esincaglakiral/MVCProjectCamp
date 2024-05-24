using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcProjeKampi.Models;

namespace MvcProjeKampi.Controllers
{
    public class ChartController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CategoryChart()
        {
            return Json(BlogList(), JsonRequestBehavior.AllowGet);
        }

        public List<CategoryClass> BlogList()
        {
            List<CategoryClass> ct = new List<CategoryClass>();
            ct.Add(new CategoryClass()
            {
                CategoryName = "MVC5",
                CategoryCount = 8
            });
            ct.Add(new CategoryClass()
            {
                CategoryName = "React",
                CategoryCount = 7
            });
            ct.Add(new CategoryClass()
            {
                CategoryName = "Angular",
                CategoryCount = 6
            });
            ct.Add(new CategoryClass()
            {
                CategoryName = "Asp.Net",
                CategoryCount = 7
            });

            return ct;
        }
    }
}