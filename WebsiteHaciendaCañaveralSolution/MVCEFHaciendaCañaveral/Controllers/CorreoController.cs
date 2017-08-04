using MVCEFHaciendaCañaveral.Business;
using MVCEFHaciendaCañaveral.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCEFHaciendaCañaveral.Controllers
{
    public class CorreoController : Controller
    {
        private CorreoBusiness correoBusiness;
        private DatosOrganizacionalesBusiness datosOrganizacionalesBusiness;

        public CorreoController()
        {
            this.correoBusiness = new CorreoBusiness();
            this.datosOrganizacionalesBusiness = new DatosOrganizacionalesBusiness();
        }
        // GET: Correo
        public ActionResult Index()
        {
            var model = correoBusiness.GetAllCorreo();
            return View(model);
        }

        // GET: Correo/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Correo/Create
        public ActionResult Create()
        {
            ViewBag.Datos = datosOrganizacionalesBusiness.GetAllDatosItem();
            return View();
        }

        // POST: Correo/Create
        [HttpPost]
        public ActionResult Create(Correo correo)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    correoBusiness.Crear(correo);
                    return RedirectToAction("Index");
                }   
            }
            catch
            {
            }
            return View();
        }

        // GET: Correo/Edit/5
        public ActionResult Edit(int id)
        {
            Correo correo = correoBusiness.GetCorreoById(id);
            if (correo == null)
            {
                return HttpNotFound();
            }
            
            ViewBag.Datos = datosOrganizacionalesBusiness.GetAllDatosItem();
            return View(correo);
        }

        // POST: Correo/Edit/5
        [HttpPost]
        public ActionResult Edit(Correo correo)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    correoBusiness.Editar(correo);
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {

            }
            return View(correo);
        }

        // GET: Correo/Delete/5
        public ActionResult Delete(int id)
        {
            Correo correo = correoBusiness.GetCorreoById(id);
            if (correo == null)
            {
                HttpNotFound();
            }
            return View(correo);
        }

        // POST: Correo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                correoBusiness.Eliminar(id);
                return RedirectToAction("Index");
            }
            catch
            {
            }
            return View();
        }
    }
}
