using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Project.UI.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage ="Kullanıcı adını boş geçmeyiniz.")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Şifre alanını boş geçmeyiniz.")]
        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }
}