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
    
    public partial class Request
    {
        public int Request_ID { get; set; }
        public int Seeker_ID { get; set; }
        public int Owner_ID { get; set; }
        public int Ad_ID { get; set; }
        public Nullable<System.DateTime> Request_Date { get; set; }
        public Nullable<bool> Is_Accept { get; set; }
    }
}
