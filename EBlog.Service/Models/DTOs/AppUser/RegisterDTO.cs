using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBlog.Service.Models.DTOs.AppUser
{
    public class RegisterDTO
    {
        [Required(ErrorMessage = "Cannot be null")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Cannot be null")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Cannot be null")]
        [Display(Name = "E-mail Address")]
        [DataType(DataType.EmailAddress)]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Cannot be null")]
        [Display(Name = "Enter Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Cannot be null")]
        [Display(Name = "Confirm Your Password")]
        [DataType(DataType.Password)]
        [Compare(nameof(Password), ErrorMessage = "Entries not matched")]
        public string ConfirmPassword { get; set; }
    }
}
