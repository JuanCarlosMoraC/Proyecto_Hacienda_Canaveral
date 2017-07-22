using MVCEFHaciendaCañaveral.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace MVCEFHaciendaCañaveral.Business
{
    public class UsuarioBusiness
    {
        public List<Usuario> GetAllUsers()
        {
            using (var db = new HaciendaCañaveralContext())
            {
                return db.Usuario.Include(x => x.Role).ToList();
            }
        }

        public Usuario UserByID(int idUsuario)
        {
            using (var db= new HaciendaCañaveralContext())
            {
                return db.Usuario.Include(x => x.Role).Single(u => u.IdUsuario == idUsuario);
            }
        }

        internal void Editar(Usuario usuario)
        {
            using (var db= new HaciendaCañaveralContext())
            {
                db.Usuario.Attach(usuario);
                db.SaveChanges();
            }
        }

        internal void Crear(Usuario usuario)
        {
            using (var db = new HaciendaCañaveralContext())
            {
                db.Usuario.Add(usuario);
                db.SaveChanges();
            }
        }

        internal void Eliminar(Usuario usuario)
        {
            using (var db = new HaciendaCañaveralContext())
            {
                db.Usuario.Remove(usuario);
                db.SaveChanges();
            }
        }
    }
}