using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EventoFactory.Models;
using System.Web.Security;

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

        /// <param name="login"></param>
        /// <param name="returnUrl"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Usuarios login, string returnUrl)
        {
            


            //if (ModelState.IsValid)
            //{
            using (ServidorEventoEntities db = new ServidorEventoEntities())
            {
                 var vLogin = db.Usuarios.Where(p => p.Usuario.Equals(login.Usuario)).FirstOrDefault();
                /*Verificar se a variavel vLogin está vazia. Isso pode ocorrer caso o usuário não existe. 
                Caso não exista ele vai cair na condição else.*/
                if (vLogin != null)
                {
                    /*Código abaixo verifica se a senha digitada no site é igual a senha que está sendo retornada 
                    do banco. Caso não cai direto no else*/

                    if (Equals(vLogin.Senha, login.Senha))
                    {
                        FormsAuthentication.SetAuthCookie(vLogin.Usuario, false);
                        if (Url.IsLocalUrl(returnUrl)
                        && returnUrl.Length > 1
                        && returnUrl.StartsWith("/")
                        && !returnUrl.StartsWith("//")
                        && returnUrl.StartsWith("/\\"))
                        {
                            return Redirect(returnUrl);
                        }
                        /*código abaixo cria uma session para armazenar o nome do usuário*/
                        Session["Nome"] = vLogin.Nome;
                        /*código abaixo cria uma session para armazenar o sobrenome do usuário*/
                        Session["Sobrenome"] = vLogin.Perfil;
                        /*retorna para a tela inicial do Sobre*/
                        if (vLogin.Perfil == "administrador")
                        {
                            return RedirectToAction("Index", "Admin/Home", vLogin.Perfil);
                        }

                        return RedirectToAction("Index", "PortalDoUsuario/Home", vLogin.Perfil);
                    }
                    /*Else responsável da validação da senha*/
                    else
                    {
                        /*Escreve na tela a mensagem de erro informada*/
                        ModelState.AddModelError("", "Senha informada Inválida!!!");
                        /*Retorna a tela de login*/
                        return View(new Usuarios());
                    }

                }
                /*Else responsável por verificar se o usuário existe*/
                else
                {
                    /*Escreve na tela a mensagem de erro informada*/
                    ModelState.AddModelError("", "E-mail informado inválido!!!");
                    /*Retorna a tela de login*/
                    return View(new Usuarios());
                }
            }
        }
        //    /*Caso os campos não esteja de acordo com a solicitação retorna a tela de login com as mensagem dos campos*/
        //    return View();
        //}

    }
}
