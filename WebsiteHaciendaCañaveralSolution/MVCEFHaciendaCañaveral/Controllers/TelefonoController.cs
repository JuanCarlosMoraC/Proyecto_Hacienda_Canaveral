using MVCEFHaciendaCañaveral.Business;
using MVCEFHaciendaCañaveral.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCEFHaciendaCañaveral.Controllers
{
    public class TelefonoController : Controller
    {
        private HaciendaCañaveralContext db;
        private DatosOrganizacionalesBusiness _datosOrganizacionalesBusiness;
        private TelefonoBusiness _telefonoBusiness;

        public TelefonoController()
        {
            db = new HaciendaCañaveralContext();
            _datosOrganizacionalesBusiness = new DatosOrganizacionalesBusiness();
            _telefonoBusiness = new TelefonoBusiness();
        }

        // GET: Telefono
        public ActionResult Index()
        {
            var model = _telefonoBusiness.getAllPhones();
            return View(model);
        }

        // GET: Telefono/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Telefono/Create
        public ActionResult Create()
        {
            ViewBag.Datos = _datosOrganizacionalesBusiness.GetAllDatosItem();
            return View();
        }

        // POST: Telefono/Create
        [HttpPost]
        public ActionResult Create(Telefono telefono)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _telefonoBusiness.Crear(telefono);
                    return RedirectToAction("Index");
                }
            }
            catch
            {
                
            }
            return View();
        }

        // GET: Telefono/Edit/5
        public ActionResult Edit(int id)
        {
            Telefono telefono = _telefonoBusiness.getPhoneById(id);
            if(telefono== null)
            {
                HttpNotFound();
            }
            ViewBag.Datos = _datosOrganizacionalesBusiness.GetAllDatosItem();
            return View(telefono);
        }

        // POST: Telefono/Edit/5
        [HttpPost]
        public ActionResult Edit(Telefono telefono)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _telefonoBusiness.Editar(telefono);
                    return RedirectToAction("Index");
                }
            }
            catch
            {
            }
            return View();
        }

        // GET: Telefono/Delete/5
        public ActionResult Delete(int id)
        {
            Telefono telefono = db.Telefono.Find(id);
            if(telefono == null)
            {
                HttpNotFound();
            }
            return View(telefono);
        }

        // POST: Telefono/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Telefono telefono = db.Telefono.Find(id);
            db.Telefono.Remove(telefono);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
