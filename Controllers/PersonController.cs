using EczaneMesaj.Hash;
using EczaneMesaj.Models;
using EczaneMesaj.Validation;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace EczaneMesaj.Controllers
{
    [Authorize(Roles = "true")]
    public class PersonController : Controller
    {
        private readonly EczaneMessageEntities db = new EczaneMessageEntities();
        private readonly Validation.UsersValidate validate = new UsersValidate();
        public ActionResult List()
        {
            byte id = (byte)Session["ID"];
            List<Tbl_User> deger = db.Tbl_User.Where(x => x.ID != id).ToList();
            return View(deger);
        }
        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add(Tbl_User p)
        {
            p.Role = p.Role == true ? true : false;
            p.Status = true;
            ValidationResult result = validate.Validate(p);
            if (result.IsValid)
            {
                p.Password = Encryption.Enc(p.Password);
                db.Tbl_User.Add(p);
                db.SaveChanges();
                return RedirectToAction("List");
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
        public ActionResult StatusChanged(byte id)
        {
            Tbl_User deger = db.Tbl_User.Find(id);
            deger.Status = deger.Status != true;
            db.Database.ExecuteSqlCommand("update Tbl_Message set Status='" + deger.Status + "' where Sender=" + id + " or Receiver="+id+"");
            db.SaveChanges();
            return RedirectToAction("List");
        }
        [HttpGet]
        public ActionResult Update(byte id)
        {
            Tbl_User deger = db.Tbl_User.Find(id);
            return View(deger);
        }
        [HttpPost]
        public ActionResult Update(Tbl_User p)
        {
            ValidationResult result = validate.Validate(p);
            if (result.IsValid)
            {
                Tbl_User deger = db.Tbl_User.Find(p.ID);
                deger.Name = p.Name;
                deger.Password = deger.Password == p.Password
                    ? p.Password
                    : Encryption.Enc(p.Password);
                deger.Image = p.Image;
                deger.Role = p.Role == true ? true : false;
                deger.Status = p.Status;
                db.SaveChanges();
                return RedirectToAction("List", "Person");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return View();
            }
        }
    }
}