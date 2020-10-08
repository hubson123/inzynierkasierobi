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
    public class NotkasController : Controller
    {
        private PersonalnyContext db = new PersonalnyContext();

        // GET: Notkas
        public ActionResult Index()
        {
            return View(db.Notkas.ToList());
        }

        // GET: Notkas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Notka notka = db.Notkas.Find(id);
            if (notka == null)
            {
                return HttpNotFound();
            }
            return View(notka);
        }

        // GET: Notkas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Notkas/Create
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,UserName,Tresc,datautworzenia")] Notka notka)
        {
            if (ModelState.IsValid)
            {
                db.Notkas.Add(notka);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(notka);
        }

        // GET: Notkas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Notka notka = db.Notkas.Find(id);
            if (notka == null)
            {
                return HttpNotFound();
            }
            return View(notka);
        }

        // POST: Notkas/Edit/5
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,UserName,Tresc,datautworzenia")] Notka notka)
        {
            if (ModelState.IsValid)
            {
                db.Entry(notka).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(notka);
        }

        // GET: Notkas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Notka notka = db.Notkas.Find(id);
            if (notka == null)
            {
                return HttpNotFound();
            }
            return View(notka);
        }

        // POST: Notkas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Notka notka = db.Notkas.Find(id);
            db.Notkas.Remove(notka);
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
