using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using hw2.Models;
namespace hw2.Controllers
{
    public class homeController : Controller
    {
        Models.Class1 db = new Models.Class1();
        public ActionResult Index()
        {
            ViewBag.i = db.getsql();
            return View();
        }
        [HttpPost]
        public JsonResult delet(string id)
        {
            db.delet(id);
            return this.Json(true);
        }
        [HttpPost]
        public JsonResult inser(string id)
        {
            string[] s = id.Split('|');
            db.inser(s[0],s[1],s[2],s[3],s[4],s[5]);
            return this.Json(true);
        }
        public JsonResult update(string id)
        {
            string[] s = id.Split('|');
            db.update(s[0], s[1], s[2], s[3], s[4], s[5], s[6], s[7],s[8]);
            return this.Json(true);
        }
    }
}