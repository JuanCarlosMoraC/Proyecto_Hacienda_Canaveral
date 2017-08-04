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
    public class InstruccionController : Controller
    {
        private InstruccionBusiness instruccionBusiness;
        private RecetaBusiness recetaBusiness;

        public InstruccionController()
        {
            this.instruccionBusiness = new InstruccionBusiness();
            this.recetaBusiness = new RecetaBusiness();
        }

        // GET: Instruccion
        public ActionResult Index()
        {
            var model = instruccionBusiness.GetAllInstrucciones();
            return View(model);
        }

        public ActionResult Preview(string file)
        {
            var path = ControllerContext.HttpContext.Server.MapPath("~/Images/Instrucciones/");
            if (System.IO.File.Exists(Path.Combine(path, file)))
            {
                return File(Path.Combine(path, file), "image/jpeg");
            }
            return new HttpNotFoundResult();
        }

        // GET: Instruccion/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Instruccion/Create
        public ActionResult Create()
        {
            ViewBag.Recetas = recetaBusiness.GetAllRecetaItem();
            return View();
        }

        // POST: Instruccion/Create
        [HttpPost]
        public ActionResult Create(Instruccion instruccion,HttpPostedFileBase file)
        {
            try
            {
                string ruta = Server.MapPath("~/Images/Instrucciones/");

                if (instruccionBusiness.Create(instruccion, file, ruta))
                {
                    return RedirectToAction("Index");
                }
            }
            catch
            {
                
            }
            return View();
        }

        // GET: Instruccion/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Instruccion/Edit/5
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

        // GET: Instruccion/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Instruccion/Delete/5
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
