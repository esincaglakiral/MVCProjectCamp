using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using PagedList;
using PagedList.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class WriterPanelController : Controller
    {
        // GET: WriterPanel

        HeadingManager hm = new HeadingManager(new EFHeadingDal());
        CategoryManager cm = new CategoryManager(new EFCategoryDal());
        Context context = new Context();
        WriterManager wm = new WriterManager(new EFWriterDal());
        WriterValidator validator = new WriterValidator();

        public ActionResult WriterProfile(int id = 0)
        {
            string p = (string)Session["WriterMail"];
            id = context.Writers.Where(x => x.WriterMail == p).Select(y => y.WriterID).FirstOrDefault();
            var writerValue = wm.GetByID(id);
            return View(writerValue);
        }

        [HttpPost]
        public ActionResult WriterProfile(Writer writer)
        {
            ValidationResult result = validator.Validate(writer);
            if (result.IsValid)
            {
                wm.WriterUpdateBL(writer);
                return RedirectToAction("AllHeading", "WriterPanel");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }

            }

            return View();
        }


        public ActionResult MyHeading(string p, int pager = 1)
        {
            p = (string)Session["WriterMail"];
            var writerIdInfo = context.Writers.Where(x => x.WriterMail == p).Select(y => y.WriterID).FirstOrDefault();
            var value = hm.GetListByWriter(writerIdInfo).ToPagedList(pager, 5);
            return View(value);
        }

        [HttpGet]
        public ActionResult NewHeading()
        {

            List<SelectListItem> valueCategory = (from x in cm.GetList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.CategoryName,
                                                      Value = x.CategoryID.ToString()
                                                  }
                                                  ).ToList();
            ViewBag.vlc = valueCategory;
            return View();
        }

        [HttpPost]
        public ActionResult NewHeading(Heading h)
        {
            string writerMailInfo = (string)Session["WriterMail"];
            var writerIdInfo = context.Writers.Where(x => x.WriterMail == writerMailInfo).Select(y => y.WriterID).FirstOrDefault();
            h.HeadingDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            h.WriterID = writerIdInfo;          
            h.HeadingStatus = true;
            hm.HeadingAddBL(h);
            return RedirectToAction("MyHeading");
        }


        [HttpGet]
        public ActionResult EditHeading(int id)
        {
            List<SelectListItem> valueCategory = (from x in cm.GetList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.CategoryName,
                                                      Value = x.CategoryID.ToString()
                                                  }
                                                 ).ToList();

            ViewBag.vlc = valueCategory;
            var value = hm.GetByID(id);
            return View(value);
        }
        [HttpPost]
        public ActionResult EditHeading(Heading heading)
        {
            hm.HeadingUpdateBL(heading);
            return RedirectToAction("MyHeading");
        }

        public ActionResult DeleteHeading(int id)
        {
            var headingvalues = hm.GetByID(id);
            if (headingvalues.HeadingStatus == true)
            {
                headingvalues.HeadingStatus = false;
                hm.HeadingDeleteBL(headingvalues);
            }
            else
            {
                headingvalues.HeadingStatus = true;
                hm.HeadingDeleteBL(headingvalues);
            }

            return RedirectToAction("MyHeading");
        }

        public ActionResult AllHeading(int pager = 1)
        {

            var headings = hm.GetList().ToPagedList(pager, 8);
            return View(headings);
        }

    }
}