using MVCEFHaciendaCañaveral.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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

        public List<SelectListItem> GetAllRolesItem()
        {
            List<SelectListItem> listaItem = new List<SelectListItem>();

            using (var db = new HaciendaCañaveralContext())
            {
                List<Role> roles = GetAllRoles();

                foreach (var item in roles)
                {
                    listaItem.Add(new SelectListItem()
                    {
                        Value = item.IdRole.ToString(),
                        Text = item.Descripcion
                    });
                }
            }
            return listaItem;
        }

        public Role GetRoleById(int idRole)
        {
            using (var db = new HaciendaCañaveralContext())
            {
                return db.Role.Single(x => x.IdRole == idRole);
            }
        }

        public void Editar(Role role)
        {
            using (var db = new HaciendaCañaveralContext())
            {
                db.Entry(role).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
        }

        public void Eliminar(int idRole)
        {
            using (var db = new HaciendaCañaveralContext())
            {
                Role r = db.Role.Find(idRole);
                db.Role.Remove(r);
                db.SaveChanges();
            }
        }

        public void Crear(Role role)
        {
            using (var db = new HaciendaCañaveralContext())
            {
                db.Role.Add(role);
                db.SaveChanges();
            }
        }
    }
}