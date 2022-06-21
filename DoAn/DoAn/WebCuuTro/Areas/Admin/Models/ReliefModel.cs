using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebCuuTro.Areas.Admin.Models
{
    public class ReliefModel
    {
        [Required]
        public int ID_relieft { get; set; }

        public string ID_rc { get; set; }
      
        public string ID_ward { get; set; }

        public DateTime? Time_sent_post { get; set; }

        public string Content { get; set; }

        public string Content_thank { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime? Start_date { get; set; }
      
        public DateTime? End_date { get; set; }

        public string map { get; set; }

        public string note { get; set; }

        public string status { get; set; }
    }
}