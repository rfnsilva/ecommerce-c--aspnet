using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ecommerce.Models
{
    [Table("produtos")]
    public class Produto
    {
        public int id { get; set; }
        public string nome { get; set; }
        public string descricao { get; set; }
        public string imagem { get; set; }
        public int valor { get; set; }
        public string fav { get; set; }
        public string destaque { get; set; }
        public string imagem_min { get; set; }
    }
}