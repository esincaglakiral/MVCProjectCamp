using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using MvcProjeKampi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class SkillCardController : Controller
    {
        // GET: SkillCard
        SkillManager skl = new SkillManager(new EFSkillDal());

        public ActionResult Index()
        {
            var skillValue = skl.GetList();
            return View(skillValue);
        }

       
    }
}