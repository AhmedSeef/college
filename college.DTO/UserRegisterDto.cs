using college.DTO.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace college.DTO
{
    public class UserRegisterDto : BaseDTO
    {
        [Required(ErrorMessage = "you must enter Name")]
        public string Username { get; set; }

        [Required(ErrorMessage = "you must enter the password")]
        public string Password { get; set; }
    }
}
