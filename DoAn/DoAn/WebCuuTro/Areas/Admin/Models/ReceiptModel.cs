using Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebCuuTro.Areas.Admin.Models
{
    public class ReceiptModel
    {
        public int ID_receipt { get; set; }

        public int? ID_relieft { get; set; }

        public string ID_user { get; set; }

        public DateTime? Date { get; set; }

        public virtual Pesonal Pesonal { get; set; }

        public virtual Relief Relief { get; set; }

        public string Nguoitang { get; set; }

        public virtual List<Details_receipt> Details_receipt { get; set; }
    }
}