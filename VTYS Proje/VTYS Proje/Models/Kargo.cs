namespace VTYS_Proje.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Kargo")]
    public partial class Kargo
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Kargo()
        {
            Siparis = new HashSet<Siparis>();
        }

        public int KargoID { get; set; }

        [Display(Name = "Sirket")]
        [StringLength(50)]
        public string KargoAdi { get; set; }

        [Display(Name = "Adres")]
        [StringLength(50)]
        public string KargoAdresi { get; set; }

        [Display(Name = "Telefon")]
        [StringLength(50)]
        public string KargoTelefon { get; set; }

        [Display(Name = "Web Sitesi")]
        [StringLength(50)]
        public string KargoWeb { get; set; }

        [Display(Name = "E-mail")]
        [StringLength(50)]
        public string KargoEmail { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Siparis> Siparis { get; set; }
    }
}
