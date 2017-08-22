using EventoFactory.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EventoFactory.Areas.PortalDoUsuario.Controllers
{
    public class EventoController : Controller
    {
        //
        // GET: /Evento/
        ServidorEventoEntities db = new ServidorEventoEntities();
        public ActionResult Eventos()
        {
            var eventos = db.Eventos.ToList().Where(x => x.ID_Evento < 5);
            return View(eventos);
        }

    }
}
