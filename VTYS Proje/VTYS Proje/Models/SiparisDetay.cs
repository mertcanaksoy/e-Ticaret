namespace VTYS_Proje.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SiparisDetay")]
    public partial class SiparisDetay
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int SiparisID { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int UrunID { get; set; }

        public int? Adet { get; set; }

        [Column(TypeName = "money")]
        public decimal? Fiyat { get; set; }

        public virtual Siparis Siparis { get; set; }

        public virtual Urun Urun { get; set; }
    }
}
