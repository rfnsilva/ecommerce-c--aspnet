using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ecommerce.Models
{
    public class Users_r
    {
        public int id { get; set; }
        [Required]
        public string nome { get; set; }

        [Required]
        public string senha { get; set; }

        public string token { get; set; }
    }
}