using EczaneMesaj.Models;
using EczaneMesaj.Validation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;


namespace EczaneMesaj.Controllers
{
    [Authorize]
    public class MessageController : Controller
    {
        private readonly Models.EczaneMessageEntities db = new EczaneMessageEntities();
        private readonly Validation.MessageValidate validate = new MessageValidate();
        public ActionResult List()
        {
            byte user = (byte)Session["ID"];
            List<Tbl_Message> deger = db.Tbl_Message.Where(x => x.Receiver == user && x.Unnecessary == false && x.Status == true).OrderByDescending(x => x.MessageID).ToList();
            return View(deger);
        }
        public ActionResult GetByList(int id)
        {
            db.Database.ExecuteSqlCommand("update Tbl_Message set ReadStatus=1 where MessageID=" + id + "");
            db.SaveChanges();
            Tbl_Message deger = db.Tbl_Message.Find(id);
            return View(deger);
        }
        public ActionResult SendMail()
        {
            byte user = (byte)Session["ID"];
            List<Tbl_Message> deger = db.Tbl_Message.Where(x => x.Sender == user && x.Status == true).OrderByDescending(x => x.MessageID).ToList();
            return View(deger);
        }
        public ActionResult GetBySendMail(int id)
        {
            Tbl_Message deger = db.Tbl_Message.Find(id);
            return View(deger);
        }
        [HttpGet]
        public ActionResult AddMessage()
        {
            byte user = (byte)Session["ID"];
            List<SelectListItem> deger = (from x in db.Tbl_User.Where(x => x.Status == true && x.ID != user).OrderBy(x => x.Name).ToList()
                                          select new SelectListItem
                                          {
                                              Value = x.ID.ToString(),
                                              Text = x.Name
                                          }).ToList();
            ViewBag.users = deger;
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult AddMessage(Tbl_Message p)
        {
            byte user = (byte)Session["ID"];
            p.MessageDate = DateTime.Now;
            p.Status = true;
            p.ReadStatus = false;
            p.Sender = user;
            p.Unnecessary = false;
            ValidationResult result = validate.Validate(p);
            if (result.IsValid)
            {
                db.Tbl_Message.Add(p);
                db.SaveChanges();
                return RedirectToAction("SendMail");
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
        public ActionResult DeleteByID(int id)
        {
            Tbl_Message deger = db.Tbl_Message.Find(id);
            return View(deger);
        }
        public ActionResult StatusChanged(short id)
        {
            Tbl_Message deger = db.Tbl_Message.Find(id);
            deger.Status = true;
            db.SaveChanges();
            return RedirectToAction("List");
        }
        public ActionResult StatusUn(int id)
        {
            Tbl_Message deger = db.Tbl_Message.Find(id);
            deger.Unnecessary = false;
            db.SaveChanges();
            return RedirectToAction("List");
        }
        public ActionResult UnByID(int id)
        {
            Tbl_Message deger = db.Tbl_Message.Find(id);
            return View(deger);
        }
        public ActionResult DeleteList()
        {
            byte user = (byte)Session["ID"];
            List<Tbl_Message> deger = db.Tbl_Message.Where(x => x.Sender == user && x.Status == false).OrderByDescending(x => x.MessageID).ToList();
            return View(deger);
        }
        public ActionResult Delete(int id)
        {
            Tbl_Message deger = db.Tbl_Message.Find(id);
            deger.Status = false;
            db.SaveChanges();
            return RedirectToAction("List");
        }
        public ActionResult UnnecessaryDelete(int id)
        {
            Tbl_Message deger = db.Tbl_Message.Find(id);
            deger.Unnecessary = true;
            db.SaveChanges();
            return RedirectToAction("List");
        }
        public ActionResult UnnecessaryList()
        {
            byte user = (byte)Session["ID"];
            List<Tbl_Message> deger = db.Tbl_Message.Where(x => x.Receiver == user && x.Unnecessary == true).OrderByDescending(x => x.MessageID).ToList();
            return View(deger);
        }
        public PartialViewResult SideBard()
        {
            byte user = (byte)Session["ID"];
            ViewBag.send = db.Tbl_Message.Count(x => x.Sender == user && x.Status == true).ToString();
            ViewBag.inbox = db.Tbl_Message.Count(x => x.Receiver == user && x.Status == true && x.Unnecessary == false).ToString();
            ViewBag.delete = db.Tbl_Message.Count(x => x.Status == false && x.Sender == user).ToString();
            ViewBag.Unnecessary = db.Tbl_Message.Count(x => x.Unnecessary == true && x.Receiver == user).ToString();
            return PartialView();
        }
    }
}