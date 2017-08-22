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
    public class AdmIngressosController : Controller
    {
        private ServidorEventoEntities db = new ServidorEventoEntities();

        //
        // GET: /Admin/AdmIngressos/

        public ActionResult Index()
        {
            return View(db.Ingressos.ToList());
        }

        //
        // GET: /Admin/AdmIngressos/Details/5

        public ActionResult Details(int id = 0)
        {
            Ingressos ingressos = db.Ingressos.Find(id);
            if (ingressos == null)
            {
                return HttpNotFound();
            }
            return View(ingressos);
        }

        //
        // GET: /Admin/AdmIngressos/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Admin/AdmIngressos/Create

        [HttpPost]
        public ActionResult Create(Ingressos ingressos)
        {
            if (ModelState.IsValid)
            {
                db.Ingressos.Add(ingressos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(ingressos);
        }

        //
        // GET: /Admin/AdmIngressos/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Ingressos ingressos = db.Ingressos.Find(id);
            if (ingressos == null)
            {
                return HttpNotFound();
            }
            return View(ingressos);
        }

        //
        // POST: /Admin/AdmIngressos/Edit/5

        [HttpPost]
        public ActionResult Edit(Ingressos ingressos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ingressos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ingressos);
        }

        //
        // GET: /Admin/AdmIngressos/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Ingressos ingressos = db.Ingressos.Find(id);
            if (ingressos == null)
            {
                return HttpNotFound();
            }
            return View(ingressos);
        }

        //
        // POST: /Admin/AdmIngressos/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Ingressos ingressos = db.Ingressos.Find(id);
            db.Ingressos.Remove(ingressos);
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