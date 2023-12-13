namespace WebQuanLyResort.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ThaoTacDatPhong")]
    public partial class ThaoTacDatPhong
    {
        [Key]
        public int id_lichsudatphong { get; set; }

        [StringLength(10)]
        public string id_khachhang { get; set; }

        [StringLength(10)]
        public string id_nhanvien_datphong { get; set; }

        [StringLength(10)]
        public string id_nhanvien_thuchien { get; set; }

        [StringLength(10)]
        public string id_phong { get; set; }

        [StringLength(50)]
        public string tenphong { get; set; }

        public int? loaiphong { get; set; }

        public double? giaphong { get; set; }

        public double? datcoc { get; set; }

        [Column(TypeName = "date")]
        public DateTime? ngaydatphong { get; set; }

        [Column(TypeName = "date")]
        public DateTime? ngay_check_in { get; set; }

        [Column(TypeName = "date")]
        public DateTime? ngay_check_out { get; set; }

        [StringLength(50)]
        public string nguoithuchien { get; set; }

        [Column(TypeName = "date")]
        public DateTime? thoigianthuchien { get; set; }

        public bool? trangthai { get; set; }
    }
}
