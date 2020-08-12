using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ecommerce.Controllers
{
    public class ContaController : Controller
    {
        // GET: Conta
        [Authorize]
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
    }
}