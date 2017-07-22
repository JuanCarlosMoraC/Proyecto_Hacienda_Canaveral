using MVCEFHaciendaCañaveral.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCEFHaciendaCañaveral.Business
{
    public class RoleBusiness
    {
        public List<Role> GetAllRoles()
        {
            using (var db = new HaciendaCañaveralContext())
            {
                return db.Role.ToList();
            }
        }

        internal Role GetRoleById(int idRole)
        {
            using (var db = new HaciendaCañaveralContext())
            {
                return db.Role.Single(x => x.IdRole == idRole);
            }
        }

        internal void Editar(Role role)
        {
            using (var db = new HaciendaCañaveralContext())
            {

                //db.Role.Attach(role);
                db.Entry(role).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
        }

        internal void Eliminar(int idRole)
        {
            using (var db = new HaciendaCañaveralContext())
            {

                Role r = GetRoleById(idRole);
                db.Entry(r).State = System.Data.Entity.EntityState.Deleted;
                db.SaveChanges();
            }
        }

        internal void Crear(Role role)
        {
            using (var db = new HaciendaCañaveralContext())
            {
                db.Role.Add(role);
                db.SaveChanges();
            }
        }
    }
}