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
    public class SiparisDetayController : Controller
    {
        private ModelETicaret db = new ModelETicaret();

        // GET: SiparisDetay
        public ActionResult Index()
        {
            var siparisDetay = db.SiparisDetay.Include(s => s.Siparis).Include(s => s.Urun);
            return View(siparisDetay.ToList());
        }

        // GET: SiparisDetay/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SiparisDetay siparisDetay = db.SiparisDetay.Find(id);
            if (siparisDetay == null)
            {
                return HttpNotFound();
            }
            return View(siparisDetay);
        }

        // GET: SiparisDetay/Create
        public ActionResult Create()
        {
            ViewBag.SiparisID = new SelectList(db.Siparis, "SiparisID", "KargoTakipNo");
            ViewBag.UrunID = new SelectList(db.Urun, "UrunID", "UrunAdi");
            return View();
        }

        // POST: SiparisDetay/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SiparisID,UrunID,Adet,Fiyat")] SiparisDetay siparisDetay)
        {
            if (ModelState.IsValid)
            {
                db.SiparisDetay.Add(siparisDetay);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.SiparisID = new SelectList(db.Siparis, "SiparisID", "KargoTakipNo", siparisDetay.SiparisID);
            ViewBag.UrunID = new SelectList(db.Urun, "UrunID", "UrunAdi", siparisDetay.UrunID);
            return View(siparisDetay);
        }

        // GET: SiparisDetay/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SiparisDetay siparisDetay = db.SiparisDetay.Find(id);
            if (siparisDetay == null)
            {
                return HttpNotFound();
            }
            ViewBag.SiparisID = new SelectList(db.Siparis, "SiparisID", "KargoTakipNo", siparisDetay.SiparisID);
            ViewBag.UrunID = new SelectList(db.Urun, "UrunID", "UrunAdi", siparisDetay.UrunID);
            return View(siparisDetay);
        }

        // POST: SiparisDetay/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SiparisID,UrunID,Adet,Fiyat")] SiparisDetay siparisDetay)
        {
            if (ModelState.IsValid)
            {
                db.Entry(siparisDetay).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.SiparisID = new SelectList(db.Siparis, "SiparisID", "KargoTakipNo", siparisDetay.SiparisID);
            ViewBag.UrunID = new SelectList(db.Urun, "UrunID", "UrunAdi", siparisDetay.UrunID);
            return View(siparisDetay);
        }

        // GET: SiparisDetay/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SiparisDetay siparisDetay = db.SiparisDetay.Find(id);
            if (siparisDetay == null)
            {
                return HttpNotFound();
            }
            return View(siparisDetay);
        }

        // POST: SiparisDetay/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SiparisDetay siparisDetay = db.SiparisDetay.Find(id);
            db.SiparisDetay.Remove(siparisDetay);
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
