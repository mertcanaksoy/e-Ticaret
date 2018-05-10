namespace VTYS_Proje.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ModelETicaret : DbContext
    {
        public ModelETicaret()
            : base("name=ModelETicaret")
        {
        }

        public virtual DbSet<Adress> Adress { get; set; }
        public virtual DbSet<Kargo> Kargo { get; set; }
        public virtual DbSet<Kategori> Kategori { get; set; }
        public virtual DbSet<Kisi> Kisi { get; set; }
        public virtual DbSet<Marka> Marka { get; set; }
        public virtual DbSet<Musteri> Musteri { get; set; }
        public virtual DbSet<Personel> Personel { get; set; }
        public virtual DbSet<Resim> Resim { get; set; }
        public virtual DbSet<SatinAlma> SatinAlma { get; set; }
        public virtual DbSet<SatinAlmaDetay> SatinAlmaDetay { get; set; }
        public virtual DbSet<Siparis> Siparis { get; set; }
        public virtual DbSet<SiparisDetay> SiparisDetay { get; set; }
        public virtual DbSet<SiparisDurum> SiparisDurum { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<Tedarikci> Tedarikci { get; set; }
        public virtual DbSet<Urun> Urun { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Musteri>()
                .HasMany(e => e.Adress)
                .WithRequired(e => e.Musteri)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Personel>()
                .Property(e => e.Maas)
                .HasPrecision(19, 4);

            modelBuilder.Entity<SatinAlma>()
                .HasMany(e => e.SatinAlmaDetay)
                .WithRequired(e => e.SatinAlma)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SatinAlmaDetay>()
                .Property(e => e.AlisFiyati)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Siparis>()
                .HasMany(e => e.SiparisDetay)
                .WithRequired(e => e.Siparis)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SiparisDetay>()
                .Property(e => e.Fiyat)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Urun>()
                .Property(e => e.UrunFiyat)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Urun>()
                .HasMany(e => e.Resim)
                .WithOptional(e => e.Urun)
                .WillCascadeOnDelete();

            modelBuilder.Entity<Urun>()
                .HasMany(e => e.SatinAlmaDetay)
                .WithRequired(e => e.Urun)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Urun>()
                .HasMany(e => e.SiparisDetay)
                .WithRequired(e => e.Urun)
                .WillCascadeOnDelete(false);
        }
    }
}
