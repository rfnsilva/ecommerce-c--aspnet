using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ecommerce.Models
{
    public class Resumo_Produtos
    {
        public Produto produto { get; set; }
        public List<Produto> destaques { get; set; }

        public Resumo_Produtos(Produto produto1, List<Produto> destaques1)
        {
            produto = produto1;
            destaques = destaques1;
        }
    }
}