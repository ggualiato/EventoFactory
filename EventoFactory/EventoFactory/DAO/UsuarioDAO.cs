using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EventoFactory.Models;

namespace EventoFactory.DAO
{
    public class UsuarioDAO
    {
        ServidorEventoEntities db = new ServidorEventoEntities();

        public Boolean CadastrarUsuario(Usuarios a)
        {
            try
            {
                db.Usuarios.Add(a);
                db.SaveChanges();

                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

    }
}