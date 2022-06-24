namespace Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Relief")]
    public partial class Relief
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Relief()
        {
            Proofs = new HashSet<Proof>();
            Receipts = new HashSet<Receipt>();
            Registration_form = new HashSet<Registration_form>();
        }

        [Key]
        public int ID_relieft { get; set; }

        [Required]
        [StringLength(10)]
        public string ID_rc { get; set; }

        [Required]
        [StringLength(10)]
        public string ID_ward { get; set; }

        public DateTime Time_sent_post { get; set; }

        public string Content { get; set; }

        public string Content_thank { get; set; }

        [Required]
        [StringLength(255)]
        public string Title { get; set; }

        public string Description { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Start_date { get; set; }

        [Column(TypeName = "date")]
        public DateTime? End_date { get; set; }

        [StringLength(255)]
        public string map { get; set; }

        [StringLength(255)]
        public string note { get; set; }

        [StringLength(255)]
        public string status { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Proof> Proofs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Receipt> Receipts { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Registration_form> Registration_form { get; set; }

        public virtual Relief_classification Relief_classification { get; set; }

        public virtual Ward Ward { get; set; }
    }
}
