using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Core.Metadata.Edm;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PersonalniePL.Data;
using PersonalniePL.Models;

namespace PersonalniePL.Controllers
{
    public class WiadomoscsController : Controller
    {
        private PersonalnyContext db = new PersonalnyContext();

        // GET: Wiadomoscs
        public ActionResult Index(string UserName)
        {

            var wiadomoscs = db.Wiadomoscs.Include(w => w.Treners).Where(t => t.Treners.UserName == UserName || t.Podopiecznies.UserName == UserName);
            return View(wiadomoscs.ToList());
        }

        // GET: Wiadomoscs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Wiadomosc wiadomosc = db.Wiadomoscs.Find(id);
            if (wiadomosc == null)
            {
                return HttpNotFound();
            }
            return View(wiadomosc);
        }

        // GET: Wiadomoscs/Create
        public ActionResult Create(int? id)
        {
            if (User.IsInRole("Podopieczny"))
            {
                ViewBag.PodopiecznyId = new SelectList(db.Podopiecznies.Where(n => n.UserName == User.Identity.Name), "ID", "Nazwisko");
                ViewBag.TrenerId = new SelectList(db.Treners.Where(t => t.ID == id), "ID", "Nazwisko");
            }
            if (User.IsInRole("Trener"))
            {
                ViewBag.PodopiecznyId = new SelectList(db.Podopiecznies.Where(t => t.ID == id), "ID", "Nazwisko");
                ViewBag.TrenerId = new SelectList(db.Treners.Where(n => n.UserName == User.Identity.Name), "ID", "Nazwisko");
            }
            return View();
        }

        // POST: Wiadomoscs/Create
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,TrenerId,PodopiecznyId,Tresc")] Wiadomosc wiadomosc)
        {
            if (ModelState.IsValid)
            {
                wiadomosc.Autor = User.Identity.Name;
                db.Wiadomoscs.Add(wiadomosc);
                db.SaveChanges();
                return RedirectToAction("Index","Wiadomoscs",new { UserName=User.Identity.Name});
            }

            ViewBag.PodopiecznyId = new SelectList(db.Podopiecznies, "ID", "Nazwisko", wiadomosc.PodopiecznyID);
            ViewBag.TrenerId = new SelectList(db.Treners, "ID", "Nazwisko", wiadomosc.TrenerID);
            return RedirectToRoute("Index", "Treners");
        }

        // GET: Wiadomoscs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Wiadomosc wiadomosc = db.Wiadomoscs.Find(id);
            if (wiadomosc == null)
            {
                return HttpNotFound();
            }
            ViewBag.PodopiecznyId = new SelectList(db.Podopiecznies, "ID", "Nazwisko", wiadomosc.PodopiecznyID);
            ViewBag.TrenerId = new SelectList(db.Treners, "ID", "Nazwisko", wiadomosc.TrenerID);
            return View(wiadomosc);
        }

        // POST: Wiadomoscs/Edit/5
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,TrenerId,PodopiecznyId,Tresc")] Wiadomosc wiadomosc)
        {
            if (ModelState.IsValid)
            {
                db.Entry(wiadomosc).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PodopiecznyId = new SelectList(db.Podopiecznies, "ID", "Nazwisko", wiadomosc.PodopiecznyID);
            ViewBag.TrenerId = new SelectList(db.Treners, "ID", "Nazwisko", wiadomosc.TrenerID);
            return View(wiadomosc);
        }

        // GET: Wiadomoscs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Wiadomosc wiadomosc = db.Wiadomoscs.Find(id);
            if (wiadomosc == null)
            {
                return HttpNotFound();
            }
            return View(wiadomosc);
        }

        // POST: Wiadomoscs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Wiadomosc wiadomosc = db.Wiadomoscs.Find(id);
            db.Wiadomoscs.Remove(wiadomosc);
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
