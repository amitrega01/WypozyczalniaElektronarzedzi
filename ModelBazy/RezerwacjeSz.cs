//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ModelBazy
{
    using System;
    using System.Collections.Generic;
    
    public partial class RezerwacjeSz
    {
        public int IDRezerwacjiSz { get; set; }
        public Nullable<int> IDRezerwacji { get; set; }
        public Nullable<int> IDProduktuSZ { get; set; }
    
        public virtual ProduktySz ProduktySz { get; set; }
        public virtual Rezerwacje Rezerwacje { get; set; }
    }
}
