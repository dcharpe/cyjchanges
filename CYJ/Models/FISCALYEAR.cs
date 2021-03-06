//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CYJ.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;

    public partial class FISCALYEAR
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public FISCALYEAR()
        {
            this.CHARTs = new HashSet<CHART>();
            this.GOALACTUALs = new HashSet<GOALACTUAL>();
            this.QUARTEROPTIONs = new HashSet<QUARTEROPTION>();
        }

        [DisplayName("Fiscal Year")]
        public int fiscalYearID { get; set; }
        public Nullable<int> quarteroptionID { get; set; }
        public Nullable<int> subcategoryID { get; set; }
        [DisplayName("Fiscal Year")]
        public Nullable<int> fy { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CHART> CHARTs { get; set; }
        public virtual QUARTEROPTION QUARTEROPTION { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GOALACTUAL> GOALACTUALs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<QUARTEROPTION> QUARTEROPTIONs { get; set; }
    }
}
