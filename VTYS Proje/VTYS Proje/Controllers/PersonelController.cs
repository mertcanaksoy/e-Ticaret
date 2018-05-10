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
    public class PersonelController : Controller
    {
        private ModelETicaret db = new ModelETicaret();

        // GET: Personel
        public ActionResult Index()
        {
            var personel = db.Personel.Include(p => p.Kisi);
            return View(personel.ToList());
        }

        // GET: Personel/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Personel personel = db.Personel.Find(id);
            if (personel == null)
            {
                return HttpNotFound();
            }
            return View(personel);
        }

        // GET: Personel/Create
        public ActionResult Create()
        {
            ViewBag.KisiID = new SelectList(db.Kisi, "KisiID", "AdSoyad");
            return View();
        }

        // POST: Personel/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PersonelID,KisiID,IseBaslamaTarihi,Maas")] Personel personel)
        {
            if (ModelState.IsValid)
            {
                db.Personel.Add(personel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.KisiID = new SelectList(db.Kisi, "KisiID", "AdSoyad", personel.KisiID);
            return View(personel);
        }

        // GET: Personel/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Personel personel = db.Personel.Find(id);
            if (personel == null)
            {
                return HttpNotFound();
            }
            ViewBag.KisiID = new SelectList(db.Kisi, "KisiID", "AdSoyad", personel.KisiID);
            return View(personel);
        }

        // POST: Personel/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PersonelID,KisiID,IseBaslamaTarihi,Maas")] Personel personel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(personel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.KisiID = new SelectList(db.Kisi, "KisiID", "AdSoyad", personel.KisiID);
            return View(personel);
        }

        // GET: Personel/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Personel personel = db.Personel.Find(id);
            if (personel == null)
            {
                return HttpNotFound();
            }
            return View(personel);
        }

        // POST: Personel/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Personel personel = db.Personel.Find(id);
            db.Personel.Remove(personel);
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
