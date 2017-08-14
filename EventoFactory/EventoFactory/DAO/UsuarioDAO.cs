using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EventoFactory.Models;

namespace EventoFactory.DAO
{
    public class UsuarioDAO
    {
        ServidorEventoEntities1 db = new ServidorEventoEntities1();

        public Boolean CadastrarUsuario(Usuarios usuario)
        {
            try
            {
                db.Usuarios.Add(usuario);

                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

    }
}