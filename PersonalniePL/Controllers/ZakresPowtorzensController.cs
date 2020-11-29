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
    public class ZakresPowtorzensController : Controller
    {
        private PersonalnyContext db = new PersonalnyContext();

        // GET: ZakresPowtorzens
        public ActionResult Index()
        {
            return View(db.ZakresPowtorzens.ToList());
        }

        // GET: ZakresPowtorzens/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ZakresPowtorzen zakresPowtorzen = db.ZakresPowtorzens.Find(id);
            if (zakresPowtorzen == null)
            {
                return HttpNotFound();
            }
            return View(zakresPowtorzen);
        }

        // GET: ZakresPowtorzens/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ZakresPowtorzens/Create
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,IloscPowtorzen")] ZakresPowtorzen zakresPowtorzen)
        {
            if (ModelState.IsValid)
            {
                db.ZakresPowtorzens.Add(zakresPowtorzen);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(zakresPowtorzen);
        }

        // GET: ZakresPowtorzens/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ZakresPowtorzen zakresPowtorzen = db.ZakresPowtorzens.Find(id);
            if (zakresPowtorzen == null)
            {
                return HttpNotFound();
            }
            return View(zakresPowtorzen);
        }

        // POST: ZakresPowtorzens/Edit/5
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,IloscPowtorzen")] ZakresPowtorzen zakresPowtorzen)
        {
            if (ModelState.IsValid)
            {
                db.Entry(zakresPowtorzen).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(zakresPowtorzen);
        }

        // GET: ZakresPowtorzens/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ZakresPowtorzen zakresPowtorzen = db.ZakresPowtorzens.Find(id);
            if (zakresPowtorzen == null)
            {
                return HttpNotFound();
            }
            return View(zakresPowtorzen);
        }

        // POST: ZakresPowtorzens/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ZakresPowtorzen zakresPowtorzen = db.ZakresPowtorzens.Find(id);
            db.ZakresPowtorzens.Remove(zakresPowtorzen);
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
