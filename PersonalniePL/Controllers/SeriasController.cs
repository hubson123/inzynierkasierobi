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
    public class SeriasController : Controller
    {
        private PersonalnyContext db = new PersonalnyContext();

        // GET: Serias
        public ActionResult Index()
        {
            return View(db.Serias.ToList());
        }

        // GET: Serias/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Seria seria = db.Serias.Find(id);
            if (seria == null)
            {
                return HttpNotFound();
            }
            return View(seria);
        }

        // GET: Serias/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Serias/Create
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,IloscSerii")] Seria seria)
        {
            if (ModelState.IsValid)
            {
                db.Serias.Add(seria);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(seria);
        }

        // GET: Serias/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Seria seria = db.Serias.Find(id);
            if (seria == null)
            {
                return HttpNotFound();
            }
            return View(seria);
        }

        // POST: Serias/Edit/5
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,IloscSerii")] Seria seria)
        {
            if (ModelState.IsValid)
            {
                db.Entry(seria).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(seria);
        }

        // GET: Serias/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Seria seria = db.Serias.Find(id);
            if (seria == null)
            {
                return HttpNotFound();
            }
            return View(seria);
        }

        // POST: Serias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Seria seria = db.Serias.Find(id);
            db.Serias.Remove(seria);
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
