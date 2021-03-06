﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoLote.Models;

namespace AutoLote.Controllers
{
    public class ModelosController : Controller
    {
        private DBContext db = new DBContext();

        //
        // GET: /Modelos/

        public ActionResult Index()
        {
            var modelos = db.Modelos.Include(m => m.Marcas);
            return View(modelos.ToList());
        }

        //
        // GET: /Modelos/Details/5

        public ActionResult Details(int id = 0)
        {
            Modelos modelos = db.Modelos.Find(id);
            if (modelos == null)
            {
                return HttpNotFound();
            }
            return View(modelos);
        }

        //
        // GET: /Modelos/Create

        public ActionResult Create()
        {
            ViewBag.MarcaId = new SelectList(db.Marcas, "MarcaId", "Descripcion");
            return View();
        }

        //
        // POST: /Modelos/Create

        [HttpPost]
        public ActionResult Create(Modelos modelos)
        {
            if (ModelState.IsValid)
            {
                db.Modelos.Add(modelos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MarcaId = new SelectList(db.Marcas, "MarcaId", "Descripcion", modelos.MarcaId);
            return View(modelos);
        }

        //
        // GET: /Modelos/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Modelos modelos = db.Modelos.Find(id);
            if (modelos == null)
            {
                return HttpNotFound();
            }
            ViewBag.MarcaId = new SelectList(db.Marcas, "MarcaId", "Descripcion", modelos.MarcaId);
            return View(modelos);
        }

        //
        // POST: /Modelos/Edit/5

        [HttpPost]
        public ActionResult Edit(Modelos modelos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(modelos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MarcaId = new SelectList(db.Marcas, "MarcaId", "Descripcion", modelos.MarcaId);
            return View(modelos);
        }

        //
        // GET: /Modelos/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Modelos modelos = db.Modelos.Find(id);
            if (modelos == null)
            {
                return HttpNotFound();
            }
            return View(modelos);
        }

        //
        // POST: /Modelos/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Modelos modelos = db.Modelos.Find(id);
            db.Modelos.Remove(modelos);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

        public ActionResult ListaModelosPorMarca(int id)
        {
            var modelos = db.Modelos.Where(r => r.MarcaId == id);

            if (modelos.Any()) { 
            
            var query = (from m in modelos
                             select new 
                             {
                                ID = m.MarcaId,
                                Modelo = m.Descripcion,
                                selected = false
                             });
            return Json(query, JsonRequestBehavior.AllowGet);
            
            }
            return RedirectToAction("Index");




        }



    }
}