//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EczaneMesaj.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Tbl_Message
    {
        public int MessageID { get; set; }
        public byte Sender { get; set; }
        public byte Receiver { get; set; }
        public string Context { get; set; }
        public System.DateTime MessageDate { get; set; }
        public bool Status { get; set; }
        public bool ReadStatus { get; set; }
        public bool Unnecessary { get; set; }
    
        public virtual Tbl_User Tbl_User { get; set; }
        public virtual Tbl_User Tbl_User1 { get; set; }
    }
}
