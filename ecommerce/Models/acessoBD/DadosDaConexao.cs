using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ecommerce.Models.acessoBD
{
    public class DadosDaConexao
    {
        public static String servidor = @"RICARDO\SQLEXPRESS";
        public static String banco = "portifolio";

        public static String StringDeConexao
        {
            get
            {
                return @"Data Source=" + servidor + ";Initial Catalog=" + banco + ";Integrated Security=true;";
            }
        }
    }
}