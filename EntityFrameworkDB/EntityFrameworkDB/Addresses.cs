//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EntityFrameworkDB
{
    using System;
    using System.Collections.Generic;
    
    public partial class Addresses
    {
        public Addresses()
        {
            this.Employees = new HashSet<Employees>();
        }
    
        public int AddressID { get; set; }
        public string AddressText { get; set; }
        public Nullable<int> TownID { get; set; }
    
        public virtual Towns Towns { get; set; }
        public virtual ICollection<Employees> Employees { get; set; }
    }
}