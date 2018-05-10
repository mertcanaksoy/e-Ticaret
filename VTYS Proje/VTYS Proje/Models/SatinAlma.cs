namespace VTYS_Proje.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SatinAlma")]
    public partial class SatinAlma
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SatinAlma()
        {
            SatinAlmaDetay = new HashSet<SatinAlmaDetay>();
        }

        public int SatinAlmaID { get; set; }

        public int? TedarikciID { get; set; }

        [Display(Name = "Satin Alma Tarihi")]
        [Column(TypeName = "date")]
        public DateTime? SatinAlmaTarihi { get; set; }

        public int? PersonelID { get; set; }

        public virtual Personel Personel { get; set; }

        public virtual Tedarikci Tedarikci { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SatinAlmaDetay> SatinAlmaDetay { get; set; }
    }
}
