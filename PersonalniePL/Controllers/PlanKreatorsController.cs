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
    public class PlanKreatorsController : Controller
    {
        private PersonalnyContext db = new PersonalnyContext();

        // GET: PlanKreators
        [Authorize]
        public ActionResult Index(string UserName)
        {
            var planKreators = db.PlanKreators.Include(p => p.Podopieczny).Include(p => p.RodzajPlanus).Include(p => p.Trener).Where(t => t.Trener.UserName == UserName || t.Podopieczny.UserName == UserName);
            return View(planKreators.ToList());
        }

        // GET: PlanKreators/Details/5
        [Authorize]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PlanKreator planKreator = db.PlanKreators.Find(id);
            if (planKreator == null)
            {
                return HttpNotFound();
            }
            return View(planKreator);
        }

        // GET: PlanKreators/Create
        [Authorize(Roles = "Trener")]
        public ActionResult Create(string UserName)
        {
            ViewBag.PodopiecznyID = new SelectList(db.Podopiecznies, "ID", "Nazwisko");
            ViewBag.RodzajPlanuID = new SelectList(db.RodzajPlanus, "Id", "Nazwa");
            ViewBag.TrenerID = new SelectList(db.Treners.Where(t=>t.UserName==User.Identity.Name), "ID", "Nazwisko");
            ViewBag.CwiczenieID = new SelectList(db.Cwiczenies, "Id", "NazwaCwiczenia");
            return View();
        }

        // POST: PlanKreators/Create
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,TrenerID,PodopiecznyID,RodzajPlanuID,CwiczenieID,Cwiczenie1ID,Cwiczenie2ID,Cwiczenie3ID,Cwiczenie4ID,Cwiczenie5ID,Zablokowany,Cena")] PlanKreator planKreator)
        {
            if (ModelState.IsValid)
            {
                Trener tr = db.Treners.Single(t => t.UserName == User.Identity.Name);
                planKreator.TrenerID = (int)tr.ID;
                db.PlanKreators.Add(planKreator);
        
                db.SaveChanges();
                return RedirectToAction("Index", "PlanKreators", new { UserName = User.Identity.Name });

            }

            return View(planKreator);
        }

        // GET: PlanKreators/Edit/5
        [Authorize(Roles = "Trener")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PlanKreator planKreator = db.PlanKreators.Find(id);
            if (planKreator == null)
            {
                return HttpNotFound();
            }
            ViewBag.PodopiecznyID = new SelectList(db.Podopiecznies, "ID", "Nazwisko");
            ViewBag.RodzajPlanuID = new SelectList(db.RodzajPlanus, "Id", "Nazwa");
            ViewBag.CwiczenieID = new SelectList(db.Cwiczenies, "Id", "NazwaCwiczenia");
            ViewBag.TrenerID = new SelectList(db.Treners, "ID", "Nazwisko");
            return View(planKreator);
        }

        // POST: PlanKreators/Edit/5
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,TrenerID,PodopiecznyID,RodzajPlanuID,CwiczenieID,Cwiczenie1ID,Cwiczenie2ID,Cwiczenie3ID,Cwiczenie4ID,Cwiczenie5ID,Zablokowany,Cena")] PlanKreator planKreator)
        {
            if (ModelState.IsValid)
            {
                db.Entry(planKreator).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", "PlanKreators", new { UserName = User.Identity.Name });
            }
            ViewBag.PodopiecznyID = new SelectList(db.Podopiecznies, "ID", "Nazwisko");
            ViewBag.RodzajPlanuID = new SelectList(db.RodzajPlanus, "Id", "Nazwa");
            ViewBag.CwiczenieID = new SelectList(db.Cwiczenies, "Id", "NazwaCwiczenia");
            ViewBag.TrenerID = new SelectList(db.Treners, "ID", "Nazwisko");
            return View(planKreator);
        }
        [Authorize(Roles = "Trener")]
        // GET: PlanKreators/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PlanKreator planKreator = db.PlanKreators.Find(id);
            if (planKreator == null)
            {
                return HttpNotFound();
            }
            return View(planKreator);
        }

        // POST: PlanKreators/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PlanKreator planKreator = db.PlanKreators.Find(id);
            db.PlanKreators.Remove(planKreator);
            db.SaveChanges();
            return RedirectToAction("Index", "PlanKreators", new { UserName = User.Identity.Name });

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
