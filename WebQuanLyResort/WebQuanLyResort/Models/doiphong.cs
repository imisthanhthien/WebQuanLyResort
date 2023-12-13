namespace WebQuanLyResort.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("doiphong")]
    public partial class doiphong
    {
        [Key]
        public int id_doiphong { get; set; }

        [Required]
        [StringLength(10)]
        public string id_phong_bandau { get; set; }

        [Required]
        [StringLength(10)]
        public string id_phong_doiphong { get; set; }

        [Required]
        [StringLength(10)]
        public string id_nhanvien_thuchien { get; set; }

        [Column(TypeName = "date")]
        public DateTime? ngaythuchien { get; set; }

        [StringLength(100)]
        public string lydodoiphong { get; set; }

        public virtual nhanvien nhanvien { get; set; }
    }
}
