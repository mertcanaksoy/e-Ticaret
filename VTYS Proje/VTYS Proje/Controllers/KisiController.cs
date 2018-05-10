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
    public class KisiController : Controller
    {
        private ModelETicaret db = new ModelETicaret();

        // GET: Kisi
        public ActionResult Index()
        {
            return View(db.Kisi.ToList());
        }

        // GET: Kisi/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kisi kisi = db.Kisi.Find(id);
            if (kisi == null)
            {
                return HttpNotFound();
            }
            return View(kisi);
        }

        // GET: Kisi/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Kisi/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "KisiID,AdSoyad,TCKN,DogumTarihi,Telefon,Email")] Kisi kisi)
        {
            if (ModelState.IsValid)
            {
                db.Kisi.Add(kisi);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(kisi);
        }

        // GET: Kisi/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kisi kisi = db.Kisi.Find(id);
            if (kisi == null)
            {
                return HttpNotFound();
            }
            return View(kisi);
        }

        // POST: Kisi/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "KisiID,AdSoyad,TCKN,DogumTarihi,Telefon,Email")] Kisi kisi)
        {
            if (ModelState.IsValid)
            {
                db.Entry(kisi).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(kisi);
        }

        // GET: Kisi/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kisi kisi = db.Kisi.Find(id);
            if (kisi == null)
            {
                return HttpNotFound();
            }
            return View(kisi);
        }

        // POST: Kisi/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Kisi kisi = db.Kisi.Find(id);
            db.Kisi.Remove(kisi);
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
