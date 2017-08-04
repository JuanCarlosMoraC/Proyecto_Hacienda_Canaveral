using MVCEFHaciendaCañaveral.Business;
using MVCEFHaciendaCañaveral.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCEFHaciendaCañaveral.Controllers
{
    public class IngredienteController : Controller
    {
        private IngredienteBusiness ingredienteBusiness;
        private RecetaBusiness recetaBusiness;

        public IngredienteController()
        {
            this.ingredienteBusiness = new IngredienteBusiness();
            this.recetaBusiness = new RecetaBusiness();
        }
        // GET: Ingrediente
        public ActionResult Index()
        {
            var model = ingredienteBusiness.GetAllIngredientes();
            return View(model);
        }

        public ActionResult Preview(string file)
        {
            var path = ControllerContext.HttpContext.Server.MapPath("~/Images/Ingredientes/");
            if (System.IO.File.Exists(Path.Combine(path, file)))
            {
                return File(Path.Combine(path, file), "image/jpeg");
            }
            return new HttpNotFoundResult();
        }


        // GET: Ingrediente/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Ingrediente/Create
        public ActionResult Create()
        {
            ViewBag.Recetas = recetaBusiness.GetAllRecetaItem();
            return View();
        }

        // POST: Ingrediente/Create
        [HttpPost]
        public ActionResult Create(Ingrediente ingrediente, HttpPostedFileBase file)
        {
            try
            {
                string ruta = Server.MapPath("~/Images/Ingredientes/");

                if (ingredienteBusiness.Create(ingrediente, file, ruta))
                {
                    Response.Write("<script language='JavaScript'>alert('Ingrediente registrado con exito');</script>");
                    return RedirectToAction("Index");
                }
            }
            catch
            {
            }
            return View();
        }

        // GET: Ingrediente/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Ingrediente/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Ingrediente/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Ingrediente/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
