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
    public class SatinAlmaController : Controller
    {
        private ModelETicaret db = new ModelETicaret();

        // GET: SatinAlma
        public ActionResult Index()
        {
            var satinAlma = db.SatinAlma.Include(s => s.Personel).Include(s => s.Tedarikci);
            return View(satinAlma.ToList());
        }

        // GET: SatinAlma/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SatinAlma satinAlma = db.SatinAlma.Find(id);
            if (satinAlma == null)
            {
                return HttpNotFound();
            }
            return View(satinAlma);
        }

        // GET: SatinAlma/Create
        public ActionResult Create()
        {
            ViewBag.PersonelID = new SelectList(db.Personel, "PersonelID", "PersonelID");
            ViewBag.TedarikciID = new SelectList(db.Tedarikci, "TedarikciID", "TedarikciAdi");
            return View();
        }

        // POST: SatinAlma/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SatinAlmaID,TedarikciID,SatinAlmaTarihi,PersonelID")] SatinAlma satinAlma)
        {
            if (ModelState.IsValid)
            {
                db.SatinAlma.Add(satinAlma);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PersonelID = new SelectList(db.Personel, "PersonelID", "PersonelID", satinAlma.PersonelID);
            ViewBag.TedarikciID = new SelectList(db.Tedarikci, "TedarikciID", "TedarikciAdi", satinAlma.TedarikciID);
            return View(satinAlma);
        }

        // GET: SatinAlma/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SatinAlma satinAlma = db.SatinAlma.Find(id);
            if (satinAlma == null)
            {
                return HttpNotFound();
            }
            ViewBag.PersonelID = new SelectList(db.Personel, "PersonelID", "PersonelID", satinAlma.PersonelID);
            ViewBag.TedarikciID = new SelectList(db.Tedarikci, "TedarikciID", "TedarikciAdi", satinAlma.TedarikciID);
            return View(satinAlma);
        }

        // POST: SatinAlma/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SatinAlmaID,TedarikciID,SatinAlmaTarihi,PersonelID")] SatinAlma satinAlma)
        {
            if (ModelState.IsValid)
            {
                db.Entry(satinAlma).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PersonelID = new SelectList(db.Personel, "PersonelID", "PersonelID", satinAlma.PersonelID);
            ViewBag.TedarikciID = new SelectList(db.Tedarikci, "TedarikciID", "TedarikciAdi", satinAlma.TedarikciID);
            return View(satinAlma);
        }

        // GET: SatinAlma/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SatinAlma satinAlma = db.SatinAlma.Find(id);
            if (satinAlma == null)
            {
                return HttpNotFound();
            }
            return View(satinAlma);
        }

        // POST: SatinAlma/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SatinAlma satinAlma = db.SatinAlma.Find(id);
            db.SatinAlma.Remove(satinAlma);
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
