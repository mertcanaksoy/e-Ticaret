namespace VTYS_Proje.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Resim")]
    public partial class Resim
    {
        public int ResimID { get; set; }

        public int? UrunID { get; set; }

        [StringLength(250)]
        public string ResimAdi { get; set; }

        public virtual Urun Urun { get; set; }
    }
}
