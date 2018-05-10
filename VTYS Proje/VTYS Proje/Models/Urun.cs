namespace VTYS_Proje.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Urun")]
    public partial class Urun
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Urun()
        {
            Resim = new HashSet<Resim>();
            SatinAlmaDetay = new HashSet<SatinAlmaDetay>();
            SiparisDetay = new HashSet<SiparisDetay>();
            Tedarikci = new HashSet<Tedarikci>();
        }

        public int UrunID { get; set; }

        public int? KategoriID { get; set; }

        public int? MarkaID { get; set; }

        [Display(Name = "Urun Adi")]
        [StringLength(250)]
        public string UrunAdi { get; set; }

        [Display(Name = "Detay")]
        [StringLength(1000)]
        public string UrunAciklama { get; set; }

        [Display(Name = "Fiyat")]
        [Column(TypeName = "money")]
        public decimal? UrunFiyat { get; set; }

        public int? UrunStok { get; set; }

        public virtual Kategori Kategori { get; set; }

        public virtual Marka Marka { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Resim> Resim { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SatinAlmaDetay> SatinAlmaDetay { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SiparisDetay> SiparisDetay { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tedarikci> Tedarikci { get; set; }
    }
}
