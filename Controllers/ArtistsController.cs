using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication8.Models;
using System.Data.SqlClient;

namespace WebApplication8.Controllers
{
    public class ArtistsController : Controller
    {
        private ChinookEntities db = new ChinookEntities();

        // GET: Artists
        public ActionResult Index()
        {
            return View(db.Artist.ToList());
        }

        // GET: Artists/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Artist artist = db.Artist.Find(id);
            if (artist == null)
            {
                return HttpNotFound();
            }
            return View(artist);
        }

        // GET: Artists/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Artists/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ArtistId,Name")] Artist artist)
        {
            if (ModelState.IsValid)
            {
                db.Artist.Add(artist);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(artist);
        }

        // GET: Artists/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Artist artist = db.Artist.Find(id);
            if (artist == null)
            {
                return HttpNotFound();
            }
            return View(artist);
        }

        // POST: Artists/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ArtistId,Name")] Artist artist)
        {
            if (ModelState.IsValid)
            {
                db.Entry(artist).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(artist);
        }

        // GET: Artists/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Artist artist = db.Artist.Find(id);
            if (artist == null)
            {
                return HttpNotFound();
            }
            return View(artist);
        }

        // POST: Artists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Artist artist = db.Artist.Find(id);
            db.Artist.Remove(artist);
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

        public ActionResult Input()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Input(int? count, string date1 ,string date2)
        {

            int? X = count; 
            string since = date1;
            string till = date2;
            
            if ((since == "" && till == "" && X == null) || (till == "" && X == null)|| (since == "" && X == null))
            {
                return RedirectToAction("Input");
            }
            if (since == "")
            {
                since = "2009-01-01";
            }
            if (till == "")
            {
                till = "2100-01-01";
            }
            if (X == null)
            {
                return RedirectToAction("Input");
            }
            using (var context = new ChinookEntities())
            {
                var data = context.Artist.SqlQuery("[dbo].[query1] @X, @StartDate, @StopDate",
                    new SqlParameter("X", count),
                    new SqlParameter("StartDate", since),
                    new SqlParameter("StopDate", till)).ToList();
                TempData["data"] = data;
                return RedirectToAction("show");
            }

        }
        public ActionResult Show()
        {
            var result = TempData["data"];
            if (result != null) { 
            return View(result);}
            else { 
                return RedirectToAction("Input");}
        }
    }
}
