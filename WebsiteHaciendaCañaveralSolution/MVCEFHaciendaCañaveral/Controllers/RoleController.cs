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
    public class RoleController : Controller
    {
        private RoleBusiness _roleBusiness;
        private HaciendaCañaveralContext db;

        public RoleController()
        {
            _roleBusiness = new RoleBusiness();
            db = new HaciendaCañaveralContext();
        }

        // GET: Role
        public ActionResult Index()
        {
            var model = _roleBusiness.GetAllRoles();
            return View(model);
        }

        // GET: Role/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Role/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Role/Create
        [HttpPost]
        public ActionResult Create(Role role)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _roleBusiness.Crear(role);
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {

            }
            return View();
        }

        // GET: Role/Edit/5
        public ActionResult Edit(int id)
        {
            Role rol = _roleBusiness.GetRoleById(id);
            if (rol == null)
            {
                return HttpNotFound();
            }
            return View(rol);
        }

        // POST: Role/Edit/5
        [HttpPost]
        public ActionResult Edit(Role role)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _roleBusiness.Editar(role);
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {

            }
            return View(role);
        }

        // GET: Roles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Role role = db.Role.Find(id);
            if (role == null)
            {
                return HttpNotFound();
            }
            return View(role);
        }

        // POST: Roles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Role role = db.Role.Find(id);
            db.Role.Remove(role);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
