//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace doctor_fonder.EDM
{
    using System;
    using System.Collections.Generic;
    
    public partial class doctor
    {
        public int doctor_id { get; set; }
        public string f_name { get; set; }
        public string l_name { get; set; }
        public string email { get; set; }
        public string contact_no { get; set; }
        public Nullable<int> degree_id { get; set; }
        public Nullable<int> speciality_id { get; set; }
        public Nullable<int> hospital_id { get; set; }
        public string profile_img { get; set; }
    
        public virtual degree degree { get; set; }
        public virtual hospital hospital { get; set; }
        public virtual specility specility { get; set; }
    }
}
