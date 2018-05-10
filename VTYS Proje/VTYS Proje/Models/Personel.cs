namespace VTYS_Proje.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Personel")]
    public partial class Personel
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Personel()
        {
            SatinAlma = new HashSet<SatinAlma>();
            Siparis = new HashSet<Siparis>();
        }

        public int PersonelID { get; set; }

        public int? KisiID { get; set; }

        [Display(Name = "ise Baslama Tarihi")]
        [Column(TypeName = "smalldatetime")]
        public DateTime? IseBaslamaTarihi { get; set; }

        [Column(TypeName = "money")]
        public decimal? Maas { get; set; }

        public virtual Kisi Kisi { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SatinAlma> SatinAlma { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Siparis> Siparis { get; set; }
    }
}
