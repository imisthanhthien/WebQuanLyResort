using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebQuanLyResort.ViewModel
{
    public class LoginVM
    {
        [Required(ErrorMessage = "Tài khoản không được để trống.")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Password không được để trống.")]
        public string Password { get; set; }
    }
}