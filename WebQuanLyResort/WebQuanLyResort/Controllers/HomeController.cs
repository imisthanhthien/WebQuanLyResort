using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebQuanLyResort.Identity;
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
        AppDbContext appdb = new AppDbContext();
        public ActionResult LichSuDatPhong(string search = "", string username = "")
        {
            List<datphong> dp = new List<datphong>();
            AppUser user = appdb.Users.Where(row => row.UserName == username).FirstOrDefault();
            if (user != null)
            {


                khachhang kh = db.khachhangs.FirstOrDefault(row => row.cmnd == user.CCCD);

                if (kh != null)
                {
                    dp = db.datphongs.Where(row => row.id_khachhang == kh.id_khachhang).ToList();
                }
            }
            else
            {
                if (!string.IsNullOrEmpty(search))
                {

                    khachhang kh = db.khachhangs.FirstOrDefault(row => row.cmnd == search);

                    if (kh != null)
                    {
                        dp = db.datphongs.Where(row => row.id_khachhang == kh.id_khachhang).ToList();
                    }
                }
            }
            return View(dp);
        }
    }
}