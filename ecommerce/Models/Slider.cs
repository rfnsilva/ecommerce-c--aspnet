using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ecommerce.Models
{
    [Table("slider")]
    public class Slider
    {
        public int id { get; set; }
        public string descricao { get; set; }
        public string imagem { get; set; }
    }
}