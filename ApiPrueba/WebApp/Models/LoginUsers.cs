using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApp.Models
{
    public class LoginUsers
    {
        [Required]
        [Display(Name = "Usuario")]
        [MinLength(1, ErrorMessage = "Es necesario ingresar un usuario")]
        public string Usua { get; set; }
        [Required]
        [Display(Name = "Password")]
        [MinLength(1, ErrorMessage = "Es necesario ingresar un password")]
        public string Pass { get; set; }
    }
}