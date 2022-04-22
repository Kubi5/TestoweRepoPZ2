using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkDB
{
    internal class Program
    {
        static void Main(string[] args)
        {
           SoftUniEntities softUniEntities = new SoftUniEntities();
            using (softUniEntities)
            {

                //ZADANIE 1
                /*
                foreach (var c in softUniEntities.Employees)
                {
                    Console.WriteLine(c.FirstName + " " + c.LastName + " " + c.MiddleName + " " +
                        c.JobTitle + " " + Math.Round(c.Salary,2));
                }
                */

                //ZADANIE 2

                /*
                var EmployeeNames = softUniEntities.Employees
                    .Where(e => e.Salary > 50000)
                    .OrderBy(e => e.FirstName)
                    .Select(e => e.FirstName + " " + e.Salary);

                foreach(var Employee in EmployeeNames)
                {
                    Console.WriteLine(Employee);
                }
                */

                //ZADANIE 3

                var selectedEmployees = softUniEntities.Employees
                    .Select(e => e.FirstName + " " + e.LastName + " " + e.Departments.)

                




             }
        }
    }
}
