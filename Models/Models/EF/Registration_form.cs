namespace Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Registration_form
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Registration_form()
        {
            Details_registration = new HashSet<Details_registration>();
        }

        [Key]
        public int ID_re { get; set; }

        [Required]
        [StringLength(255)]
        public string ID_user { get; set; }

        public int ID_relieft { get; set; }

        [StringLength(255)]
        public string Status { get; set; }

        public virtual Pesonal Pesonal { get; set; }

        public virtual Relief Relief { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Details_registration> Details_registration { get; set; }
    }
}
