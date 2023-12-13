namespace WebQuanLyResort.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("dichvu")]
    public partial class dichvu
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public dichvu()
        {
            chitietsudungdvs = new HashSet<chitietsudungdv>();
        }

        [Key]
        [StringLength(10)]
        public string id_dichvu { get; set; }

        [Required]
        [StringLength(50)]
        public string ten_dichvu { get; set; }

        public int gia { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<chitietsudungdv> chitietsudungdvs { get; set; }
    }
}
