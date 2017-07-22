using MVCEFHaciendaCañaveral.Business;
using MVCEFHaciendaCañaveral.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCEFHaciendaCañaveral.Controllers
{
    public class UsuarioController : Controller
    {
        private UsuarioBusiness _usuarioBusiness;
        private RoleBusiness _roleBusiness;

        public UsuarioController()
        {
            _usuarioBusiness = new UsuarioBusiness();
            _roleBusiness = new RoleBusiness();
        }
        // GET: Usuario
        public ActionResult Index()
        {
            var model = _usuarioBusiness.GetAllUsers();
            return View(model);
        }

        // GET: Usuario/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Usuario/Create
        public ActionResult Create()
        {
            var roles = _roleBusiness.GetAllRoles();
            ViewBag.ListaRoles = new SelectList(roles, "IdRole", "Descripcion");
            return View();
        }

        // POST: Usuario/Create
        [HttpPost]
        public ActionResult Create(Usuario usuario)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _usuarioBusiness.Crear(usuario);
                    return RedirectToAction("Index");
                }
            }
            catch(Exception ex)
            {
                
            }
            return View();
        }

        // GET: Usuario/Edit/5
        public ActionResult Edit(int id)
        {
            Usuario usuario = _usuarioBusiness.UserByID(id);
            if(usuario == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
        }

        // POST: Usuario/Edit/5
        [HttpPost]
        public ActionResult Edit(Usuario usuario)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _usuarioBusiness.Editar(usuario);
                    return RedirectToAction("Index");
                }
            }
            catch(Exception ex)
            {
                
            }
            return View(usuario);
        }

        // GET: Usuario/Delete/5
        public ActionResult Delete(int id)
        {
            Usuario usuario = _usuarioBusiness.UserByID(id);
            if(usuario == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
        }

        // POST: Usuario/Delete/5
        [HttpPost]
        public ActionResult Delete(Usuario usuario)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _usuarioBusiness.Eliminar(usuario);
                    return RedirectToAction("Index");
                }
            }
            catch(Exception ex)
            {
            }
            return View(usuario);
        }
    }
}
