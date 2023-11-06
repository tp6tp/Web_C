using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_WebDTO.sysDTO
{
    public class LoginDTO
    {
        [Required(ErrorMessage ="Enter your Account")]
        public string Account { get; set; }

        [Required(ErrorMessage = "Enter your Password")]
        public string Password { get; set; }
    }
}
