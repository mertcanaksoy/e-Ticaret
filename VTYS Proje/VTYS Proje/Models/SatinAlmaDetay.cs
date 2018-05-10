namespace VTYS_Proje.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SatinAlmaDetay")]
    public partial class SatinAlmaDetay
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int SatinAlmaID { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int UrunID { get; set; }

        public int? Adet { get; set; }

        [Display(Name = "Alis Fiyati")]
        [Column(TypeName = "money")]
        public decimal? AlisFiyati { get; set; }

        public virtual SatinAlma SatinAlma { get; set; }

        public virtual Urun Urun { get; set; }
    }
}
