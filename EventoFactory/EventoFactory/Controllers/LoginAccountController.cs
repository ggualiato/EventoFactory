using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EventoFactory.Models;

namespace EventoFactory.Controllers
{
    public class LoginAccountController : Controller
    {
        //
        // GET: /Login/

        /// <param name="returnURL"></param>
        /// <returns></returns>
        public ActionResult Login(string returnURL)
        {
            /*Recebe a url que o usuário tentou acessar*/
            ViewBag.ReturnUrl = returnURL;
            return View(new Usuarios());
        }

    }
}
