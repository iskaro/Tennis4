//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Tennis4.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Competition
    {
        public Competition()
        {
            this.CompetitionRow = new HashSet<CompetitionRow>();
        }
    
        public int ID { get; set; }
        public string CompetitionName { get; set; }
    
        public virtual ICollection<CompetitionRow> CompetitionRow { get; set; }
    }
}
