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
    
    public partial class PunktyObslugi
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PunktyObslugi()
        {
            this.Pracownicies = new HashSet<Pracownicy>();
            this.ProduktySzs = new HashSet<ProduktySz>();
        }
    
        public int IDPunktuObslugi { get; set; }
        public string Ulica { get; set; }
        public string NrDomu { get; set; }
        public string Miasto { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Pracownicy> Pracownicies { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProduktySz> ProduktySzs { get; set; }
    }
}
