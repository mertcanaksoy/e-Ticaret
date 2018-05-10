using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VTYS_Proje.Models;
using VTYS_Proje.App_Class;

namespace VTYS_Proje.Controllers
{
    public class HomeController : Controller
    {
        ModelETicaret db = new ModelETicaret();
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult miniSepet()
        {
            return PartialView();
        }

        public PartialViewResult Kategoriler()
        {
            return PartialView(db.Kategori.ToList());
        }

        public PartialViewResult SideKategori()
        {
            return PartialView(db.Kategori.ToList());
        }

        public PartialViewResult Markalar()
        {
            return PartialView(db.Marka.ToList());
        }

        public PartialViewResult SideMarka()
        {
            return PartialView(db.Marka.ToList());
        }

        public PartialViewResult SayiliUrun()
        {
            return PartialView(db.Urun.Take(15).ToList()); //15 ürün listelemek için
        }

        public PartialViewResult Footer()
        {
            return PartialView();
        }

        public ActionResult Urunler(int id)
        {
            return View(db.Urun.Where(x => x.KategoriID == id)); //o id degerine sahip ürünü parametre olarak al
        }

        public ActionResult MarkalaraGoreUrunler(int id)
        {
            return View(db.Urun.Where(x => x.MarkaID == id)); //o id degerine sahip ürünü parametre olarak al
        }

        public ActionResult UrunDetay(int id)
        {
            ViewBag.Resimler = db.Resim.Where(x => x.UrunID == id);
            return View(db.Urun.Find(id));
        }

        public void SepeteEkle(int id)
        {
            //SepettekiUrun nesnesi tanımlayıp sepete atalım
            Sepet.SepetUrun su = new Sepet.SepetUrun();

            //eklenecek ürünü belirleyelim
            Urun u = db.Urun.Find(id);

            su.urun = u;
            su.Adet = 1;

            Sepet s = new Sepet();
            s.SepeteEkle(su);
        }

        public ActionResult Sepetim()
        {
            //eğer sepet boş değilse "AktifSepet"i View'e gönder
            if (HttpContext.Session["AktifSepet"] != null)
                return View((Sepet)HttpContext.Session["AktifSepet"]);
            else//sepet boşsa Model'e birşey gönderilmez
                return View();
        }

        public void FavorilereEkle(int id)
        {
            //SepettekiUrun nesnesi tanımlayıp sepete atalım
            Favori.FavoriUrun fu = new Favori.FavoriUrun();

            //eklenecek ürünü belirleyelim
            Urun u = db.Urun.Find(id);

            fu.urun = u;
            fu.Adet = 1;

            Favori fav = new Favori();
            fav.FavorieEkle(fu);
        }


        public ActionResult Favorilerim()
        {
            //eğer favoriler boş değilse "AktifFavori"i View'e gönder
            if (HttpContext.Session["AktifFavori"] != null)
                return View((Favori)HttpContext.Session["AktifFavori"]);
            else//favoriler boşsa Model'e birşey gönderilmez
                return View();
        }

        public ActionResult Iletisim()
        {
            return View();
        }

        public ActionResult Hakkimizda()
        {
            return View();
        }

        public PartialViewResult AnlasmaliFirmalar()
        {
            return PartialView(db.Kargo.ToList());
        }
    }
}