using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EventoFactory.Models;
using System.Web.Security;
using System.Net;

namespace EventoFactory.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        ServidorEventoEntities db = new ServidorEventoEntities();

        public ActionResult Index()
        {

            FormsAuthentication.SignOut();
            Session["Nome"] = null;
            Session["Sobrenome"] = null;


            var eventos = db.Eventos.ToList().Where(x => x.ID_Evento < 5);
            
            return View(eventos);
        }

        public ActionResult Evento(long? id)
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

            return View("Eventos", evento);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Evento(Eventos evento)
        {



           
            using (ServidorEventoEntities db = new ServidorEventoEntities()) {


                return RedirectToAction("Historico", "PortalDoUsuario/Historico");

            }
        }




    }
}
