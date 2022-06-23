namespace Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Details_receipt
    {
        [Key, Column(Order = 1)]
        public int? ID_receipt { get; set; }

        [Key, Column(Order = 2)]
        [StringLength(10)]
        public string ID_product { get; set; }

        public int Quantity { get; set; }

        public virtual Product Product { get; set; }

        public virtual Receipt Receipt { get; set; }
    }
}
