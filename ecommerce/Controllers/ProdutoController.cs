using System;
using ecommerce.Models;
using ecommerce.Models.acessoBD;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Collections.Generic;

namespace ecommerce.Controllers
{
    public class ProdutoController : Controller
    {
        // GET: Produto
        public ActionResult Index(int id)
        {
            RestritoDAO restritoDAO = new RestritoDAO(new ConexaoBD(DadosDaConexao.StringDeConexao));
            Produto produto = new Produto();
            List<Produto> destaques = new List<Produto>();

            produto = restritoDAO.retorna_produto(id);
            destaques = restritoDAO.retorna_destaques();

            Resumo_Produtos resumo_produtos = new Resumo_Produtos(produto, destaques);


            return View(resumo_produtos);
        }
    }
}