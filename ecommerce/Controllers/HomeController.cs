using ecommerce.Models;
using ecommerce.Models.acessoBD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ecommerce.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            RestritoDAO restritoDAO = new RestritoDAO(new ConexaoBD(DadosDaConexao.StringDeConexao));
            List<Produto> favoritos = new List<Produto>();
            List<Slider> sliders = new List<Slider>();
            //Users_r user = new Users_r();
            List<Categoria> categorias = new List<Categoria>();
            List<Social> sociais = new List<Social>();
            favoritos = restritoDAO.retorna_fav();
            sociais = restritoDAO.retorna_sociais();
            sliders = restritoDAO.retorna_sliders();
            categorias = restritoDAO.retorna_categorias();
            Resumo_Principal resumo_principal = new Resumo_Principal(favoritos, sliders, categorias, sociais);

            return View(resumo_principal);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}