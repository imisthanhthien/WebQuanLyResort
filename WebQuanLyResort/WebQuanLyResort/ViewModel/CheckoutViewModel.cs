using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebQuanLyResort.Models;

namespace WebQuanLyResort.ViewModel
{
    public class CheckoutViewModel
    {
        public BookingInfo BookingInfo { get; set; }
        public khachhang KhachHang { get; set; }
        public string InvalidEmailErrorMessage { get; set; }
    }
}