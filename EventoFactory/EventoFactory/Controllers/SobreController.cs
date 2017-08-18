using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EventoFactory.Controllers
{
    [Authorize(Roles = "Administrador")]
    public class SobreController : Controller
    {
        //
        // GET: /Sobre/

        public ActionResult SobreFactory()
        {
            return View();
        }

    }
}
