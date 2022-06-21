namespace Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Proof")]
    public partial class Proof
    {
        [Key]
        public int ID_proof { get; set; }

        public int? ID_relieft { get; set; }

        [StringLength(255)]
        public string Link { get; set; }

        [StringLength(255)]
        public string Type { get; set; }

        public virtual Relief Relief { get; set; }
    }
}
