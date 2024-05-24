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
    public class HeadingController : Controller
    {
        // GET: Heading
        HeadingManager hm = new HeadingManager(new EFHeadingDal());  // HeadingManager'dan hm isimli nesne türettik
        CategoryManager cm = new CategoryManager(new EFCategoryDal()); // CategoryManager'dan cm isimli nesne türettik
        WriterManager wm = new WriterManager(new EFWriterDal());

        [Authorize]
        public ActionResult Index(int pager = 1)
        {
            var headingValues = hm.GetList().ToPagedList(pager, 6); 
            return View(headingValues);
        }

        [HttpGet]
        public ActionResult AddHeading()
        {
            List<SelectListItem> valueCategory = (from x in cm.GetList()  //Dropdown ile tüm categorileri getiricek
                                                  select new SelectListItem
                                                  {
                                                      Text = x.CategoryName,
                                                      Value = x.CategoryID.ToString()
                                                  }).ToList();

            List<SelectListItem> valueWriter = (from x in wm.GetList() //Dropdown ile tüm yazarları getiricek
                                                select new SelectListItem
                                                  {
                                                      Text = x.WriterName + " " + x.WriterSurName,
                                                      Value = x.WriterID.ToString()
                                                  }).ToList();

            ViewBag.vlc = valueCategory;
            ViewBag.vlw = valueWriter;
            return View();
        }


        [HttpPost]
        public ActionResult AddHeading(Heading heading)
        {
            heading.HeadingDate = DateTime.Parse(DateTime.Now.ToShortDateString()); // bugunun kısa tarihini al
            hm.HeadingAddBL(heading);
            return RedirectToAction("Index");
        }


        [HttpGet]
        public ActionResult EditHeading(int id)
        {
            List<SelectListItem> valueCategory = (from x in cm.GetList()  //Dropdown ile tüm categorileri getiricek
                                                  select new SelectListItem
                                                  {
                                                      Text = x.CategoryName,
                                                      Value = x.CategoryID.ToString()
                                                  }).ToList();
            List<SelectListItem> valueWriter = (from x in wm.GetList() //Dropdown ile tüm yazarları getiricek
                                                select new SelectListItem
                                                {
                                                    Text = x.WriterName + " " + x.WriterSurName,
                                                    Value = x.WriterID.ToString()
                                                }).ToList();

            ViewBag.vlc = valueCategory;
            ViewBag.vlw = valueWriter;
            var headingValue = hm.GetByID(id);
            return View(headingValue);
        }


        [HttpPost]
        public ActionResult EditHeading(Heading heading)
        {
            hm.HeadingUpdateBL(heading);
            return RedirectToAction("Index");
        }

        public ActionResult DeleteHeading(int id)
        {
            var headingValue = hm.GetByID(id);  // önce GetByID ile id'sini buluyoruz

            if(headingValue.HeadingStatus == true)
            {
                headingValue.HeadingStatus = false;
                hm.HeadingDeleteBL(headingValue);
            }
            else
            {
                headingValue.HeadingStatus = true;
                hm.HeadingDeleteBL(headingValue);
            }
            return RedirectToAction("Index");
        }
    }
}