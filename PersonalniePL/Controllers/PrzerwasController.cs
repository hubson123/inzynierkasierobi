using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PersonalniePL.Data;
using PersonalniePL.Models;

namespace PersonalniePL.Controllers
{
    public class PrzerwasController : Controller
    {
        private PersonalnyContext db = new PersonalnyContext();

        // GET: Przerwas
        public ActionResult Index()
        {
            return View(db.Przerwas.ToList());
        }

        // GET: Przerwas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Przerwa przerwa = db.Przerwas.Find(id);
            if (przerwa == null)
            {
                return HttpNotFound();
            }
            return View(przerwa);
        }

        // GET: Przerwas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Przerwas/Create
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,CzasPrzerwy")] Przerwa przerwa)
        {
            if (ModelState.IsValid)
            {
                db.Przerwas.Add(przerwa);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(przerwa);
        }

        // GET: Przerwas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Przerwa przerwa = db.Przerwas.Find(id);
            if (przerwa == null)
            {
                return HttpNotFound();
            }
            return View(przerwa);
        }

        // POST: Przerwas/Edit/5
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,CzasPrzerwy")] Przerwa przerwa)
        {
            if (ModelState.IsValid)
            {
                db.Entry(przerwa).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(przerwa);
        }

        // GET: Przerwas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Przerwa przerwa = db.Przerwas.Find(id);
            if (przerwa == null)
            {
                return HttpNotFound();
            }
            return View(przerwa);
        }

        // POST: Przerwas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Przerwa przerwa = db.Przerwas.Find(id);
            db.Przerwas.Remove(przerwa);
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
