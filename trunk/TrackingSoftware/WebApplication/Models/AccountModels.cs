using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Globalization;
using System.Web.Security;

namespace WebApplication.Models {


    public class LoginModel {
        [Required]
        [Display(Name = "Օգտագործողի անուն")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Գաղտնաբառ")]
        public string Password { get; set; }

        [Display(Name = "Հիշել")]
        public bool RememberMe { get; set; }
    }




}
