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
using PagedList;
using System.Web.UI.WebControls;
namespace PersonalniePL.Controllers
{
    public class PodopieczniesController : Controller
    {
        private PersonalnyContext db = new PersonalnyContext();

        // GET: Podopiecznies
        [Authorize]
        public ActionResult Index(string UserName,string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.ImieSortParm = String.IsNullOrEmpty(sortOrder) ? "Imie_desc" : "";
            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;
            var treners = db.Podopiecznies.Include(z=>z.Trener).Where(t => t.Trener.UserName == UserName).ToList();
            if (!String.IsNullOrEmpty(searchString))
            {
                treners = treners.Where(t => t.Nazwisko.Contains(searchString)).ToList();
            }
            switch (sortOrder)
            {
                case "Imie_desc":
                    treners = treners.OrderByDescending(t => t.Imie).ToList();
                    break;
                default:
                    treners = treners.OrderBy(t => t.Nazwisko).ToList();
                    break;
            }
            int pageSize = 2;
            int pageNumber = (page ?? 1);
            return View(treners.ToPagedList(pageNumber, pageSize));
        }

        // GET: Podopiecznies/Details/5
        [Authorize]
        public ActionResult Details(string UserName)
        {
            if (UserName == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Podopieczny podopieczny = db.Podopiecznies.Single(t => t.UserName == UserName);
            if (podopieczny == null)
            {
                return HttpNotFound();
            }
            return View(podopieczny);
        }
        [Authorize]
        // GET: Podopiecznies/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Podopiecznies/Create
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,UserName")] Podopieczny podopieczny)
        {
            if (ModelState.IsValid)
            {
                db.Podopiecznies.Add(podopieczny);
                db.SaveChanges();
                return RedirectToAction("Home", "Index");
            }

            return View(podopieczny);
        }

        // GET: Podopiecznies/Edit/5
        [Authorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Podopieczny podopieczny = db.Podopiecznies.Find(id);
            ViewBag.TrenerId = new SelectList(db.Treners.Where(t => t.ID == id), "ID", "Nazwisko");
            if (podopieczny == null)
            {
                return HttpNotFound();
            }
            return View(podopieczny);
        }
        // GET: Podopiecznies/Edit/5
        [Authorize]
        public ActionResult Dolacz(int? id,string st)
        {
            if (st == null || id==null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var podopieczny = db.Podopiecznies.Where(t=> t.UserName==st);
            ViewBag.TrenerId = new SelectList(db.Treners.Where(t => t.ID == id), "ID", "Nazwisko");
            if (podopieczny == null)
            {
                return HttpNotFound();
            }
            return View(podopieczny.ToList());
        }
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult Dolacz([Bind(Include = "ID,Avatar,UserName,Imie,Nazwisko,Wiek,idTrenera")] Podopieczny podopieczny)
        {
            if (ModelState.IsValid)
            {
                db.Entry(podopieczny).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index","Treners");
            }

                return View(podopieczny);
        }
        // POST: Podopiecznies/Edit/5
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Avatar,UserName,Imie,Nazwisko,Wiek,idTrenera")] Podopieczny podopieczny)
        {
            if (ModelState.IsValid)
            {
                HttpPostedFileBase plik = Request.Files["plikzobrazkiem"];
                if (plik != null && plik.ContentLength > 0)
                {
                    podopieczny.Avatar = plik.FileName;
                    plik.SaveAs(HttpContext.Server.MapPath("~/Avatary") + podopieczny.Avatar);
                }
                db.Entry(podopieczny).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Home");
            }
            return View(podopieczny);
        }

        // GET: Podopiecznies/Delete/5
        [Authorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Podopieczny podopieczny = db.Podopiecznies.Find(id);
            if (podopieczny == null)
            {
                return HttpNotFound();
            }
            return View(podopieczny);
        }

        // POST: Podopiecznies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult DeleteConfirmed(int id)
        {
            Podopieczny podopieczny = db.Podopiecznies.Find(id);
            db.Podopiecznies.Remove(podopieczny);
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
