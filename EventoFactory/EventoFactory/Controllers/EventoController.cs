using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EventoFactory.Controllers
{
    public class EventoController : Controller
    {
        //
        // GET: /Evento/

        public ActionResult Eventos()
        {
            return View();
        }

    }
}
