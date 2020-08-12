using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using ecommerce.Models;
using System.Text;
using System.Web;
using System.Web.Mvc;
using ecommerce.Models.acessoBD;
using System.Security.Principal;
using static ecommerce.Models.User;
using System.Web.Security;

namespace ecommerce.Controllers
{
    public class AccountController : Controller
    {
        public string Key = "dfusa7f9090dfsiaisfdasfiuasjasdfa90cvzxxzcvasf998dfspd";
        public string Issuer = "RicardoIssuer";
        public string Audience = "RicardoAudience";

        public ActionResult Index()
        {
            return View();
        }

        //gera token
        public string gera_token(string nome, string senha)
        {
            var issuer = Issuer;
            var audience = Audience;
            var expiry = DateTime.Now.AddMinutes(60);
            var securityKey = new SymmetricSecurityKey
                              (Encoding.UTF8.GetBytes(Key));
            var credentials = new SigningCredentials
                              (securityKey, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(issuer: issuer,
                                             audience: audience,
                                             expires: DateTime.Now.AddMinutes(120),
                                             signingCredentials: credentials);
            var tokenHandler = new JwtSecurityTokenHandler();
            var stringToken = tokenHandler.WriteToken(token);
            return stringToken;
        }

        // Faz Login
        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login(string nome, string senha)
        {
            ConexaoBD dALConexao = new ConexaoBD(DadosDaConexao.StringDeConexao);
            UserDAO userDAO = new UserDAO(dALConexao);

            var result = userDAO.verifica_login(nome, senha);

            if (result != null) {
                var string_token = gera_token(result.nome, result.senha);
                result.token = string_token;
                Session["id_user"] = result.id;
                Session["nome_user"] = result.nome;
                FormsAuthentication.SetAuthCookie(result.nome, true);
                return RedirectToAction("Index", "Home", result);
            }
            else
            {
                return RedirectToAction("Index", "Account");
            }
        }
    }
}