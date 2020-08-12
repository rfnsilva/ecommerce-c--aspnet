using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ecommerce.Controllers
{
    public class FavoritosController : Controller
    {
        // GET: Favoritos
        public ActionResult Index()
        {
            return View();
        }
    }
}