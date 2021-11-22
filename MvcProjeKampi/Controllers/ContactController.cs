using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Abstract;
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
        // GET: Contact
        ContactManager cm = new ContactManager(new EfContactDal());
        ContactValidator cr = new ContactValidator();
        MessageManager mm = new MessageManager(new EfMessageDal());

        public ActionResult Index()
        {
            var contactValues = cm.GetList();
            return View(contactValues);
        }
        public ActionResult GetContactDetail(int id)
        {
            var contactValues = cm.GetByID(id);
            return View(contactValues);
        }
        public PartialViewResult MessageOptions()
        {
            ViewBag.sendBoxCount = mm.GetListSendbox().Count;
            ViewBag.inBoxCount = mm.GetListInbox().Count;
            ViewBag.contactCount = cm.GetList().Count;
            return PartialView();
        }
    }
}