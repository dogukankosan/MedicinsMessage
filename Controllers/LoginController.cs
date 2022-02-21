using EczaneMesaj.Hash;
using EczaneMesaj.Models;
using EczaneMesaj.Validation;
using FluentValidation.Results;
using System.Linq;
using System.Web.Mvc;
using System.Web.Security;

namespace EczaneMesaj.Controllers
{
    public class LoginController : Controller
    {
        private readonly Models.EczaneMessageEntities db = new EczaneMessageEntities();
        private readonly Validation.LoginValidate validate = new LoginValidate();
        [HttpGet]
        public ActionResult Log()
        {
            ViewBag.message = TempData["message"] as string;
            return View();
        }

        [HttpPost]
        public ActionResult Log(Models.Tbl_User p)
        {
            p.Password = Encryption.Enc(p.Password);
            Tbl_User deger1 = db.Tbl_User.FirstOrDefault(x => x.Password == p.Password & x.Status == true & x.UserName == p.UserName);
            ValidationResult result = validate.Validate(p);
            if (result.IsValid)
            {
                if (deger1 != null)
                {
                    FormsAuthentication.SetAuthCookie(deger1.ID.ToString(), false);
                    Session["ID"] = deger1.ID;
                    return RedirectToAction("List", "Users");
                }
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            TempData["message"] = (string)"hat";
            return RedirectToAction("Log");
        }

        public ActionResult Page404()
        {
            Response.StatusCode = 404;
            Response.TrySkipIisCustomErrors = true;
            return View();
        }
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Log", "Login");
        }
    }
}