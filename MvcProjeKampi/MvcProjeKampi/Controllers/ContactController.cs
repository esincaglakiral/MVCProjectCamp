using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class ContactController : Controller
    {
        // GET: Context

        ContactManager ctm = new ContactManager(new EFContactDal());
        MessageManager mm = new MessageManager(new EFMessageDal());
        ContactValidator cv = new ContactValidator();

        [Authorize]
        public ActionResult Index()
        {
            var contactValue = ctm.GetList();
            return View(contactValue);
        }

        public ActionResult GetContactDetails(int id)
        {
            var contactValue = ctm.GetByID(id);
            return View(contactValue);
        }

        public ActionResult DeleteContact(int id)
        {
            var ContactValues = ctm.GetByID(id);
            ctm.ContactDeleteBL(ContactValues);
            return RedirectToAction("Index");
        }

        //checbox ile toplu silme işlemi için
        [HttpPost]
        public ActionResult DeleteSelectedContacts(List<int> ids)
        {
            if (ids != null && ids.Any())
            {
                foreach (var id in ids)
                {
                    var contact = ctm.GetByID(id);
                    if (contact != null)
                    {
                        ctm.ContactDeleteBL(contact);
                    }
                }
            }
            return RedirectToAction("Index");
        }


        public PartialViewResult MessageListMenu()
        {
            var p = "admin@gmail.com";
            ViewBag.a1 = ctm.GetList().Count();
            ViewBag.a2 = mm.GetListInbox(p).Count();
            ViewBag.a3 = mm.GetListSendbox(p).Count();
            return PartialView();
        }

    }
}