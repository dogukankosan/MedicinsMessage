using EczaneMesaj.Hash;
using EczaneMesaj.Models;
using EczaneMesaj.Validation;
using FluentValidation.Results;
using System.Web.Mvc;

namespace EczaneMesaj.Controllers
{
    [Authorize]
    public class UsersController : Controller
    {
        private readonly Models.EczaneMessageEntities db = new EczaneMessageEntities();
        private readonly UsersValidate Validate = new UsersValidate();
        public ActionResult List()
        {
            byte user = (byte)Session["ID"];
            Tbl_User deger = db.Tbl_User.Find(user);
            return View(deger);
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
            ValidationResult result = Validate.Validate(p);
            if (result.IsValid)
            {
                Tbl_User deger = db.Tbl_User.Find(p.ID);
                deger.Password = deger.Password == p.Password
                    ? p.Password
                    : Encryption.Enc(p.Password);
                deger.Name = p.Name;
                deger.UserName = p.UserName;
                deger.Status = p.Status;
                deger.Image = p.Image;
                deger.Role = p.Role;
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
    }
}