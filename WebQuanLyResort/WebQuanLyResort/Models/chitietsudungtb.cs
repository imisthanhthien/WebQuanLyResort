namespace WebQuanLyResort.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("chitietsudungtb")]
    public partial class chitietsudungtb
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(10)]
        public string id_datphong { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(10)]
        public string id_thietbi { get; set; }

        [Column(TypeName = "date")]
        public DateTime? ngay_thue { get; set; }

        public int? so_luong { get; set; }

        public double? tong_tien_tb { get; set; }

        public virtual datphong datphong { get; set; }

        public virtual thietbi thietbi { get; set; }
    }
}
