using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Teste2DAW.Models;

namespace Teste2DAW.Controllers
{
    public class CopiasController : Controller
    {
        private ProjectoDB db = new ProjectoDB();

        // GET: Copias
        public ActionResult Index()
        {
            var copias = db.copias.Include(c => c.Estado).Include(c => c.Filme);
            return View(copias.ToList());
        }

        // GET: Copias/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Copia copia = db.copias.Find(id);
            if (copia == null)
            {
                return HttpNotFound();
            }
            return View(copia);
        }

        // GET: Copias/Create
        public ActionResult Create()
        {
            ViewBag.EstadoID = new SelectList(db.Estados, "EstadoID", "Designacao");
            ViewBag.FilmeID = new SelectList(db.filmes, "FilmeID", "Titulo");
            return View();
        }

        // POST: Copias/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CopiaID,FilmeID,EstadoID,disponivel")] Copia copia)
        {
            if (ModelState.IsValid)
            {
                db.copias.Add(copia);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EstadoID = new SelectList(db.Estados, "EstadoID", "Designacao", copia.EstadoID);
            ViewBag.FilmeID = new SelectList(db.filmes, "FilmeID", "Titulo", copia.FilmeID);
            return View(copia);
        }

        // GET: Copias/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Copia copia = db.copias.Find(id);
            if (copia == null)
            {
                return HttpNotFound();
            }
            ViewBag.EstadoID = new SelectList(db.Estados, "EstadoID", "Designacao", copia.EstadoID);
            ViewBag.FilmeID = new SelectList(db.filmes, "FilmeID", "Titulo", copia.FilmeID);
            return View(copia);
        }

        // POST: Copias/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CopiaID,FilmeID,EstadoID,disponivel")] Copia copia)
        {
            if (ModelState.IsValid)
            {
                db.Entry(copia).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EstadoID = new SelectList(db.Estados, "EstadoID", "Designacao", copia.EstadoID);
            ViewBag.FilmeID = new SelectList(db.filmes, "FilmeID", "Titulo", copia.FilmeID);
            return View(copia);
        }

        // GET: Copias/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Copia copia = db.copias.Find(id);
            if (copia == null)
            {
                return HttpNotFound();
            }
            return View(copia);
        }

        // POST: Copias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Copia copia = db.copias.Find(id);
            db.copias.Remove(copia);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
