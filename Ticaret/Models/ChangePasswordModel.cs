﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Ticaret.Models
{
    public class ChangePasswordModel
    {
        [Required]
        [DisplayName("Eski Şifre")]
        public string OldPassword { get; set; }
        [Required]
        [StringLength(100, MinimumLength =5, ErrorMessage ="Şifreniz En Az 5 karakter olmalı")]
        [DisplayName("Yeni Şifre")]
        public string NewPassword { get; set; }
        [Required]
        [DisplayName("Şifre Tekrar")]
        [Compare("NewPassword", ErrorMessage ="Şifreler Aynı Değil.. ")]
        public string ConNewPassword { get; set; }

    }
}