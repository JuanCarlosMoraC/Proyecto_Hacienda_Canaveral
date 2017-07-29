using MVCEFHaciendaCañaveral.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCEFHaciendaCañaveral.Business
{
    public class TelefonoBusiness
    {

        public List<Telefono> getAllPhones()
        {
            using (var db= new HaciendaCañaveralContext())
            {
                return db.Telefono.ToList();
            }
        }

        public Telefono getPhoneById(int idPhone)
        {
            using (var db = new HaciendaCañaveralContext())
            {
                return db.Telefono.Single(t => t.IdTelefono == idPhone);
            }
        }

        internal void Crear(Telefono telefono)
        {
            using (var db = new HaciendaCañaveralContext())
            {
                db.Telefono.Add(telefono);
                db.SaveChanges();
            }
        }

        internal void Editar(Telefono telefono)
        {
            using (var db = new HaciendaCañaveralContext())
            {
                db.Entry(telefono).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
        }
    }
}