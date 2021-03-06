﻿using MVCEFHaciendaCañaveral.Business;
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
        private RoleBusiness _roleBusiness;
        private UsuarioBusiness _usuarioBusiness;
        private HaciendaCañaveralContext db;

        public UsuarioController()
        {
            this._roleBusiness= new RoleBusiness();
            this._usuarioBusiness = new UsuarioBusiness();
            this.db = new HaciendaCañaveralContext();
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
            ViewBag.Roles = _roleBusiness.GetAllRolesItem();
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
            catch
            {
            }
            return View();
        }

        // GET: Usuario/Edit/5
        public ActionResult Edit(int id)
        {
            Usuario usuario = _usuarioBusiness.UserByID(id);
            if (usuario == null)
            {
                HttpNotFound();
            }

            ViewBag.Roles = _roleBusiness.GetAllRolesItem();
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
            catch
            {
            }
            return View();
        }

        // GET: Usuario/Delete/5
        public ActionResult Delete(int id)
        {
            Usuario usuario = _usuarioBusiness.UserByID(id);
            if(usuario == null)
            {
                HttpNotFound();
            }
            return View(usuario);
        }

        // POST: Usuario/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                _usuarioBusiness.Eliminar(id);
                return RedirectToAction("Index");
            }
            catch
            {
            }
            return View();

        }
    }
}
