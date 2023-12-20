using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebQuanLyResort.ViewModel
{
    public class RegisterVM
    {
        [Required(ErrorMessage = "Tên đăng nhập không được để trống.")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Mật khẩu không được để trống.")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Mật khẩu xác nhận không được để trống.")]
        [Compare("Password", ErrorMessage = "Mật khẩu và mật khẩu xác nhận không chính xác.")]
        public string ComfirmPassword { get; set; }
        [Required(ErrorMessage = "Email không được để trống.")]
        [EmailAddress(ErrorMessage = "Email không hợp lệ.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "CCCD không được để trống.")]
        [RegularExpression("^[0-9]{12}$", ErrorMessage = "CCCD cần phải có đúng 12 số.")]
        public string Cccd { get; set; }
        public string Mobile { get; set; }
        public string DateOfBirth { get; set; }
        public string Address { get; set; }
        //public string City { get; set; }
    }
}