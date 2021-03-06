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
    public class CwiczeniesController : Controller
    {
        private PersonalnyContext db = new PersonalnyContext();

        // GET: Cwiczenies
        [Authorize]
        public ActionResult Index()
        {
            var ddd = db.Cwiczenies.Where(t => t.Id > 1);
           return View(ddd.ToList());
        }

        // GET: Cwiczenies/Details/5
        [Authorize]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cwiczenie cwiczenie = db.Cwiczenies.Find(id);
            if (cwiczenie == null)
            {
                return HttpNotFound();
            }
            return View(cwiczenie);
        }

        // GET: Cwiczenies/Create
        [Authorize(Roles = "Trener")]
        public ActionResult Create()
        {
          return View();
        }

        // POST: Cwiczenies/Create
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,NazwaCwiczenia,IloscSerii,ZakresPowtorzen,CzasPrzerwy,SkalaRpes,TempoPracy")] Cwiczenie cwiczenie)
        {
            if (ModelState.IsValid)
            {
                db.Cwiczenies.Add(cwiczenie);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

      return View(cwiczenie);
        }

        // GET: Cwiczenies/Edit/5
        [Authorize(Roles = "Trener")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cwiczenie cwiczenie = db.Cwiczenies.Find(id);
            if (cwiczenie == null)
            {
                return HttpNotFound();
            }
      return View(cwiczenie);
        }

        // POST: Cwiczenies/Edit/5
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,NazwaCwiczenia,IloscSerii,ZakresPowtorzen,CzasPrzerwy,SkalaRpes,TempoPracy")] Cwiczenie cwiczenie)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cwiczenie).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
      return View(cwiczenie);
        }

        // GET: Cwiczenies/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cwiczenie cwiczenie = db.Cwiczenies.Find(id);
            if (cwiczenie == null)
            {
                return HttpNotFound();
            }
            return View(cwiczenie);
        }

        // POST: Cwiczenies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cwiczenie cwiczenie = db.Cwiczenies.Find(id);
            db.Cwiczenies.Remove(cwiczenie);
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
