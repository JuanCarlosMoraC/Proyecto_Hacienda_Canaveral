using MVCEFHaciendaCañaveral.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCEFHaciendaCañaveral.Business
{
    public class RecetaBusiness
    {

        public List<Receta> GetAllRecetas()
        {
            using (var db= new HaciendaCañaveralContext())
            {
                return db.Receta.Include("Ingredientes").Include("Instrucciones").ToList();
            }
        }
        
        public Receta GetRecetaById(int idReceta)
        {
            using (var db = new HaciendaCañaveralContext())
            {
                return db.Receta.Include("Ingredientes").Include("Instrucciones").Single(r => r.IdReceta == idReceta);
            }
        }

        public List<SelectListItem> GetAllRecetaItem()
        {
            List<SelectListItem> listaItem = new List<SelectListItem>();

            using (var db = new HaciendaCañaveralContext())
            {
                List<Receta> recetas = GetAllRecetas();

                foreach (var item in recetas)
                {
                    listaItem.Add(new SelectListItem()
                    {
                        Value = item.IdReceta.ToString(),
                        Text = item.Nombre
                    });
                }
            }
            return listaItem;
        }

        internal void Create(Receta receta)
        {
            using (var db = new HaciendaCañaveralContext())
            {
                db.Receta.Add(receta);
                db.SaveChanges();
            }
        }
    }
}