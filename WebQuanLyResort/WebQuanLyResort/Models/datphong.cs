namespace WebQuanLyResort.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("datphong")]
    public partial class datphong
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public datphong()
        {
            chitietsudungdvs = new HashSet<chitietsudungdv>();
            chitietsudungtbs = new HashSet<chitietsudungtb>();
            hoadons = new HashSet<hoadon>();
        }

        [Key]
        [StringLength(10)]
        public string id_datphong { get; set; }

        [Required]
        [StringLength(10)]
        public string id_nhanvien { get; set; }

        [Required]
        [StringLength(10)]
        public string id_khachhang { get; set; }

        [Required]
        [StringLength(10)]
        public string id_phong { get; set; }

        public DateTime check_in { get; set; }

        public DateTime? check_out { get; set; }

        public double? dat_coc { get; set; }

        public double? phu_thu_checkin { get; set; }

        public double? phu_thu_checkout { get; set; }

        public int? so_nguoi_o { get; set; }

        [StringLength(40)]
        public string trang_thai { get; set; }

        public DateTime? ngaydat { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<chitietsudungdv> chitietsudungdvs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<chitietsudungtb> chitietsudungtbs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<hoadon> hoadons { get; set; }

        public virtual khachhang khachhang { get; set; }

        public virtual nhanvien nhanvien { get; set; }

        public virtual phong phong { get; set; }
    }
}
