using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace WebCuuTro.Areas.Admin.Models
{
    public class Registration_formModel
    {
        [Required]
        public string ID_user { get; set; }

        public int ID_relieft { get; set; }

        public int ID_re { get; set; }

    }
}