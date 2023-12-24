using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBlog.Service.Models.DTOs.AppUser
{
    public class LoginDTO
    {
        [Required(ErrorMessage = "Cannot be null")]
        [DataType(DataType.EmailAddress)]
        [DisplayName("Enter Your E-mail Address")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Cannot be null")]
        [DataType(DataType.Password)]
        [DisplayName("Enter Password")]
        public string Password { get; set; }
    }
}
