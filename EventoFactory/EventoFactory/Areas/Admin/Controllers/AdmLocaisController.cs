using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EventoFactory.Models;

namespace EventoFactory.Areas.Admin.Controllers
{
    public class AdmLocaisController : Controller
    {
        private ServidorEventoEntities db = new ServidorEventoEntities();

        //
        // GET: /AdmLocais/

        public ActionResult Index()
        {
            return View(db.Locais.ToList());
        }

        //
        // GET: /AdmLocais/Details/5

        public ActionResult Details(int id = 0)
        {
            Locais locais = db.Locais.Find(id);
            if (locais == null)
            {
                return HttpNotFound();
            }
            return View(locais);
        }

        //
        // GET: /AdmLocais/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /AdmLocais/Create

        [HttpPost]
        public ActionResult Create(Locais locais)
        {
            if (ModelState.IsValid)
            {
                db.Locais.Add(locais);
                db.SaveChanges();
                return RedirectToAction("Create", "AdmEventos");
            }

            ModelState.AddModelError("Bairro", "ERRRROUOU");

            return RedirectToAction("Create", "AdmEventos");            
        }

        //
        // GET: /AdmLocais/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Locais locais = db.Locais.Find(id);
            if (locais == null)
            {
                return HttpNotFound();
            }
            return View(locais);
        }

        //
        // POST: /AdmLocais/Edit/5

        [HttpPost]
        public ActionResult Edit(Locais locais)
        {
            if (ModelState.IsValid)
            {
                db.Entry(locais).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(locais);
        }

        //
        // GET: /AdmLocais/Delete/5

        public ActionResult Delete(int? id)
        {
            Locais locais = db.Locais.Find(id);
            if (locais == null)
            {
                return HttpNotFound();
            }
            return View(locais);
        }

        //
        // POST: /AdmLocais/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            try {
                Locais locais = db.Locais.Find(id);

                db.Locais.Remove(locais);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch (InvalidOperationException ioe) {

                ViewBag.msgErro = "NÃO É POSSIVEL";
                return RedirectToAction("Index");
            }
            
        } 


        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}