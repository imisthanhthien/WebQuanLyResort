namespace WebQuanLyResort.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("khachhang")]
    public partial class khachhang
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public khachhang()
        {
            datphongs = new HashSet<datphong>();
            hoadons = new HashSet<hoadon>();
        }

        [Key]
        [StringLength(10)]
        public string id_khachhang { get; set; }

        [Required]
        [StringLength(50)]
        public string ten_khachhang { get; set; }

        [Column(TypeName = "date")]
        public DateTime ngay_sinh { get; set; }

        [Required]
        [StringLength(300)]
        public string dia_chi { get; set; }

        [Required]
        [StringLength(15)]
        public string sdt { get; set; }

        [Required]
        [StringLength(15)]
        public string cmnd { get; set; }

        [Required]
        [StringLength(6)]
        public string gioi_tinh { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<datphong> datphongs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<hoadon> hoadons { get; set; }
    }
}
