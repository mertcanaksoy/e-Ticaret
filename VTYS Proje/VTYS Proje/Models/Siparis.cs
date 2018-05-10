namespace VTYS_Proje.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Siparis
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Siparis()
        {
            SiparisDetay = new HashSet<SiparisDetay>();
        }

        public int SiparisID { get; set; }

        public int? MusteriID { get; set; }

        [Display(Name = "Siparis Tarihi")]
        [Column(TypeName = "smalldatetime")]
        public DateTime? SiparisTarihi { get; set; }

        public bool? SepetteMi { get; set; }

        public int? SiparisDurumID { get; set; }

        public int? KargoID { get; set; }

        [Display(Name = "Kargo Tahip No")]
        [StringLength(50)]
        public string KargoTakipNo { get; set; }

        public int? PersonelID { get; set; }

        public virtual Kargo Kargo { get; set; }

        public virtual Musteri Musteri { get; set; }

        public virtual Personel Personel { get; set; }

        public virtual SiparisDurum SiparisDurum { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SiparisDetay> SiparisDetay { get; set; }
    }
}
