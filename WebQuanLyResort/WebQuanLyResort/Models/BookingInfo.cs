using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebQuanLyResort.Models
{
    public class BookingInfo
    {
        public string idphong { get; set; }
        public string tenphong { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public int songuoio { get; set; }
        public int songayo { get; set; }
        public float datcoc { get; set; }
        public float tongtien { get; set; }
    }
}