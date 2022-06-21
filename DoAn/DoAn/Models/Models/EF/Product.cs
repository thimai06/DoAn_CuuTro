namespace Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Product")]
    public partial class Product
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Product()
        {
            Details_receipt = new HashSet<Details_receipt>();
            Details_registration = new HashSet<Details_registration>();
        }

        [Key]
        [StringLength(10)]
        public string ID_product { get; set; }

        [StringLength(10)]
        public string ID_cate { get; set; }

        [Required]
        [StringLength(255)]
        public string Name_product { get; set; }

        public virtual categorize categorize { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Details_receipt> Details_receipt { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Details_registration> Details_registration { get; set; }
    }
}
