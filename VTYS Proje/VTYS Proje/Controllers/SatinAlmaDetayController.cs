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
    public class SatinAlmaDetayController : Controller
    {
        private ModelETicaret db = new ModelETicaret();

        // GET: SatinAlmaDetay
        public ActionResult Index()
        {
            var satinAlmaDetay = db.SatinAlmaDetay.Include(s => s.SatinAlma).Include(s => s.Urun);
            return View(satinAlmaDetay.ToList());
        }

        // GET: SatinAlmaDetay/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SatinAlmaDetay satinAlmaDetay = db.SatinAlmaDetay.Find(id);
            if (satinAlmaDetay == null)
            {
                return HttpNotFound();
            }
            return View(satinAlmaDetay);
        }

        // GET: SatinAlmaDetay/Create
        public ActionResult Create()
        {
            ViewBag.SatinAlmaID = new SelectList(db.SatinAlma, "SatinAlmaID", "SatinAlmaID");
            ViewBag.UrunID = new SelectList(db.Urun, "UrunID", "UrunAdi");
            return View();
        }

        // POST: SatinAlmaDetay/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SatinAlmaID,UrunID,Adet,AlisFiyati")] SatinAlmaDetay satinAlmaDetay)
        {
            if (ModelState.IsValid)
            {
                db.SatinAlmaDetay.Add(satinAlmaDetay);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.SatinAlmaID = new SelectList(db.SatinAlma, "SatinAlmaID", "SatinAlmaID", satinAlmaDetay.SatinAlmaID);
            ViewBag.UrunID = new SelectList(db.Urun, "UrunID", "UrunAdi", satinAlmaDetay.UrunID);
            return View(satinAlmaDetay);
        }

        // GET: SatinAlmaDetay/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SatinAlmaDetay satinAlmaDetay = db.SatinAlmaDetay.Find(id);
            if (satinAlmaDetay == null)
            {
                return HttpNotFound();
            }
            ViewBag.SatinAlmaID = new SelectList(db.SatinAlma, "SatinAlmaID", "SatinAlmaID", satinAlmaDetay.SatinAlmaID);
            ViewBag.UrunID = new SelectList(db.Urun, "UrunID", "UrunAdi", satinAlmaDetay.UrunID);
            return View(satinAlmaDetay);
        }

        // POST: SatinAlmaDetay/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SatinAlmaID,UrunID,Adet,AlisFiyati")] SatinAlmaDetay satinAlmaDetay)
        {
            if (ModelState.IsValid)
            {
                db.Entry(satinAlmaDetay).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.SatinAlmaID = new SelectList(db.SatinAlma, "SatinAlmaID", "SatinAlmaID", satinAlmaDetay.SatinAlmaID);
            ViewBag.UrunID = new SelectList(db.Urun, "UrunID", "UrunAdi", satinAlmaDetay.UrunID);
            return View(satinAlmaDetay);
        }

        // GET: SatinAlmaDetay/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SatinAlmaDetay satinAlmaDetay = db.SatinAlmaDetay.Find(id);
            if (satinAlmaDetay == null)
            {
                return HttpNotFound();
            }
            return View(satinAlmaDetay);
        }

        // POST: SatinAlmaDetay/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SatinAlmaDetay satinAlmaDetay = db.SatinAlmaDetay.Find(id);
            db.SatinAlmaDetay.Remove(satinAlmaDetay);
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
