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
    
    public partial class Pracownicy
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Pracownicy()
        {
            this.WypozyczenieSz = new HashSet<WypozyczenieSz>();
            this.WypozyczenieSz1 = new HashSet<WypozyczenieSz>();
        }
    
        public string PESEL { get; set; }
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public string Haslo { get; set; }
        public System.DateTime DataZatrudnienia { get; set; }
        public Nullable<int> IDPunktuObslugi { get; set; }
    
        public virtual PunktyObslugi PunktyObslugi { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<WypozyczenieSz> WypozyczenieSz { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<WypozyczenieSz> WypozyczenieSz1 { get; set; }
    }
}
