using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Project.UI.Models
{
    public class AppUserViewModel
    {
        [Required(ErrorMessage ="Ad bilgisi boş geçilemez"),MinLength(3,ErrorMessage ="Adınız en az 3 karakter olmalıdır.")]

        public string Name { get; set; }

        [Required(ErrorMessage = "Soyad bilgisi boş geçilemez"), MinLength(3, ErrorMessage = "Soyadınız en az 3 karakter olmalıdır.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Kullanıcı adı bilgisi boş geçilemez"), MinLength(3, ErrorMessage = "Kullanıcı adınız en az 3 karakter olmalıdır.")]
        public string UserName { get; set; }

        [Required(ErrorMessage ="Şifre boş geçilemez."),MinLength(3),MaxLength(16)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Şifre boş geçilemez."), MinLength(3), MaxLength(16),Compare("Password",ErrorMessage ="Şifre ve Şifre Tekrarı uyuşmamaktadır.")]
        public string ComparePassword { get; set; }

        [EmailAddress(ErrorMessage ="Girdiğiniz metin e-mail formatında değildi."),Required(ErrorMessage ="Email adresi zorunlu bir alandır.Boş geçilemez.")]
        public string Email { get; set; }
    }
}