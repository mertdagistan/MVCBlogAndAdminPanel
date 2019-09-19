using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCBlog.Areas.Admin.Models.LoginVM
{
    public class LoginVM
    {
        [Required(ErrorMessage = "Please Enter E-Mail.")]
        [Display(Name = "E-Mail")]
        public string EMail { get; set; }

        [Required(ErrorMessage = "Plase Enter Password.")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }
    }
}