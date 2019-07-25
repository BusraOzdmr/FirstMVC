using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FirstMVC.Models
{
    public class ContactViewModel
    {
        [Display(Name = "Ad")]
        [Required(ErrorMessage = "Ad alanı gereklidir.")]
        [MaxLength(50)]
        public string FirstName { get; set; }
        [Display(Name = "Soyad")]
        [Required(ErrorMessage = "Soyad alanı gereklidir.")]
        [MaxLength(50)]
        public string LastName { get; set; }
        [Display(Name = "Telefon")]
        [Required(ErrorMessage = "Telefon alanı gereklidir.")]
        [MaxLength(20)]
        [Phone]
        public string Telephone { get; set; }
        [Display(Name = "E-posta")]
        [Required(ErrorMessage = "E-posta alanı gereklidir.")]
        [MaxLength(100)]
        [EmailAddress]
        public string Email { get; set; }
        [Display(Name = "Mesaj")]
        [Required(ErrorMessage = "Mesaj alanı gereklidir.")]
        [MaxLength(4000)]
        public string Message { get; set;  }
        [Display(Name="Kvkk")]
        [Required(ErrorMessage = "Sözleşmeyi kabul etmelisiniz")]
        public bool PrivacyPolicyAccepted { get; set; }

    }
}