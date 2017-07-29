using MVCEFHaciendaCañaveral.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCEFHaciendaCañaveral.Business
{
    public class CorreoBusiness
    {
        internal object GetAllCorreo()
        {
            using (var db = new HaciendaCañaveralContext())
            {
                return db.Correo.ToList();
            }
        }

        internal Correo GetCorreoById(int idCorreo)
        {
            using (var db = new HaciendaCañaveralContext())
            {
                return db.Correo.Single(c => c.IdCorreo == idCorreo);
            }
        }

        internal void Crear(Correo correo)
        {
            using (var db = new HaciendaCañaveralContext())
            {
                db.Correo.Add(correo);
                db.SaveChanges();
            }
        }

        internal void Editar(Correo correo)
        {
            using (var db = new HaciendaCañaveralContext())
            {
                db.Entry(correo).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
        }
    }
}