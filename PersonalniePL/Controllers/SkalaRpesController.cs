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
    public class SkalaRpesController : Controller
    {
        private PersonalnyContext db = new PersonalnyContext();

        // GET: SkalaRpes
        public ActionResult Index()
        {
            return View(db.SkalaRpes.ToList());
        }

        // GET: SkalaRpes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SkalaRpe skalaRpe = db.SkalaRpes.Find(id);
            if (skalaRpe == null)
            {
                return HttpNotFound();
            }
            return View(skalaRpe);
        }

        // GET: SkalaRpes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SkalaRpes/Create
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,SkalaRPE")] SkalaRpe skalaRpe)
        {
            if (ModelState.IsValid)
            {
                db.SkalaRpes.Add(skalaRpe);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(skalaRpe);
        }

        // GET: SkalaRpes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SkalaRpe skalaRpe = db.SkalaRpes.Find(id);
            if (skalaRpe == null)
            {
                return HttpNotFound();
            }
            return View(skalaRpe);
        }

        // POST: SkalaRpes/Edit/5
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,SkalaRPE")] SkalaRpe skalaRpe)
        {
            if (ModelState.IsValid)
            {
                db.Entry(skalaRpe).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(skalaRpe);
        }

        // GET: SkalaRpes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SkalaRpe skalaRpe = db.SkalaRpes.Find(id);
            if (skalaRpe == null)
            {
                return HttpNotFound();
            }
            return View(skalaRpe);
        }

        // POST: SkalaRpes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SkalaRpe skalaRpe = db.SkalaRpes.Find(id);
            db.SkalaRpes.Remove(skalaRpe);
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
