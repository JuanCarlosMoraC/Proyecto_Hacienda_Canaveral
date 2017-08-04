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

        private DatosOrganizacionalesBusiness datosOrganizacionalesBusiness;
        private TelefonoBusiness telefonoBusiness;

        public TelefonoController()
        {
            datosOrganizacionalesBusiness = new DatosOrganizacionalesBusiness();
            telefonoBusiness = new TelefonoBusiness();
        }

        // GET: Telefono
        public ActionResult Index()
        {
            var model = telefonoBusiness.getAllPhones();
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
            ViewBag.Datos = datosOrganizacionalesBusiness.GetAllDatosItem();
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
                    telefonoBusiness.Crear(telefono);
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
            Telefono telefono = telefonoBusiness.getPhoneById(id);
            if(telefono== null)
            {
                HttpNotFound();
            }
            ViewBag.Datos = datosOrganizacionalesBusiness.GetAllDatosItem();
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
                    telefonoBusiness.Editar(telefono);
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
            Telefono telefono = telefonoBusiness.getPhoneById(id);
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
            try
            {
                telefonoBusiness.Eliminar(id);
                return RedirectToAction("Index");
            }
            catch
            {
            }
            return View();
        }
    }
}
