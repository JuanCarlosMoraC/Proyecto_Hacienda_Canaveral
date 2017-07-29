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
        private CorreoBusiness _correoBusiness;
        private HaciendaCañaveralContext db;
        private DatosOrganizacionalesBusiness _datosOrganizacionalesBusiness;

        public CorreoController()
        {
            _correoBusiness = new CorreoBusiness();
            db = new HaciendaCañaveralContext();
            _datosOrganizacionalesBusiness = new DatosOrganizacionalesBusiness();
        }
        // GET: Correo
        public ActionResult Index()
        {
            var model = _correoBusiness.GetAllCorreo();
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
            ViewBag.Datos = _datosOrganizacionalesBusiness.GetAllDatosItem();
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
                    _correoBusiness.Crear(correo);
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
            Correo correo = _correoBusiness.GetCorreoById(id);
            if (correo == null)
            {
                return HttpNotFound();
            }
            
            ViewBag.Datos = _datosOrganizacionalesBusiness.GetAllDatosItem();
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
                    _correoBusiness.Editar(correo);
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
            Correo correo = db.Correo.Find(id);
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
            Correo correo= db.Correo.Find(id);
            db.Correo.Remove(correo);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
