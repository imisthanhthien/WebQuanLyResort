namespace WebQuanLyResort.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("phong")]
    public partial class phong
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public phong()
        {
            datphongs = new HashSet<datphong>();
        }

        [Key]
        [StringLength(10)]
        public string id_phong { get; set; }

        public int id_loaiphong { get; set; }

        [Required]
        [StringLength(50)]
        public string ten { get; set; }

        public int so_luong_nguoi { get; set; }

        [StringLength(30)]
        public string trang_thai { get; set; }

        public string MoTa { get; set; }

        [StringLength(50)]
        public string DienTich { get; set; }

        [StringLength(100)]
        public string Giuong { get; set; }

        [StringLength(100)]
        public string HinhAnh { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<datphong> datphongs { get; set; }

        public virtual loaiphong loaiphong { get; set; }
    }
}
