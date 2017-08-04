using MVCEFHaciendaCañaveral.Models;
using MVCEFHaciendaCañaveral.Security;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace MVCEFHaciendaCañaveral.Business
{
    public class UsuarioBusiness
    {
        public List<Usuario> GetAllUsers()
        {
            using (var db = new HaciendaCañaveralContext())
            {
                return db.Usuario.Include("Role").ToList();
            }
        }

        public Usuario UserByID(int idUsuario)
        {
            using (var db = new HaciendaCañaveralContext())
            {
                return db.Usuario.Include("Role").Single(u => u.IdUsuario == idUsuario);
            }
        }

        public void Editar(Usuario usuario)
        {
            usuario.Password = HashHelper.MD5(usuario.Password);
            using (var db = new HaciendaCañaveralContext())
            {
                db.Entry(usuario).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
        }

        public void Crear(Usuario usuario)
        {
            usuario.Password = HashHelper.MD5(usuario.Password);
            using(var db = new HaciendaCañaveralContext())
            {
                db.Usuario.Add(usuario);
                db.SaveChanges();
            }

        }

        public void Eliminar(int idUsuario)
        {
            using (var db = new HaciendaCañaveralContext())
            {
                Usuario usuario = db.Usuario.Find(idUsuario);
                db.Usuario.Remove(usuario);
                db.SaveChanges();
            }
        }
    }
}