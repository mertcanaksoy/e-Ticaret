namespace VTYS_Proje.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Adress")]
    public partial class Adress
    {
        [Key]
        public int AdresID { get; set; }

        public int MusteriID { get; set; }

        [Display(Name = "Adres Turu")]
        [StringLength(50)]
        public string AdresAdi { get; set; }

        [Display(Name = "Adres Alani")]
        [StringLength(250)]
        public string AdresAlani { get; set; }

        public virtual Musteri Musteri { get; set; }
    }
}
