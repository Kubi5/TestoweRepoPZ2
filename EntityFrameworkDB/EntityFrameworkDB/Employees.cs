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
    
    public partial class Employees
    {
        public Employees()
        {
            this.Departments = new HashSet<Departments>();
            this.Employees1 = new HashSet<Employees>();
            this.Projects = new HashSet<Projects>();
        }
    
        public int EmployeeID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string JobTitle { get; set; }
        public int DepartmentID { get; set; }
        public Nullable<int> ManagerID { get; set; }
        public System.DateTime HireDate { get; set; }
        public decimal Salary { get; set; }
        public Nullable<int> AddressID { get; set; }
    
        public virtual Addresses Addresses { get; set; }
        public virtual ICollection<Departments> Departments { get; set; }
        public virtual Departments Departments1 { get; set; }
        public virtual ICollection<Employees> Employees1 { get; set; }
        public virtual Employees Employees2 { get; set; }
        public virtual ICollection<Projects> Projects { get; set; }
    }
}
