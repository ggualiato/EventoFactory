using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EventoFactory.Models;

namespace EventoFactory.DAO
{
    public class EventosDAO
    {
        ServidorEventoEntities db = new ServidorEventoEntities();



        public Boolean Delete(long id)
        {
            //try
            //{                
                Eventos evento = db.Eventos.Find(id);

                db.Eventos.Remove(evento);
                db.SaveChanges();

                return true;

            //}catch(Exception e)
            //{
                //Descobrir exceções
            //}

            
        }
    }
}