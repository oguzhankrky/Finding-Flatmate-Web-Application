//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DBMS.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Member
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Member()
        {
            this.Phone = new HashSet<Phone>();
        }
    
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Social_ID { get; set; }
        public string Email { get; set; }
        public bool Member_Type { get; set; }
        public System.DateTime Birthdate { get; set; }
        public bool Gender { get; set; }
        public Nullable<int> House_ID { get; set; }
        public Nullable<int> Seek_ID { get; set; }
        public string Password { get; set; }
        public int Member_Index { get; set; }
        public string M_Phone { get; set; }
        public string Member_bio { get; set; }
        public byte[] Member_picture { get; set; }
    
        public virtual House House { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Phone> Phone { get; set; }
        public virtual Seek Seek { get; set; }
    }
}
