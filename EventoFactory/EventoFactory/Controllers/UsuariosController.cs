using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EventoFactory.Models;
using EventoFactory.DAO;

namespace EventoFactory.Controllers
{
    public class UsuariosController : Controller
    {

        private UsuarioDAO usuarioDAO = new UsuarioDAO();

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Cadastrar(Usuarios u)
        {
            u.Perfil = "usuario";

            if (ModelState.IsValid)
            {
                if (usuarioDAO.CadastrarUsuario(u))
                {
                    ViewBag.Mensagem = "DEU CERTO";
                }
                else
                {
                    ViewBag.Mensagem = "EEERRRRROUUUUUUU BIXO";
                }
            }            

            return View();
        }

    }
}
