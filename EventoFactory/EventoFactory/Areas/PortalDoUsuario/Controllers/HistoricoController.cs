using EventoFactory.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.Data;
using System.Net;

namespace EventoFactory.Areas.PortalDoUsuario.Controllers
{
    
    public class HistoricoController : Controller
    {
        //
        // GET: /Historico/

        private ServidorEventoEntities db = new ServidorEventoEntities();

        public ActionResult Historico(long? id)
        {

            var compras = db.Compras.Include(u => u.Ingressos.Eventos);
            compras = db.Compras.Include(u => u.Usuarios);
            compras = db.Compras.Include(u => u.Ingressos);
            return View(compras.ToList());
        }

    }
}
