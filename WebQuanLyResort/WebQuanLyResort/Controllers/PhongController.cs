using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebQuanLyResort.Models;

namespace WebQuanLyResort.Controllers
{
    public class PhongController : Controller
    {
        // GET: Phong
        ResortDBContext db = new ResortDBContext();
        public ActionResult Index(string id)
        {
            phong p = db.phongs.Where(row=>row.id_phong == id).FirstOrDefault();
            List<phong> phong = db.phongs.ToList();
            ViewBag.phong = phong;
            return View(p);
        }
        [HttpPost]
        public ActionResult UpdateDate(int dateDifference)
        {
            ViewBag.date = dateDifference;
            return Json(new { date = dateDifference });
        }
    }
}