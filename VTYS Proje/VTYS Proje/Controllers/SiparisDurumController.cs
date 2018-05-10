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
    public class SiparisDurumController : Controller
    {
        private ModelETicaret db = new ModelETicaret();

        // GET: SiparisDurum
        public ActionResult Index()
        {
            return View(db.SiparisDurum.ToList());
        }

        // GET: SiparisDurum/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SiparisDurum siparisDurum = db.SiparisDurum.Find(id);
            if (siparisDurum == null)
            {
                return HttpNotFound();
            }
            return View(siparisDurum);
        }

        // GET: SiparisDurum/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SiparisDurum/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SiparisDurumID,SiparisDurumAdi")] SiparisDurum siparisDurum)
        {
            if (ModelState.IsValid)
            {
                db.SiparisDurum.Add(siparisDurum);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(siparisDurum);
        }

        // GET: SiparisDurum/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SiparisDurum siparisDurum = db.SiparisDurum.Find(id);
            if (siparisDurum == null)
            {
                return HttpNotFound();
            }
            return View(siparisDurum);
        }

        // POST: SiparisDurum/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SiparisDurumID,SiparisDurumAdi")] SiparisDurum siparisDurum)
        {
            if (ModelState.IsValid)
            {
                db.Entry(siparisDurum).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(siparisDurum);
        }

        // GET: SiparisDurum/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SiparisDurum siparisDurum = db.SiparisDurum.Find(id);
            if (siparisDurum == null)
            {
                return HttpNotFound();
            }
            return View(siparisDurum);
        }

        // POST: SiparisDurum/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SiparisDurum siparisDurum = db.SiparisDurum.Find(id);
            db.SiparisDurum.Remove(siparisDurum);
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
