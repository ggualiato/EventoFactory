using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EventoFactory.Models;
using System.Net;
using System.IO;
using System.Web.Security;


namespace EventoFactory.Areas.PortalDoUsuario.Controllers
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

        public ActionResult Evento(long? id, Usuarios login)
        {
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Eventos evento = db.Eventos.Find(id);

            if (evento == null) {
                return HttpNotFound();
            }
            
            return View("Eventos", evento);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Evento(Compras compras, Usuarios login, int quantidade, int idIngresso)
        {
            using (ServidorEventoEntities db = new ServidorEventoEntities()) {

                if (login.ID_Usuario == null) {

                    return RedirectToAction("login", "LoginAccount", compras);
                
                }
                var compra = new Compras() {
                    QTD_Comprada = quantidade,
                    ID_Usuario = Convert.ToInt32(@Session["ID"]),
                    ID_Ingresso = idIngresso
                };
                db.Compras.Add(compra);
                db.SaveChanges();

                return RedirectToAction("Historico", "Historico", compra);

            }
        }

        public ActionResult Details(int id = 0)
        {
            Eventos evento = db.Eventos.Find(id);

            if (evento.ID_Evento == null) {
                return HttpNotFound();
            }
            return View("Eventos", evento);
        }


        public ActionResult TodosEventos()
        {
            var eventos = db.Eventos.ToList();

            if (eventos == null) {
                return HttpNotFound();
            }
            return View(eventos);

        }
    }
}
