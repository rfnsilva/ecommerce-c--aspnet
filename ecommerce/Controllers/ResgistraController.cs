using ecommerce.Models;
using ecommerce.Models.acessoBD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ecommerce.Controllers
{
    public class ResgistraController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        // Resgistra
        [AllowAnonymous]
        [HttpPost]
        public ActionResult registra(Users_r users_r)
        {
            ConexaoBD dALConexao = new ConexaoBD(DadosDaConexao.StringDeConexao);
            UserDAO userDAO = new UserDAO(dALConexao);

            if(userDAO.registra(users_r.nome, users_r.senha)){
                //registrado com sucesso
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return RedirectToAction("Index", "Resgistra");
            }
        }
    }
}