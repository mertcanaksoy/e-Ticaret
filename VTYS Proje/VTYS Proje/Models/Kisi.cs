namespace VTYS_Proje.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Kisi")]
    public partial class Kisi
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Kisi()
        {
            Musteri = new HashSet<Musteri>();
            Personel = new HashSet<Personel>();
        }

        public int KisiID { get; set; }

        [Display(Name = "Ad-Soyad")]
        [StringLength(50)]
        public string AdSoyad { get; set; }

        [Display(Name = "TC NO")]
        [StringLength(11)]
        public string TCKN { get; set; }

        [Display(Name = "Dogum Tarihi")]
        [Column(TypeName = "smalldatetime")]
        public DateTime? DogumTarihi { get; set; }

        [StringLength(11)]
        public string Telefon { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Musteri> Musteri { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Personel> Personel { get; set; }
    }
}
