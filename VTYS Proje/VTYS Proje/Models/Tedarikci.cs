namespace VTYS_Proje.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Tedarikci")]
    public partial class Tedarikci
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Tedarikci()
        {
            SatinAlma = new HashSet<SatinAlma>();
        }

        public int TedarikciID { get; set; }

        [Display(Name = "Tedarikci Adi")]
        [StringLength(100)]
        public string TedarikciAdi { get; set; }

        public int? UrunID { get; set; }

        [Display(Name = "Adresi")]
        [StringLength(500)]
        public string TedarikciAdres { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SatinAlma> SatinAlma { get; set; }

        public virtual Urun Urun { get; set; }
    }
}
