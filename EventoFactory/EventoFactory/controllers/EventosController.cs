using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EventoFactory.Models;
using EventoFactory.DAO;

namespace EventoFactory.Controllers
{
    public class EventosController : Controller
    {
        private ServidorEventoEntities db = new ServidorEventoEntities();

        private EventosDAO eventosDAO = new EventosDAO();

        //
        // GET: /Eventos/

        public ActionResult Index()
        {
            var eventos = db.Eventos.Include(e => e.Ingressos).Include(e => e.Locais);
            return View(eventos.ToList());
        }

        //
        // GET: /Eventos/Details/5

        public ActionResult Details(int id = 0)
        {
            Eventos eventos = db.Eventos.Find(id);
            if (eventos == null)
            {
                return HttpNotFound();
            }
            return View(eventos);
        }

        //
        // GET: /Eventos/Create

        public ActionResult Create()
        {
            ViewBag.ID_Ingresso = new SelectList(db.Ingressos, "ID_Ingresso", "ID_Ingresso");
            ViewBag.ID_Local = new SelectList(db.Locais, "ID_Local", "Endereco");
            return View();
        }

        //
        // POST: /Eventos/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Eventos evento)
        {
            if (ModelState.IsValid)
            {                
                Ingressos ingresso = new Ingressos();

                ingresso.Quantidade = evento.Capacidade;

                db.Eventos.Add(evento);
                db.Ingressos.Add(ingresso);
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            ViewBag.ID_Ingresso = new SelectList(db.Ingressos, "ID_Ingresso", "ID_Ingresso", evento.ID_Ingresso);
            ViewBag.ID_Local = new SelectList(db.Locais, "ID_Local", "Endereco", evento.ID_Local);
            return View(evento);
        }

        //
        // GET: /Eventos/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Eventos eventos = db.Eventos.Find(id);
            if (eventos == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_Ingresso = new SelectList(db.Ingressos, "ID_Ingresso", "ID_Ingresso", eventos.ID_Ingresso);
            ViewBag.ID_Local = new SelectList(db.Locais, "ID_Local", "Endereco", eventos.ID_Local);
            return View(eventos);
        }

        //
        // POST: /Eventos/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Eventos eventos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(eventos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_Ingresso = new SelectList(db.Ingressos, "ID_Ingresso", "ID_Ingresso", eventos.ID_Ingresso);
            ViewBag.ID_Local = new SelectList(db.Locais, "ID_Local", "Endereco", eventos.ID_Local);
            return View(eventos);
        }

        
        public ActionResult Delete(long id)
        {
            try
            {
                eventosDAO.Delete(id);
                
                var eventos = db.Eventos;

                return View("Index", eventos);
            }
            catch (InvalidOperationException ioe)
            {
                var eventos = db.Eventos;

                return View("Index", eventos);
            }

        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}