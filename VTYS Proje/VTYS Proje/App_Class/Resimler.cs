using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VTYS_Proje.App_Class
{
    public class Resimler
    {
        public IEnumerable<HttpPostedFileBase> Dosyalar { get; set; }
    }
}