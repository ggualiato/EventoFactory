using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using EventoFactory.Models;
using System.Net;

namespace EventoFactory.Controllers
{
    public class EventoController : Controller
    {
        ServidorEventoEntities db = new ServidorEventoEntities();
        
        //
        // GET: /Evento/

        public ActionResult Index(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Eventos evento = db.Eventos.Find(id);

            if (evento == null)
            {
                return HttpNotFound();
            }

            return View("Index", evento);
        }
        


    }
}
