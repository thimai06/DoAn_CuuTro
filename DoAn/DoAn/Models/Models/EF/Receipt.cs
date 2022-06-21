namespace Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Receipt")]
    public partial class Receipt
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Receipt()
        {
            Details_receipt = new HashSet<Details_receipt>();
        }

        [Key]
        public int ID_receipt { get; set; }

        public int? ID_relieft { get; set; }

        [StringLength(255)]
        public string ID_user { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Date { get; set; }

        [StringLength(255)]
        public string Nguoitang { get; set; }

        public virtual Pesonal Pesonal { get; set; }

        public virtual Relief Relief { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Details_receipt> Details_receipt { get; set; }
    }
}
