//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class HallOfFame
    {
        public string hofID { get; set; }
        public int yearID { get; set; }
        public string votedBy { get; set; }
        public Nullable<int> ballots { get; set; }
        public Nullable<int> needed { get; set; }
        public Nullable<int> votes { get; set; }
        public string inducted { get; set; }
        public string category { get; set; }
        public string needed_note { get; set; }
    }
}
