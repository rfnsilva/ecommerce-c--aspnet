using ecommerce.Models;
using ecommerce.Models.acessoBD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using X.PagedList;

namespace ecommerce.Controllers
{
    public class ProdutosController : Controller
    {
        // GET: Produtos
        public ActionResult Index(int pagina = 1)
        {
            RestritoDAO restritoDAO = new RestritoDAO(new ConexaoBD(DadosDaConexao.StringDeConexao));
            List<Produto> todos_produtos = new List<Produto>();

            todos_produtos = restritoDAO.retorna_produtos();

            var pro_p = todos_produtos.OrderBy(p => p.id).ToPagedList(pagina, 10);

            return View(pro_p);
        }
    }
}