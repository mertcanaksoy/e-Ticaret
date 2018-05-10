using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VTYS_Proje.Models;

namespace VTYS_Proje.App_Class
{
    public class Favori
    {
        //Favori tipinde "AktifFavori" adında bir propery
        public static Favori AktifFavori
        {
            get
            {
                //ziyaretçinin oturum nesnelerini "ctx" değişkeninde tut
                HttpContext ctx = HttpContext.Current;

                //eğer Favori yok ise Favori oluştur
                if (ctx.Session["AktifFavori"] == null)
                    ctx.Session["AktifFavori"] = new Favori();

                //Favorii döndür
                return (Favori)ctx.Session["AktifFavori"];
            }
        }

        public class FavoriUrun //Favoriteki satırların tutulduğu sınıf
        {

            public Urun urun { get; set; }
            public int Adet { get; set; }
            public decimal Tutar
            {
                get
                {
                    return Adet * (decimal)urun.UrunFiyat;
                }
            }
        }

        //Favorite bulunan ürünlerin listesi
        private List<FavoriUrun> urunler = new List<FavoriUrun>();

        //listedeki ürünler "Urunler" özelliği ile çekilecek
        public List<FavoriUrun> Urunler
        {
            get { return urunler; }
            set { urunler = value; }
        }

        //ürünlerin Favorie eklenmesini sağlayan metot
        public void FavorieEkle(FavoriUrun fu)
        {
            //oturum değişkenlerinde AktifFavori boşsa
            if (HttpContext.Current.Session["AktifFavori"] == null)
            {
                //yeni Favori oluştur
                Favori favori = new Favori();
                //Ürünü Favorie ekle
                favori.Urunler.Add(fu);
                //Favorii "AktifFavori"e ekle
                HttpContext.Current.Session["AktifFavori"] = favori;
            }
            else//AktifFavori doluysa
            {
                //AktifFavori adlı oturum değişkenini Favori nesnesine ata
                Favori favori = (Favori)HttpContext.Current.Session["AktifFavori"];
                //eğer Favorite aynı ürün varsa ürün adetini artır
                if (favori.Urunler.Any(x => x.urun.UrunID == fu.urun.UrunID))
                    Urunler.FirstOrDefault(x => x.urun.UrunID == fu.urun.UrunID).Adet += 1;
                else//aynı ürün yoksa ürünü Favorie ekle
                    favori.Urunler.Add(fu);
            }
        }

        public decimal GenelToplam
        {
            //Favoriteki ürünlerin toplam fiyatı
            get { return Urunler.Sum(x => x.Tutar); }
        }

    }
}