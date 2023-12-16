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
        
        //public ActionResult Checkout()
        //{
        //    return View();
        //}
        [HttpPost]
        public ActionResult Checkout(BookingInfo booking)
        {

            return View(booking);
        }

        [HttpPost]
        public ActionResult DatPhong(khachhang k, datphong dt)
        {
            List<khachhang> lastKH = db.khachhangs.OrderBy(row => row.id_khachhang.Length).ToList();
            string idkhachhang = lastKH.Last().id_khachhang;

            // Tách phần số từ mã khách hàng hiện tại
            string numberPart = idkhachhang.Replace("KH_", ""); // Loại bỏ phần "KH_"

            // Chuyển phần số thành giá trị số nguyên
            if (int.TryParse(numberPart, out int number))
            {
                // Tăng giá trị số lên 1
                number++;

                // Gán lại cho idkhachhang với định dạng "KH_" + số đã tăng
                idkhachhang = "KH_" + number.ToString();
            }

            khachhang khach = new khachhang();
            khach.id_khachhang = idkhachhang;
            khach.ten_khachhang = k.ten_khachhang;
            khach.ngay_sinh = k.ngay_sinh;
            khach.dia_chi = k.dia_chi;
            khach.sdt = k.sdt;
            khach.cmnd = k.cmnd;
            khach.gioi_tinh = k.gioi_tinh;
            db.khachhangs.Add(khach);
            db.SaveChanges();

            List<datphong> lastDatPhong = db.datphongs.OrderBy(row => row.id_datphong.Length).ToList();
            string iddatphong = lastDatPhong.Last().id_datphong;
            // Tách phần số từ mã khách hàng hiện tại
            string numberPhong = iddatphong.Replace("DT_", ""); // Loại bỏ phần "KH_"

            // Chuyển phần số thành giá trị số nguyên
            if (int.TryParse(numberPhong, out int numberr))
            {
                // Tăng giá trị số lên 1
                numberr++;

                // Gán lại cho idkhachhang với định dạng "KH_" + số đã tăng
                iddatphong = "DT_" + numberr.ToString();
            }
            datphong datphong = new datphong();
            datphong.id_datphong = iddatphong;
            datphong.id_nhanvien = "NV_2";
            datphong.id_khachhang = idkhachhang;
            datphong.id_phong = dt.id_phong;
            datphong.check_in = dt.check_in;
            datphong.check_out = dt.check_out;
            datphong.dat_coc = dt.dat_coc;
            datphong.so_nguoi_o = dt.so_nguoi_o;
            datphong.trang_thai = "Chờ xác nhận";
            datphong.ngaydat = dt.ngaydat;
            db.datphongs.Add(datphong);
            db.SaveChanges();

            return RedirectToAction("DatPhongThanhCong");
        }
        public ActionResult DatPhongThanhCong()
        {
            return View();
        }
    }
}