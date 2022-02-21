using System.Collections.Generic;
using System.Linq;
using EczaneMesaj.Models;
using System.Web.Mvc;

namespace EczaneMesaj.Controllers
{
    [Authorize(Roles = "true")]
    public class AllMessageController : Controller
    {
        private readonly EczaneMessageEntities db = new EczaneMessageEntities();
        public ActionResult List()
        {
            List<Tbl_Message> deger = db.Tbl_Message.ToList();
            return View(deger);
        }
        public ActionResult GetByList(int id)
        {
            Tbl_Message deger = db.Tbl_Message.Find(id);
            return View(deger);
        }
    }
}