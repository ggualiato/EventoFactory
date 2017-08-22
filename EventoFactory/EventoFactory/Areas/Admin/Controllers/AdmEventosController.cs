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

namespace EventoFactory.Areas.Admin.Controllers
{
    public class AdmEventosController : Controller
    {
        private ServidorEventoEntities db = new ServidorEventoEntities();

        //
        // GET: /AdmEventos/

        public ActionResult Index()
        {
            var eventos = db.Eventos.Include(e => e.Locais);
            eventos = db.Eventos.Include(e => e.Ingressos);
            return View(eventos.ToList());
        }

        //
        // GET: /AdmEventos/Details/5

        public ActionResult Details(int? id)
        {
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Eventos eventos = db.Eventos.Find(id);
            if (eventos == null) {
                return HttpNotFound();
            }

            return View(eventos);
        }

        //
        // GET: /AdmEventos/Create

        public ActionResult Create()
        {
            ViewBag.ID_Local = new SelectList(db.Locais, "ID_Local", "Endereco");
            ViewBag.ID_Ingresso = new SelectList(db.Ingressos, "ID_Ingresso", "ID_Ingresso");



            return View();
        }

        //
        // POST: /AdmEventos/Create

        [HttpPost]
        public ActionResult Create(Eventos eventos, HttpPostedFileBase file)
        {
            if (ModelState.IsValid) {
                if (file != null && file.ContentLength > 0 && (file.ContentType == "image/jpg" || file.ContentType == "image/jpeg" || file.ContentType == "image/png")) {

                    int filelenght = file.ContentLength;

                    byte[] imagebytes = new byte[filelenght];

                    file.InputStream.Read(imagebytes, 0, filelenght);



                    eventos.Imagem = imagebytes;

                    // TODO Implementar método de inserção no banco

                }


                db.Eventos.Add(eventos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }



            ViewBag.ID_Local = new SelectList(db.Locais, "ID_Local", "Endereco", eventos.ID_Local);
            ViewBag.ID_Local = new SelectList(db.Locais, "ID_Ingresso", "ID_Ingresso", eventos.ID_Ingresso);
            return View(eventos);


        }

        [HttpPost]
        public ActionResult CriarLocal(Locais loc)
        {
            if (ModelState.IsValid) {
                db.Locais.Add(loc);
                db.SaveChanges();
                return RedirectToAction("Create");
            }

            ViewBag.ID_Local = new SelectList(db.Locais, "ID_Local", "Endereco", loc.ID_Local);
            ViewBag.ID_Ingresso = new SelectList(db.Ingressos, "ID_Ingresso", "ID_Ingresso");
            return View(loc);



        }



        //
        // GET: /AdmEventos/Edit/5

        public ActionResult Edit(int? id)
        {
            Eventos eventos = db.Eventos.Find(id);
            if (eventos == null) {
                return HttpNotFound();
            }
            ViewBag.ID_Local = new SelectList(db.Locais, "ID_Local", "Endereco", eventos.ID_Local);
            ViewBag.ID_Ingresso = new SelectList(db.Ingressos, "ID_Ingresso", "ID_Ingresso");
            return View(eventos);
        }

        //
        // POST: /AdmEventos/Edit/5

        [HttpPost]
        public ActionResult Edit(Eventos eventos)
        {
            if (ModelState.IsValid) {
                db.Entry(eventos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_Local = new SelectList(db.Locais, "ID_Local", "Endereco", eventos.ID_Local);
            ViewBag.ID_Local = new SelectList(db.Locais, "ID_Ingresso", "ID_Ingresso", eventos.ID_Ingresso);
            return View(eventos);
        }

        //
        // GET: /AdmEventos/Delete/5

        public ActionResult Delete(int? id)
        {
            Eventos eventos = db.Eventos.Find(id);
            if (eventos == null) {
                return HttpNotFound();
            }
            return View(eventos);
        }

        //
        // POST: /AdmEventos/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Eventos eventos = db.Eventos.Find(id);
            db.Eventos.Remove(eventos);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}