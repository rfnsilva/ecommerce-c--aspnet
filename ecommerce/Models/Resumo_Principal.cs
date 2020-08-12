using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ecommerce.Models
{
    public class Resumo_Principal
    {
        //public Users_r user { get; set; }
        public List<Produto> produtos { get; set; }
        public List<Slider> sliders { get; set; }
        public List<Categoria> categorias { get; set; }
        public List<Social> sociais { get; set; }

        public Resumo_Principal(List<Produto> produtos1, List<Slider> sliders1, List<Categoria> categorias1, List<Social> sociais1)
        {
            produtos = produtos1;
            sliders = sliders1;
            categorias = categorias1;
            sociais = sociais1;
        }
    }
}