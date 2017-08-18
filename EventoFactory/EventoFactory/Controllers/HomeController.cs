using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EventoFactory.Models;
using System.Web.Security;

namespace EventoFactory.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {

            FormsAuthentication.SignOut();
            Session["Nome"] = null;
            Session["Sobrenome"] = null;
           

            return View();
        }

    }
}
