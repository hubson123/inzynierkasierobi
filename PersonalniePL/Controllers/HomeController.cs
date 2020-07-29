using PersonalniePL.Data;
using PersonalniePL.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PersonalniePL.Controllers
{
    public class HomeController : Controller
    {
        private PersonalnyContext db = new PersonalnyContext();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            IQueryable<StatystykiTrenerzy> dane = db.Treners.SelectMany(t => t.Podopiecznies).GroupBy(t => t.Trener)
                .Select(m => new StatystykiTrenerzy() { IDTren = m.Key, Ilu = m.Count() });

            return View(dane.ToList());

        }
        [HttpPost]
        public ActionResult Contact(FormCollection form)
        {
            string title = form["title"].ToString();
            string body = form["body"].ToString();
            Mail.SendMail(title, body);
            return View();
        }
        // GET: Home/Contact
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Akcja()
        {
            return View();
        }
        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}