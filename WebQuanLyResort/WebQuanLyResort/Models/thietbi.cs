namespace WebQuanLyResort.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("thietbi")]
    public partial class thietbi
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public thietbi()
        {
            chitietsudungtbs = new HashSet<chitietsudungtb>();
        }

        [Key]
        [StringLength(10)]
        public string id_thietbi { get; set; }

        [Required]
        [StringLength(50)]
        public string ten_thietbi { get; set; }

        public int gia { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<chitietsudungtb> chitietsudungtbs { get; set; }
    }
}
