using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVCEFHaciendaCañaveral.Controllers;
using MVCEFHaciendaCañaveral.Models;
using System.Web.Mvc;

namespace MVCEFHaciendaCañaveral.Business
{
    public class DatosOrganizacionalesBusiness
    {
        public List<DatosOrganizacionales> getAllDataOrganizacional()
        {
            using (var db = new HaciendaCañaveralContext())
            {
                return db.DatosOrganizacionales.Include("Correos").Include("Telefonos").ToList();
            }
        }

        public List<SelectListItem> GetAllDatosItem()
        {
            List<SelectListItem> listaItem = new List<SelectListItem>();

            using (var db = new HaciendaCañaveralContext())
            {
                List<DatosOrganizacionales> datos= getAllDataOrganizacional();

                foreach (var item in datos)
                {
                    listaItem.Add(new SelectListItem()
                    {
                        Value = item.IdDatosOrganizacionales.ToString(),
                        Text = item.Nombre
                    });
                }
            }
            return listaItem;
        }

        public void Crear(DatosOrganizacionales datos)
        {
            using (var db = new HaciendaCañaveralContext())
            {
                db.DatosOrganizacionales.Add(datos);
                db.SaveChanges();
            }
        }

        public DatosOrganizacionales GetDatoById(int id)
        {
            using (var db = new HaciendaCañaveralContext())
            {
                return db.DatosOrganizacionales.Include("Correos").Include("Telefonos").Single(x => x.IdDatosOrganizacionales == id);
            }
        }

        public void Editar(DatosOrganizacionales datos)
        {
            using (var db = new HaciendaCañaveralContext())
            {
                db.Entry(datos).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
        }
    }
}