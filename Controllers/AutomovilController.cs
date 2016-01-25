using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoLote.Models;

namespace AutoLote.Controllers
{
    public class AutomovilController : Controller
    {
        private DBContext db = new DBContext();

        //
        // GET: /Automovil/

        public ActionResult Index()
        {
            var automovils = db.Automovils.Include(a => a.Tipo);
            return View(automovils.ToList());
        }

        //
        // GET: /Automovil/Details/5

        public ActionResult Details(int id = 0)
        {
            Automovil automovil = db.Automovils.Find(id);
            if (automovil == null)
            {
                return HttpNotFound();
            }
            return View(automovil);
        }

        //
        // GET: /Automovil/Create

        public ActionResult Create()
        {
            ViewBag.TipoId = new SelectList(db.Tipos, "TipoId", "Descripcion");
            return View();
        }

        //
        // POST: /Automovil/Create

        [HttpPost]
        public ActionResult Create(Automovil automovil)
        {
            if (ModelState.IsValid)
            {
                db.Automovils.Add(automovil);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.TipoId = new SelectList(db.Tipos, "TipoId", "Descripcion", automovil.TipoId);
            return View(automovil);
        }

        //
        // GET: /Automovil/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Automovil automovil = db.Automovils.Find(id);
            if (automovil == null)
            {
                return HttpNotFound();
            }
            ViewBag.TipoId = new SelectList(db.Tipos, "TipoId", "Descripcion", automovil.TipoId);
            return View(automovil);
        }

        //
        // POST: /Automovil/Edit/5

        [HttpPost]
        public ActionResult Edit(Automovil automovil)
        {
            if (ModelState.IsValid)
            {
                db.Entry(automovil).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TipoId = new SelectList(db.Tipos, "TipoId", "Descripcion", automovil.TipoId);
            return View(automovil);
        }

        //
        // GET: /Automovil/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Automovil automovil = db.Automovils.Find(id);
            if (automovil == null)
            {
                return HttpNotFound();
            }
            return View(automovil);
        }

        //
        // POST: /Automovil/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Automovil automovil = db.Automovils.Find(id);
            db.Automovils.Remove(automovil);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}