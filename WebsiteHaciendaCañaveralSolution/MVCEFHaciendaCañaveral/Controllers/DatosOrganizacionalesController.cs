using MVCEFHaciendaCañaveral.Business;
using MVCEFHaciendaCañaveral.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace MVCEFHaciendaCañaveral.Controllers
{
    public class DatosOrganizacionalesController : Controller
    {
        private DatosOrganizacionalesBusiness _datosOrganizacionalesBusiness;
        private HaciendaCañaveralContext db;

        public DatosOrganizacionalesController()
        {
            _datosOrganizacionalesBusiness = new DatosOrganizacionalesBusiness();
            db = new HaciendaCañaveralContext();
        }
        // GET: DatosOrganizacionales
        public ActionResult Index()
        {
            var model = _datosOrganizacionalesBusiness.getAllDataOrganizacional();
            return View(model);
        }

        // GET: DatosOrganizacionales/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: DatosOrganizacionales/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DatosOrganizacionales/Create
        [HttpPost]
        public ActionResult Create(DatosOrganizacionales datos)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _datosOrganizacionalesBusiness.Crear(datos);
                    return RedirectToAction("Index");
                }   
            }
            catch
            {
                
            }
            return View();
        }

        // GET: DatosOrganizacionales/Edit/5
        public ActionResult Edit(int id)
        {
            DatosOrganizacionales datos= _datosOrganizacionalesBusiness.GetDatoById(id);
            if (datos == null)
            {
                return HttpNotFound();
            }
            return View(datos);
        }

        // POST: DatosOrganizacionales/Edit/5
        [HttpPost]
        public ActionResult Edit(DatosOrganizacionales datos)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _datosOrganizacionalesBusiness.Editar(datos);
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {

            }
            return View(datos);
        }

        // GET: DatosOrganizacionales/Delete/5
        public ActionResult Delete(int id)
        {
            
            DatosOrganizacionales datos = db.DatosOrganizacionales.Find(id);
            if (datos == null)
            {
                return HttpNotFound();
            }
            return View(datos);
        }

        // POST: DatosOrganizacionales/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DatosOrganizacionales datos = db.DatosOrganizacionales.Find(id);
            db.DatosOrganizacionales.Remove(datos);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
