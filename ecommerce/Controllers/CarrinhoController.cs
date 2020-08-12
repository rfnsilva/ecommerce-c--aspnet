using ecommerce.Models;
using ecommerce.Models.acessoBD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ecommerce.Controllers
{
    public class CarrinhoController : Controller
    {
        // GET: Carrinho
        public ActionResult Index()
        {
            RestritoDAO restritoDAO = new RestritoDAO(new ConexaoBD(DadosDaConexao.StringDeConexao));
            List<Carrinho> carrinho = restritoDAO.retorna_card(Convert.ToInt32(Session["id_user"]));


            return View(carrinho);
        }

        public ActionResult add_card(int id)
        {
            RestritoDAO restritoDAO = new RestritoDAO(new ConexaoBD(DadosDaConexao.StringDeConexao));
            Produto prod = restritoDAO.retorna_produto(id);
            restritoDAO.regitra_prod_card(Convert.ToInt32(Session["id_user"]), id);
            return Json(prod, JsonRequestBehavior.AllowGet);
        }
    }
}