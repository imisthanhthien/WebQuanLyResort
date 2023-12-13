namespace WebQuanLyResort.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("nhanvien")]
    public partial class nhanvien
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public nhanvien()
        {
            datphongs = new HashSet<datphong>();
            doiphongs = new HashSet<doiphong>();
            hoadons = new HashSet<hoadon>();
        }

        [Key]
        [StringLength(10)]
        public string id_nhanvien { get; set; }

        [Required]
        [StringLength(100)]
        public string ten_nhanvien { get; set; }

        [Column(TypeName = "date")]
        public DateTime ngay_sinh { get; set; }

        [Required]
        [StringLength(10)]
        public string sdt { get; set; }

        [Required]
        [StringLength(6)]
        public string gioi_tinh { get; set; }

        [Required]
        [StringLength(50)]
        public string email { get; set; }

        [Column(TypeName = "image")]
        public byte[] hinh_anh { get; set; }

        [Required]
        [StringLength(50)]
        public string ten_dang_nhap { get; set; }

        [Required]
        [StringLength(50)]
        public string mat_khau { get; set; }

        public int quyen { get; set; }

        public bool? trangthai { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<datphong> datphongs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<doiphong> doiphongs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<hoadon> hoadons { get; set; }

        public virtual quyen quyen1 { get; set; }
    }
}
