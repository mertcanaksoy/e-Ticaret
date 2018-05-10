using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using VTYS_Proje.Models;
using System.IO;
using VTYS_Proje.App_Class;

namespace VTYS_Proje.Controllers
{
    public class UrunController : Controller
    {
        private ModelETicaret db = new ModelETicaret();

        // GET: Urun
        public ActionResult Index()
        {
            var urun = db.Urun.Include(u => u.Kategori).Include(u => u.Marka);
            return View(urun.ToList());
        }

        // GET: Urun/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Urun urun = db.Urun.Find(id);
            if (urun == null)
            {
                return HttpNotFound();
            }
            return View(urun);
        }

        // GET: Urun/Create
        public ActionResult Create()
        {
            ViewBag.KategoriID = new SelectList(db.Kategori, "KategoriID", "KategoriAdi");
            ViewBag.MarkaID = new SelectList(db.Marka, "MarkaID", "MarkaAdi");
            return View();
        }

        // POST: Urun/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UrunID,KategoriID,MarkaID,UrunAdi,UrunAciklama,UrunFiyat,UrunStok")] Urun urun)
        {
            if (ModelState.IsValid)
            {
                db.Urun.Add(urun);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.KategoriID = new SelectList(db.Kategori, "KategoriID", "KategoriAdi", urun.KategoriID);
            ViewBag.MarkaID = new SelectList(db.Marka, "MarkaID", "MarkaAdi", urun.MarkaID);
            return View(urun);
        }

        // GET: Urun/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Urun urun = db.Urun.Find(id);
            if (urun == null)
            {
                return HttpNotFound();
            }
            ViewBag.KategoriID = new SelectList(db.Kategori, "KategoriID", "KategoriAdi", urun.KategoriID);
            ViewBag.MarkaID = new SelectList(db.Marka, "MarkaID", "MarkaAdi", urun.MarkaID);
            return View(urun);
        }

        // POST: Urun/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UrunID,KategoriID,MarkaID,UrunAdi,UrunAciklama,UrunFiyat,UrunStok")] Urun urun)
        {
            if (ModelState.IsValid)
            {
                db.Entry(urun).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.KategoriID = new SelectList(db.Kategori, "KategoriID", "KategoriAdi", urun.KategoriID);
            ViewBag.MarkaID = new SelectList(db.Marka, "MarkaID", "MarkaAdi", urun.MarkaID);
            return View(urun);
        }

        // GET: Urun/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Urun urun = db.Urun.Find(id);
            if (urun == null)
            {
                return HttpNotFound();
            }
            return View(urun);
        }

        // POST: Urun/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            //Ürüne ait resimleri, Resimler klasöründen silmek için
            //belirtilen ürünid'sine sahip resimler tespit edildi
            var resimler = db.Resim.Where(x => x.UrunID == id).ToList();
            //her bir resmin adresini bul, daha sonra sil
            foreach (var resim in resimler)
            {
                var adres = Server.MapPath("~/Resimler/" + resim.ResimAdi);
                System.IO.File.Delete(adres);
            }

            //Ürüne ait resimleri, veritabanından silmek için
            Urun urun = db.Urun.Find(id);
            db.Urun.Remove(urun);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult ResimEkle(int id)
        {
            Urun urun = db.Urun.Find(id);
            return View(urun);
        }

        [HttpPost]
        public ActionResult ResimEkle(Resimler resim, int urunid)
        {
            //Her resim için yükleme işlemini yap
            foreach (var dosya in resim.Dosyalar)
            {
                if (dosya.ContentLength > 0)
                {
                    //Her resim dosyası benzersiz bir isme sahip olması için Guid metodu kullanılıyor
                    //Gelen her resim dosyası, resimler klasörüne kaydediliyor
                    var dosyaAdi = Guid.NewGuid() + Path.GetExtension(dosya.FileName);
                    var adres = Path.Combine(Server.MapPath("~/Resimler"), dosyaAdi);
                    dosya.SaveAs(adres);

                    //Klasöre kaydedilen resim, veritabanına da kaydediliyor
                    Resim rsm = new Resim();
                    rsm.UrunID = urunid;
                    rsm.ResimAdi = dosyaAdi;
                    db.Resim.Add(rsm);
                }
                else
                {
                    ViewBag.Mesaj = "Resim yükleme yapılamadı";
                    return View();
                }
            }
            db.SaveChanges();
            return RedirectToAction("Index"); //Urun listeleme sayfasına geri dön
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
