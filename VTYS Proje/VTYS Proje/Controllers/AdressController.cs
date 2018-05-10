using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using VTYS_Proje.Models;

namespace VTYS_Proje.Controllers
{
    public class AdressController : Controller
    {
        private ModelETicaret db = new ModelETicaret();

        // GET: Adress
        public ActionResult Index()
        {
            var adress = db.Adress.Include(a => a.Musteri);
            return View(adress.ToList());
        }

        // GET: Adress/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Adress adress = db.Adress.Find(id);
            if (adress == null)
            {
                return HttpNotFound();
            }
            return View(adress);
        }

        // GET: Adress/Create
        public ActionResult Create()
        {
            ViewBag.MusteriID = new SelectList(db.Musteri, "MusteriID", "Aciklama");
            return View();
        }

        // POST: Adress/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AdresID,MusteriID,AdresAdi,AdresAlani")] Adress adress)
        {
            if (ModelState.IsValid)
            {
                db.Adress.Add(adress);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MusteriID = new SelectList(db.Musteri, "MusteriID", "Aciklama", adress.MusteriID);
            return View(adress);
        }

        // GET: Adress/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Adress adress = db.Adress.Find(id);
            if (adress == null)
            {
                return HttpNotFound();
            }
            ViewBag.MusteriID = new SelectList(db.Musteri, "MusteriID", "Aciklama", adress.MusteriID);
            return View(adress);
        }

        // POST: Adress/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AdresID,MusteriID,AdresAdi,AdresAlani")] Adress adress)
        {
            if (ModelState.IsValid)
            {
                db.Entry(adress).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MusteriID = new SelectList(db.Musteri, "MusteriID", "Aciklama", adress.MusteriID);
            return View(adress);
        }

        // GET: Adress/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Adress adress = db.Adress.Find(id);
            if (adress == null)
            {
                return HttpNotFound();
            }
            return View(adress);
        }

        // POST: Adress/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Adress adress = db.Adress.Find(id);
            db.Adress.Remove(adress);
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
