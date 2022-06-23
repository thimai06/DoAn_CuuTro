namespace Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Details_receipt
    {
        public int? ID_receipt { get; set; }

        [StringLength(10)]
        public string ID_product { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Quantity { get; set; }

        public virtual Product Product { get; set; }

        public virtual Receipt Receipt { get; set; }
    }
}
