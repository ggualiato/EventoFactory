using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EventoFactory.Controllers
{
    public class AdminController : Controller
    {
        //
        // GET: /Admin/

        ///[Authorize(Roles = "Administrador")]
        public ActionResult Admin()
        {
            return View();
        }

    }
}

