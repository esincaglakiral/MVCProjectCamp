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

    public class MessageController : Controller
    {
        // GET: Message
        MessageManager mm = new MessageManager(new EFMessageDal());
        MessageValidator mv = new MessageValidator();
       
        [Authorize(Roles = "A")]
        public ActionResult Inbox()
        {
            var p = "admin@gmail.com";
            var messageList = mm.GetListInbox(p);
            return View(messageList);
        }

        public ActionResult Sendbox(string p)
        {
            p = "admin@gmail.com";
            var messageList = mm.GetListSendbox(p);
            return View(messageList);
        }

        [HttpGet]
        public ActionResult NewMessage()
        {
            return View();
        }

        [HttpPost]
        //[ValidateInput(false)]

        public ActionResult NewMessage(Message message)
        {

            ValidationResult result = mv.Validate(message);
            if (result.IsValid)
            {
                message.MessageDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                mm.MessageAddBL(message);
                return RedirectToAction("Sendbox");
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

        public ActionResult GetInboxDetails(int id)
        {
            var value = mm.GetByID(id);
            return View(value);
        }
        public ActionResult GetSendboxDetails(int id)
        {
            var value = mm.GetByID(id);
            return View(value);
        }

        //checbox ile toplu silme işlemi için
        [HttpPost]
        public ActionResult DeleteSelectedInboxMessage(List<int> ids)
        {
            if (ids != null && ids.Any())
            {
                foreach (var id in ids)
                {
                    var message = mm.GetByID(id);
                    if (message != null)
                    {
                        mm.MessageDeleteBL(message);
                    }
                }
            }
            return RedirectToAction("Inbox");
        }


        //checbox ile toplu silme işlemi için
        [HttpPost]
        public ActionResult DeleteSelectedSendboxMessage(List<int> ids)
        {
            if (ids != null && ids.Any())
            {
                foreach (var id in ids)
                {
                    var message = mm.GetByID(id);
                    if (message != null)
                    {
                        mm.MessageDeleteBL(message);
                    }
                }
            }
            return RedirectToAction("Sendbox");
        }


        public ActionResult DeleteInboxDetailsMessage(int id)
        {
            var messageValues = mm.GetByID(id);
            mm.MessageDeleteBL(messageValues);
            return RedirectToAction("Inbox");
        }


        public ActionResult DeleteSendboxDetailsMessage(int id)
        {
            var messageValues = mm.GetByID(id);
            mm.MessageDeleteBL(messageValues);
            return RedirectToAction("Sendbox");
        }
    }
}