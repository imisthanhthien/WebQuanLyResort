namespace WebQuanLyResort.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("chitietsudungdv")]
    public partial class chitietsudungdv
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(10)]
        public string id_datphong { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(10)]
        public string id_dichvu { get; set; }

        [Column(TypeName = "date")]
        public DateTime? ngay_thue { get; set; }

        public int? so_luong { get; set; }

        public double? tong_tien_dv { get; set; }

        public virtual datphong datphong { get; set; }

        public virtual dichvu dichvu { get; set; }
    }
}
