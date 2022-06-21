namespace Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Details_registration
    {
        [StringLength(10)]
        public string ID_product { get; set; }

        public int? ID_re { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Quantity { get; set; }

        public virtual Product Product { get; set; }

        public virtual Registration_form Registration_form { get; set; }
    }
}
