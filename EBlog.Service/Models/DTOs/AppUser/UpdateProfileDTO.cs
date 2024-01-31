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

        [Required(ErrorMessage = "Can not be empty")]
        [Display(Name = "First Name ")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Can not be empty")]
        [Display(Name = "Last Name ")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Can not be empty")]
        [DataType(DataType.EmailAddress)]
        [DisplayName("E-mail Address")]
        public string UserName { get; set; }

        [DisplayName("Profile Picture")]
        public string? ImagePath { get; set; }

        [DisplayName("Phone Number")]
        public string? PhoneNumber { get; set; }

        [DataType(DataType.Password)]
        [DisplayName("Password")]
        public string? Password { get; set; }

        [DataType(DataType.Password)]
        [DisplayName("Confirm Password")]
        [Compare(nameof(Password), ErrorMessage = "Passwords must be same")]
        public string? ConfirmPassword { get; set; }
    }
}
