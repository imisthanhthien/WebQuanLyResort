using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebQuanLyResort.Models;
using System.Text.RegularExpressions;
using WebQuanLyResort.Identity;
using WebQuanLyResort.Filter;

namespace WebQuanLyResort.Controllers
{
    public class PhongController : Controller
    {
        // GET: Phong
        ResortDBContext db = new ResortDBContext();
        AppDbContext appdb = new AppDbContext();
        public ActionResult Index(string id)
        {
            phong p = db.phongs.Where(row => row.id_phong == id).FirstOrDefault();
            List<phong> phong = db.phongs.ToList();
            ViewBag.phong = phong;
            return View(p);
        }


        [HttpPost]
        [MyAuthenFilter]
        public ActionResult Checkout(BookingInfo booking, string UserName="")
        {
            AppUser user = appdb.Users.Where(row => row.UserName == UserName).FirstOrDefault();
            ViewBag.user = user;
            return View(booking);
        }
        private bool IsValidEmail(string email)
        {
            string emailPattern = @"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$"; // Pattern để kiểm tra định dạng email

            if (!string.IsNullOrEmpty(email))
            {
                return Regex.IsMatch(email, emailPattern);
            }

            return false;
        }

        [HttpPost]
        public ActionResult XacNhanThongTin(khachhang kh, BookingInfo booking)
        {
            if (IsValidEmail(kh.email_khachhang))
            {
                khachhang k = db.khachhangs.Where(row => row.cmnd == kh.cmnd).FirstOrDefault();
                if (k != null)
                {
                    string date = k.ngay_sinh.ToString("dd/MM/yyyy");
                    ViewBag.date = date;
                    ViewBag.khachhang = k;
                    return View(booking);
                }
                else
                {
                    //List<khachhang> lastKH = db.khachhangs.OrderBy(row => row.id_khachhang.Substring(3)).ToList();
                    //string idkhachhang = lastKH.Last().id_khachhang;

                    List<khachhang> khachhangsFromDB = db.khachhangs
                        .Where(row => row.id_khachhang.StartsWith("KH_"))
                        .ToList(); // Lấy dữ liệu từ cơ sở dữ liệu

                    List<khachhang> lastKH = khachhangsFromDB
                        .OrderByDescending(row => int.Parse(row.id_khachhang.Substring(3))) // Sắp xếp theo số sau "KH_" giảm dần
                        .ToList();

                    string idkhachhang = lastKH.FirstOrDefault()?.id_khachhang; // Lấy id_khachhang của phần tử đầu tiên trong danh sách



                    // Tách phần số từ mã khách hàng hiện tại
                    string numberPart = idkhachhang.Replace("KH_", ""); 

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
                    khach.ten_khachhang = kh.ten_khachhang;
                    khach.ngay_sinh = kh.ngay_sinh;
                    khach.dia_chi = kh.dia_chi;
                    khach.sdt = kh.sdt;
                    khach.cmnd = kh.cmnd;
                    khach.gioi_tinh = kh.gioi_tinh;
                    khach.email_khachhang = kh.email_khachhang;
                    db.khachhangs.Add(khach);
                    db.SaveChanges();

                    string date = kh.ngay_sinh.ToString("dd/MM/yyyy");
                    ViewBag.date = kh.ngay_sinh;
                    ViewBag.khachhang = khach;
                    return View(booking);
                }
            }
            else
            {
                ModelState.AddModelError("InvalidEmail", "Email không hợp lệ. Vui lòng nhập lại.");
                return View("Checkout", booking);
            }
        }

        [HttpPost]
        public ActionResult DatPhong(khachhang k, datphong dt)
        {

            //List<datphong> lastDatPhong = db.datphongs.OrderBy(row => row.id_datphong.Length).ToList();
            //string iddatphong = lastDatPhong.Last().id_datphong;

            List<datphong> lastDatPhong = db.datphongs
                       .Where(row => row.id_datphong.StartsWith("DT_"))
                       .ToList(); // Lấy dữ liệu từ cơ sở dữ liệu

            List<datphong> lastDT = lastDatPhong
                .OrderByDescending(row => int.Parse(row.id_datphong.Substring(3))) // Sắp xếp theo số sau "KH_" giảm dần
                .ToList();

            string iddatphong = lastDT.FirstOrDefault()?.id_datphong; // Lấy id_khachhang của phần tử đầu tiên trong danh sách
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
            datphong.id_khachhang = k.id_khachhang;
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