using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebQuanLyResort.Models;

namespace WebQuanLyResort.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        ResortDBContext db = new ResortDBContext();
        public ActionResult Index()
        {
            List<phong> phong = db.phongs.ToList();
            return View(phong);
        }

        public ActionResult TatCaPhong()
        {
            List<phong> phong = db.phongs.ToList();
            return View(phong);
        }
    }
}