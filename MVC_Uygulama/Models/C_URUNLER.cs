//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MVC_Uygulama.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class C_URUNLER
    {
        public int URUNID { get; set; }
        public string URUN_AD { get; set; }
        public string URUN_FIYAT { get; set; }
        public string URUN_RESIM { get; set; }
        public Nullable<int> URUN_KATEGORI_ID { get; set; }
    
        public virtual C_URUN_KATEGORILER C_URUN_KATEGORILER { get; set; }
    }
}
