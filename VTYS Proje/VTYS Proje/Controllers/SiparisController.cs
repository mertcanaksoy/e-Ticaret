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
    public class SiparisController : Controller
    {
        private ModelETicaret db = new ModelETicaret();

        // GET: Siparis
        public ActionResult Index()
        {
            var siparis = db.Siparis.Include(s => s.Kargo).Include(s => s.Musteri).Include(s => s.Personel).Include(s => s.SiparisDurum);
            return View(siparis.ToList());
        }

        // GET: Siparis/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Siparis siparis = db.Siparis.Find(id);
            if (siparis == null)
            {
                return HttpNotFound();
            }
            return View(siparis);
        }

        // GET: Siparis/Create
        public ActionResult Create()
        {
            ViewBag.KargoID = new SelectList(db.Kargo, "KargoID", "KargoAdi");
            ViewBag.MusteriID = new SelectList(db.Musteri, "MusteriID", "Aciklama");
            ViewBag.PersonelID = new SelectList(db.Personel, "PersonelID", "PersonelID");
            ViewBag.SiparisDurumID = new SelectList(db.SiparisDurum, "SiparisDurumID", "SiparisDurumAdi");
            return View();
        }

        // POST: Siparis/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SiparisID,MusteriID,SiparisTarihi,SepetteMi,SiparisDurumID,KargoID,KargoTakipNo,PersonelID")] Siparis siparis)
        {
            if (ModelState.IsValid)
            {
                db.Siparis.Add(siparis);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.KargoID = new SelectList(db.Kargo, "KargoID", "KargoAdi", siparis.KargoID);
            ViewBag.MusteriID = new SelectList(db.Musteri, "MusteriID", "Aciklama", siparis.MusteriID);
            ViewBag.PersonelID = new SelectList(db.Personel, "PersonelID", "PersonelID", siparis.PersonelID);
            ViewBag.SiparisDurumID = new SelectList(db.SiparisDurum, "SiparisDurumID", "SiparisDurumAdi", siparis.SiparisDurumID);
            return View(siparis);
        }

        // GET: Siparis/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Siparis siparis = db.Siparis.Find(id);
            if (siparis == null)
            {
                return HttpNotFound();
            }
            ViewBag.KargoID = new SelectList(db.Kargo, "KargoID", "KargoAdi", siparis.KargoID);
            ViewBag.MusteriID = new SelectList(db.Musteri, "MusteriID", "Aciklama", siparis.MusteriID);
            ViewBag.PersonelID = new SelectList(db.Personel, "PersonelID", "PersonelID", siparis.PersonelID);
            ViewBag.SiparisDurumID = new SelectList(db.SiparisDurum, "SiparisDurumID", "SiparisDurumAdi", siparis.SiparisDurumID);
            return View(siparis);
        }

        // POST: Siparis/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SiparisID,MusteriID,SiparisTarihi,SepetteMi,SiparisDurumID,KargoID,KargoTakipNo,PersonelID")] Siparis siparis)
        {
            if (ModelState.IsValid)
            {
                db.Entry(siparis).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.KargoID = new SelectList(db.Kargo, "KargoID", "KargoAdi", siparis.KargoID);
            ViewBag.MusteriID = new SelectList(db.Musteri, "MusteriID", "Aciklama", siparis.MusteriID);
            ViewBag.PersonelID = new SelectList(db.Personel, "PersonelID", "PersonelID", siparis.PersonelID);
            ViewBag.SiparisDurumID = new SelectList(db.SiparisDurum, "SiparisDurumID", "SiparisDurumAdi", siparis.SiparisDurumID);
            return View(siparis);
        }

        // GET: Siparis/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Siparis siparis = db.Siparis.Find(id);
            if (siparis == null)
            {
                return HttpNotFound();
            }
            return View(siparis);
        }

        // POST: Siparis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Siparis siparis = db.Siparis.Find(id);
            db.Siparis.Remove(siparis);
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
