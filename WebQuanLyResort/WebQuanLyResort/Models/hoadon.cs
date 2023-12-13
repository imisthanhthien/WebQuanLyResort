namespace WebQuanLyResort.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("hoadon")]
    public partial class hoadon
    {
        [Key]
        public int id_hoadon { get; set; }

        [Required]
        [StringLength(10)]
        public string id_datphong { get; set; }

        [Required]
        [StringLength(10)]
        public string id_nhanvien { get; set; }

        [Required]
        [StringLength(10)]
        public string id_khachhang { get; set; }

        [Column(TypeName = "date")]
        public DateTime? ngay_lap { get; set; }

        public double TongTienHD { get; set; }

        public virtual datphong datphong { get; set; }

        public virtual khachhang khachhang { get; set; }

        public virtual nhanvien nhanvien { get; set; }
    }
}
