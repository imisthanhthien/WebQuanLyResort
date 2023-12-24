using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace WebQuanLyResort.ViewModel
{
    public class MinimumAgeAttribute : ValidationAttribute
    {
        private readonly int _minimumAge;

        public MinimumAgeAttribute(int minimumAge)
        {
            _minimumAge = minimumAge;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                DateTime dateOfBirth;
                if (DateTime.TryParse(value.ToString(), out dateOfBirth))
                {
                    if (dateOfBirth > DateTime.Today.AddYears(-_minimumAge))
                    {
                        return new ValidationResult($"Ngày sinh phải từ {_minimumAge} tuổi trở lên.");
                    }
                }
                else
                {
                    return new ValidationResult("Ngày sinh không hợp lệ.");
                }
            }
            return ValidationResult.Success;
        }
    }
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

        [Required(ErrorMessage = "Số điện thoại không được để trống.")]
        public string Mobile { get; set; }

        [Required(ErrorMessage = "Ngày sinh không được để trống.")]
        [MinimumAge(18, ErrorMessage = "Ngày sinh phải từ 18 tuổi trở lên.")]
        public string DateOfBirth { get; set; }
        public string Address { get; set; }
        [Required(ErrorMessage = "Họ tên không được để trống.")]
        public string HoTen { get; set; }
    }
}