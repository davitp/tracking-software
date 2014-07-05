using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Globalization;
using System.Web.Security;

namespace WebApplication.Models {
    public class CarStateHistoryModel {

        public int Id { get; set; }

        [Display(Name = "Սկիզբ")]
        public DateTime Start { get; set; }
        
        [Display(Name = "Ավարտ")]
        public DateTime End { get; set; }
    }
}