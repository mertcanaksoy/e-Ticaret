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
    public class KargoController : Controller
    {
        private ModelETicaret db = new ModelETicaret();

        // GET: Kargo
        public ActionResult Index()
        {
            return View(db.Kargo.ToList());
        }

        // GET: Kargo/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kargo kargo = db.Kargo.Find(id);
            if (kargo == null)
            {
                return HttpNotFound();
            }
            return View(kargo);
        }

        // GET: Kargo/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Kargo/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "KargoID,KargoAdi,KargoAdresi,KargoTelefon,KargoWeb,KargoEmail")] Kargo kargo)
        {
            if (ModelState.IsValid)
            {
                db.Kargo.Add(kargo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(kargo);
        }

        // GET: Kargo/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kargo kargo = db.Kargo.Find(id);
            if (kargo == null)
            {
                return HttpNotFound();
            }
            return View(kargo);
        }

        // POST: Kargo/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "KargoID,KargoAdi,KargoAdresi,KargoTelefon,KargoWeb,KargoEmail")] Kargo kargo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(kargo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(kargo);
        }

        // GET: Kargo/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kargo kargo = db.Kargo.Find(id);
            if (kargo == null)
            {
                return HttpNotFound();
            }
            return View(kargo);
        }

        // POST: Kargo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Kargo kargo = db.Kargo.Find(id);
            db.Kargo.Remove(kargo);
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
