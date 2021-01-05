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
    public class TrenersController : Controller
    {
        private PersonalnyContext db = new PersonalnyContext();

        // GET: Treners
        [Authorize(Roles = "Podopieczny,Admin")]
        public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.ImieSortParm = String.IsNullOrEmpty(sortOrder) ? "Imie_desc" : "";
            ViewBag.LiczbaPodopiecznychSortParm = String.IsNullOrEmpty(sortOrder) ? "LiczbaMaksPodopiecznych_desc" : "";
            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;
            var treners = db.Treners.ToList();
            if (!String.IsNullOrEmpty(searchString))
            {
                treners = treners.Where(t => t.Nazwisko.Contains(searchString)).ToList();
            }
            switch (sortOrder)
            {
                case "Imie_desc":
                    treners = treners.OrderByDescending(t => t.Imie).ToList();
                    break;
                case "LiczbaMaksPodopiecznych_desc":
                    treners = treners.OrderByDescending(t => t.LiczbaMaksPodopiecznych).ToList();
                    break;
                default:
                    treners = treners.OrderBy(t => t.Nazwisko).ToList();
                    break;
            }
            int pageSize = 3;
            int pageNumber = (page ?? 1);
            return View(treners.ToPagedList(pageNumber, pageSize));
        }
        [Authorize]
        // GET: Treners/Details/5
        public ActionResult Details(string UserName)
        {
            if (UserName == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Trener trener = db.Treners.Single(t => t.UserName == UserName);
            if (trener == null)
            {
                return HttpNotFound();
            }
            return View(trener);
        }
        [Authorize(Roles = "Admin")]
        // GET: Treners/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Treners/Create
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Avatar,UserName,Imie,Nazwisko,Wiek,LiczbaMaksPodopiecznych,Numerkonta")] Trener trener)
        {
            if (ModelState.IsValid)
            {
                db.Treners.Add(trener);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(trener);
        }
        [Authorize(Roles = "Trener")]
        // GET: Treners/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Trener trener = db.Treners.Find(id);
            if (trener == null)
            {
                return HttpNotFound();
            }
            return View(trener);
        }

        // POST: Treners/Edit/5
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Edit([Bind(Include = "ID,Avatar,UserName,Imie,Nazwisko,Wiek,LiczbaMaksPodopiecznych,Numerkonta")] Trener trener)
        {
            HttpPostedFileBase plik = Request.Files["plikzobrazkiem"];
            if (plik != null && plik.ContentLength > 0)
            {
                trener.Avatar = plik.FileName;
                plik.SaveAs(HttpContext.Server.MapPath("~/Avatary/") + trener.Avatar);
            }
            if (ModelState.IsValid)
            {
                db.Entry(trener).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index","Home");
            }
            return View(trener);
        }

        [Authorize(Roles = "Admin")]
        // GET: Treners/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Trener trener = db.Treners.Find(id);
            if (trener == null)
            {
                return HttpNotFound();
            }
            return View(trener);
        }

        // POST: Treners/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Trener trener = db.Treners.Find(id);
            db.Treners.Remove(trener);
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
