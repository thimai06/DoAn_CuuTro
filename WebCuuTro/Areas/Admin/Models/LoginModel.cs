using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebCuuTro.Areas.Admin.Models
{
    public class LoginModel
    {
        [Required]
        public string Username { get; set; }

        public string Passwords { get; set; }

        public string Personal_name { get; set; }
    }
}