//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace shinigamiZer0
{
    using System;
    using System.Collections.Generic;
    
    public partial class TblKitaplar
    {
        public int id { get; set; }
        public string kitapAdi { get; set; }
        public Nullable<int> yazari { get; set; }
        public Nullable<int> turu { get; set; }
        public string sayfaSayisi { get; set; }
    
        public virtual TblTurler TblTurler { get; set; }
        public virtual TblYazarlar TblYazarlar { get; set; }
    }
}
