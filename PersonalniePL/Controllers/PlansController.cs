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
    public class PlansController : Controller
    {
        private PersonalnyContext db = new PersonalnyContext();

        // GET: Plans
        [Authorize]
        public ActionResult Index()
        {
            var plans = db.Plans.Include(p => p.Podopieczny).Include(p => p.RodzajPlanu).Include(p => p.Trener).Where(t => t.Trener.UserName == User.Identity.Name || t.Podopieczny.UserName == User.Identity.Name);
            
            return View(plans.ToList());
        }
        [Authorize]
        // GET: Plans/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Plan plan = db.Plans.Find(id);
            if (plan == null)
            {
                return HttpNotFound();
            }
            return View(plan);
        }
        [Authorize]
        public ActionResult Odblok(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Plan plan = db.Plans.Find(id);
            if (plan == null)
            {
                return HttpNotFound();
            }
            return View(plan);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Odblok([Bind(Include = "Id,TrenerID,PodopiecznyID,RodzajPlanuID,Cena,Plik,Zablokowany")] Plan plan)
        {
            if (ModelState.IsValid)
            {
                db.Entry(plan).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(plan);
        }
        // GET: Plans/Create
        [Authorize]
        public ActionResult Create(int id)
        {
            ViewBag.RodzajPlanuID = new SelectList(db.RodzajPlanus, "ID", "Nazwa");
            ViewBag.PodopiecznyID = new SelectList(db.Podopiecznies.Where(t => t.ID == id), "ID", "Nazwisko");
            ViewBag.TrenerID = new SelectList(db.Treners.Where(n => n.UserName == User.Identity.Name), "ID", "Nazwisko");
            return View();
        }

        // POST: Plans/Create
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,TrenerID,PodopiecznyID,RodzajPlanuID,Cena,Plik")] Plan plan)
        {
            HttpPostedFileBase plik = Request.Files["pplan"];
            if (plik != null && plik.ContentLength > 0)
            {
                plan.Plik = plik.FileName;
                Trener tr = db.Treners.Single(t => t.UserName == User.Identity.Name);
                plan.TrenerID = tr.ID;
                plan.Zablokowany = true;
                plik.SaveAs(HttpContext.Server.MapPath("~/Plany/"+plan.PodopiecznyID+"/")+ plan.Plik);
            }
            if (ModelState.IsValid)
            {
                db.Plans.Add(plan);
                db.SaveChanges();
                return RedirectToAction("Index","Plans");
            }

    return View(plan);
        }

        // GET: Plans/Edit/5
        [Authorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Plan plan = db.Plans.Find(id);
            if (plan == null)
            {
                return HttpNotFound();
            }
            ViewBag.PodopiecznyID = new SelectList(db.Podopiecznies, "ID", "Nazwisko", plan.PodopiecznyID);
            ViewBag.RodzajPlanuID = new SelectList(db.RodzajPlanus, "Id", "Nazwa", plan.RodzajPlanuID);
            ViewBag.TrenerID = new SelectList(db.Treners, "ID", "Nazwisko", plan.TrenerID);
            return View(plan);
        }

        // POST: Plans/Edit/5
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,TrenerID,PodopiecznyID,RodzajPlanuID,Cena,Plik")] Plan plan)
        {
            HttpPostedFileBase plik = Request.Files["plikzplanem"];
            if (plik != null && plik.ContentLength > 0)
            {
                plan.Plik = plik.FileName;
                Trener tr = db.Treners.Single(t => t.UserName == User.Identity.Name);
                plan.TrenerID = tr.ID;
                plik.SaveAs(HttpContext.Server.MapPath("~/Plany/") + plan.Podopieczny.UserName +"/"+ plan.Plik);
            }
            if (ModelState.IsValid)
            {
                db.Entry(plan).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(plan);
        }

        [Authorize]
        // GET: Plans/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Plan plan = db.Plans.Find(id);
            if (plan == null)
            {
                return HttpNotFound();
            }
            return View(plan);
        }

        // POST: Plans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Plan plan = db.Plans.Find(id);
            db.Plans.Remove(plan);
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
