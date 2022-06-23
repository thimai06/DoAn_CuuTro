namespace Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Pesonal")]
    public partial class Pesonal
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Pesonal()
        {
            Receipts = new HashSet<Receipt>();
            Registration_form = new HashSet<Registration_form>();
        }

        [Key]
        [StringLength(255)]
        public string ID_user { get; set; }

        [StringLength(2)]
        public string ID_type { get; set; }

        [StringLength(255)]
        public string Personal_name { get; set; }

        [StringLength(12)]
        public string ID_card { get; set; }

        [StringLength(250)]
        public string Address { get; set; }

        [StringLength(3)]
        public string Gender { get; set; }

        [StringLength(10)]
        public string Phone { get; set; }

        [Required]
        [StringLength(255)]
        public string password { get; set; }

        [StringLength(10)]
        public string status { get; set; }

        public virtual Role_Type Role_Type { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Receipt> Receipts { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Registration_form> Registration_form { get; set; }
    }
}
