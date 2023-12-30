using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBlog.Service.Models.DTOs.AppUser
{
    public class UpdateProfileDTO
    {
        [Display(Name = "ID ")]
        public string Id { get; set; }

        [Required(ErrorMessage = "Boş Geçilemez")]
        [Display(Name = "Adı ")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Boş Geçilemez")]
        [Display(Name = "Soyadı ")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Boş Geçilemez")]
        [DataType(DataType.EmailAddress)]
        [DisplayName("Email Adresi")]
        public string UserName { get; set; }

        [DisplayName("Profil Resmi")]
        public string? ImagePath { get; set; }

        [DisplayName("Telefon")]
        public string? PhoneNumber { get; set; }

        [DataType(DataType.Password)]
        [DisplayName("Şifre")]
        public string? Password { get; set; }

        [DataType(DataType.Password)]
        [DisplayName("Şifre Tekrar")]
        [Compare(nameof(Password), ErrorMessage = "Şifreler aynı olmalıdır")]
        public string? ConfirmPassword { get; set; }
    }
}
