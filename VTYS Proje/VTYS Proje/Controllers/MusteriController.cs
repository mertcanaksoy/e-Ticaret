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
    public class MusteriController : Controller
    {
        private ModelETicaret db = new ModelETicaret();

        // GET: Musteri
        public ActionResult Index()
        {
            var musteri = db.Musteri.Include(m => m.Kisi);
            return View(musteri.ToList());
        }

        // GET: Musteri/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Musteri musteri = db.Musteri.Find(id);
            if (musteri == null)
            {
                return HttpNotFound();
            }
            return View(musteri);
        }

        // GET: Musteri/Create
        public ActionResult Create()
        {
            ViewBag.KisiID = new SelectList(db.Kisi, "KisiID", "AdSoyad");
            return View();
        }

        // POST: Musteri/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MusteriID,KisiID,Aciklama")] Musteri musteri)
        {
            if (ModelState.IsValid)
            {
                db.Musteri.Add(musteri);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.KisiID = new SelectList(db.Kisi, "KisiID", "AdSoyad", musteri.KisiID);
            return View(musteri);
        }

        // GET: Musteri/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Musteri musteri = db.Musteri.Find(id);
            if (musteri == null)
            {
                return HttpNotFound();
            }
            ViewBag.KisiID = new SelectList(db.Kisi, "KisiID", "AdSoyad", musteri.KisiID);
            return View(musteri);
        }

        // POST: Musteri/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MusteriID,KisiID,Aciklama")] Musteri musteri)
        {
            if (ModelState.IsValid)
            {
                db.Entry(musteri).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.KisiID = new SelectList(db.Kisi, "KisiID", "AdSoyad", musteri.KisiID);
            return View(musteri);
        }

        // GET: Musteri/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Musteri musteri = db.Musteri.Find(id);
            if (musteri == null)
            {
                return HttpNotFound();
            }
            return View(musteri);
        }

        // POST: Musteri/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Musteri musteri = db.Musteri.Find(id);
            db.Musteri.Remove(musteri);
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
