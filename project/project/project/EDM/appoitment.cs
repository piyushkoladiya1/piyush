//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace project.EDM
{
    using System;
    using System.Collections.Generic;
    
    public partial class appoitment
    {
        public int appoitment_id { get; set; }
        public Nullable<System.DateTime> appoitment_date_time { get; set; }
        public string appoitment_status { get; set; }
        public Nullable<int> hospital_id { get; set; }
        public Nullable<int> doctor_id { get; set; }
        public Nullable<int> patient_id { get; set; }
    
        public virtual doctor doctor { get; set; }
        public virtual hospital hospital { get; set; }
        public virtual patient patient { get; set; }
    }
}
