﻿using System;
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
    public class TempiController : Controller
    {
        private PersonalnyContext db = new PersonalnyContext();

        // GET: Tempi
        public ActionResult Index()
        {
            return View(db.Tempi.ToList());
        }

        // GET: Tempi/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tempo tempo = db.Tempi.Find(id);
            if (tempo == null)
            {
                return HttpNotFound();
            }
            return View(tempo);
        }

        // GET: Tempi/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Tempi/Create
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,TempoPracy")] Tempo tempo)
        {
            if (ModelState.IsValid)
            {
                db.Tempi.Add(tempo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tempo);
        }

        // GET: Tempi/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tempo tempo = db.Tempi.Find(id);
            if (tempo == null)
            {
                return HttpNotFound();
            }
            return View(tempo);
        }

        // POST: Tempi/Edit/5
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,TempoPracy")] Tempo tempo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tempo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tempo);
        }

        // GET: Tempi/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tempo tempo = db.Tempi.Find(id);
            if (tempo == null)
            {
                return HttpNotFound();
            }
            return View(tempo);
        }

        // POST: Tempi/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tempo tempo = db.Tempi.Find(id);
            db.Tempi.Remove(tempo);
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
