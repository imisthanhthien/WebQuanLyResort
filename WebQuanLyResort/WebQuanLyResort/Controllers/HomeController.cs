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

        public ActionResult LichSuDatPhong(string search = "")
        {
            List<datphong> dp = new List<datphong>();

            if (!string.IsNullOrEmpty(search))
            {
                // Xử lý an toàn dữ liệu đầu vào trước khi truy vấn cơ sở dữ liệu
                string sanitizedSearch = SanitizeInput(search);

                khachhang kh = db.khachhangs.FirstOrDefault(row => row.cmnd == sanitizedSearch);

                if (kh != null)
                {
                    dp = db.datphongs.Where(row => row.id_khachhang == kh.id_khachhang).ToList();
                }
            }

            return View(dp);
        }
        private string SanitizeInput(string input)
        {
            return input.Replace("'", "").Replace(";", "");
        }
    }
}