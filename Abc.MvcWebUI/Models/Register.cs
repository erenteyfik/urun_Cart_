using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Abc.MvcWebUI.Models
{
    public class Register
    {
        //required  kullanıcı bir deger girecek 
        [Required]
        [DisplayName("Adınız")]
        public string Name { get; set; }

        [Required]
        [DisplayName("Soyadınız")]
        public string Surname { get; set; }


        [Required]
        [DisplayName("Kullanıcı Adı")]
        public string UserName { get; set; }

        [Required]
        [DisplayName("Eposta")]
        [EmailAddress(ErrorMessage = "Eposta adresinizi düzgün giriniz.")]
        public string Email { get; set; }

        [Required]
        [DisplayName("Şifre")]
        public string Password { get; set; }


        //compare karşılaştırma yapmamızı saglıyor.
        [Required]
        [DisplayName("Şifre Tekrar")]
        [Compare("Password",ErrorMessage = "Şifreleriniz uyuşmuyor.")]
        public string Repassword { get; set; }   
    }
}