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
    public class WriterPanelMessageController : Controller
    {
        // GET: WriterPanelMessage
        MessageManager mm = new MessageManager(new EFMessageDal());
        MessageValidator mv = new MessageValidator();

        public ActionResult WriterPanelInbox()
        {
            string p = (string)Session["WriterMail"];
            var messageList = mm.GetListInbox(p);
            return View(messageList);
        }
        

        public ActionResult WriterPanelSendbox()
        {
            string p = (string)Session["WriterMail"];
            var messageList = mm.GetListSendbox(p);
            return View(messageList);
        }

        public ActionResult GetWriterInboxDetails(int id)
        {
            var value = mm.GetByID(id);
            return View(value);
        }
        public ActionResult GetWriterSendboxDetails(int id)
        {
            var value = mm.GetByID(id);
            return View(value);
        }

        [HttpGet]
        public ActionResult WriterNewMessage()
        {
            return View();
        }

        [HttpPost]
        //[ValidateInput(false)]

        public ActionResult WriterNewMessage(Message message)
        {

            ValidationResult result = mv.Validate(message);
            if (result.IsValid)
            {
                string sender = (string)Session["WriterMail"];
                message.SenderMail = sender;
                message.MessageDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                mm.MessageAddBL(message);
                return RedirectToAction("WriterPanelSendbox");
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

        public PartialViewResult WriterMessageListMenu()
        {
            string p = (string)Session["WriterMail"];
            ViewBag.a2 = mm.GetListInbox(p).Count();
            ViewBag.a3 = mm.GetListSendbox(p).Count();
            return PartialView();
        }

        //checbox ile toplu silme işlemi için
        [HttpPost]
        public ActionResult DeleteSelectedWriterInbox(List<int> ids)
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
            return RedirectToAction("WriterPanelInbox");
        }


        //checbox ile toplu silme işlemi için
        [HttpPost]
        public ActionResult DeleteSelectedWriterSendbox(List<int> ids)
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
            return RedirectToAction("WriterPanelSendbox");
        }


        public ActionResult DeleteWriterInboxDetails(int id)
        {
            var messageValues = mm.GetByID(id);
            mm.MessageDeleteBL(messageValues);
            return RedirectToAction("WriterPanelInbox");
        }


        public ActionResult DeleteWriterSendboxDetails(int id)
        {
            var messageValues = mm.GetByID(id);
            mm.MessageDeleteBL(messageValues);
            return RedirectToAction("WriterPanelSendbox");
        }
    }
}