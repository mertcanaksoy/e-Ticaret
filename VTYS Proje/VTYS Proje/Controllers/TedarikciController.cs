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
    public class TedarikciController : Controller
    {
        private ModelETicaret db = new ModelETicaret();

        // GET: Tedarikci
        public ActionResult Index()
        {
            var tedarikci = db.Tedarikci.Include(t => t.Urun);
            return View(tedarikci.ToList());
        }

        // GET: Tedarikci/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tedarikci tedarikci = db.Tedarikci.Find(id);
            if (tedarikci == null)
            {
                return HttpNotFound();
            }
            return View(tedarikci);
        }

        // GET: Tedarikci/Create
        public ActionResult Create()
        {
            ViewBag.UrunID = new SelectList(db.Urun, "UrunID", "UrunAdi");
            return View();
        }

        // POST: Tedarikci/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TedarikciID,TedarikciAdi,UrunID,TedarikciAdres")] Tedarikci tedarikci)
        {
            if (ModelState.IsValid)
            {
                db.Tedarikci.Add(tedarikci);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UrunID = new SelectList(db.Urun, "UrunID", "UrunAdi", tedarikci.UrunID);
            return View(tedarikci);
        }

        // GET: Tedarikci/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tedarikci tedarikci = db.Tedarikci.Find(id);
            if (tedarikci == null)
            {
                return HttpNotFound();
            }
            ViewBag.UrunID = new SelectList(db.Urun, "UrunID", "UrunAdi", tedarikci.UrunID);
            return View(tedarikci);
        }

        // POST: Tedarikci/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TedarikciID,TedarikciAdi,UrunID,TedarikciAdres")] Tedarikci tedarikci)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tedarikci).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UrunID = new SelectList(db.Urun, "UrunID", "UrunAdi", tedarikci.UrunID);
            return View(tedarikci);
        }

        // GET: Tedarikci/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tedarikci tedarikci = db.Tedarikci.Find(id);
            if (tedarikci == null)
            {
                return HttpNotFound();
            }
            return View(tedarikci);
        }

        // POST: Tedarikci/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tedarikci tedarikci = db.Tedarikci.Find(id);
            db.Tedarikci.Remove(tedarikci);
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
