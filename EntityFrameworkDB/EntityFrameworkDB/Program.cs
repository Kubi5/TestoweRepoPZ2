
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
            SoftUniEntities context = new SoftUniEntities();
            using (context)
            {

                //ZADANIE 1
                /*
                foreach (var c in context.Employees)
                {
                    Console.WriteLine(c.FirstName + " " + c.LastName + " " + c.MiddleName + " " +
                        c.JobTitle + " " + Math.Round(c.Salary,2));
                }
                */

                //ZADANIE 2

                /*
                var EmployeeNames = context.Employees
                    .Where(e => e.Salary > 50000)
                    .OrderBy(e => e.FirstName)
                    .Select(e => e.FirstName + " " + e.Salary);

                foreach(var Employee in EmployeeNames)
                {
                    Console.WriteLine(Employee);
                }
                */

                //ZADANIE 3

                /*
                var selectedEmployees = from e in context.Employees
                                        join d in context.Departments
                                        on e.DepartmentID equals d.DepartmentID
                                        where d.Name == "Research and Development"
                                        orderby e.Salary ascending, e.FirstName descending
                                        select e.FirstName + " " + e.LastName + " from " + d.Name + 
                                        " - " + Math.Round(e.Salary,2);

                foreach (var employee in selectedEmployees)
                {
                    Console.WriteLine(employee);
                }
                
                */

                //ZADANIE 4

                /*
                Addresses newAddress = new Addresses
                {
                    AddressID = 501,
                    AddressText = "Warszawa, Krakowska 41"
                };

                Console.WriteLine(context.Addresses.Count().ToString());
                context.Addresses.Add(newAddress);
                context.SaveChanges();
                Console.WriteLine(context.Addresses.Count().ToString());
                */
                /*
                
                //biore id pracownika do zmiany
                var NakovID = from emp in context.Employees
                              where emp.LastName == "Nakov"
                              select emp.EmployeeID;
                
                //wsrod tych id modyfikuje dane pole w innej tabeli
                foreach (var itemID in NakovID)
                {
                    var EmployeetoUpdate = context.Employees
                    .Include("Addresses")
                    .Where(x => x.EmployeeID.Equals(itemID))
                    .First();
                        EmployeetoUpdate.Addresses.AddressText = "Góralska 43, Chocznia";
                }

                //zapisuje zmiany
                context.SaveChanges();
               

                //sprawdzam czy dziala
                var employees = from emp in context.Employees
                                join adr in context.Addresses
                                on emp.AddressID equals adr.AddressID
                                where emp.LastName == "Nakov"
                                select emp.LastName + " " + adr.AddressText + " " + adr.TownID;
                   
                foreach (var employee in employees)
                {
                     Console.WriteLine(employee);
                }
                */


                //ZADANIE 5
                /*
                int counter = 0;
                DateTime d2001 = new DateTime(2001, 1, 1, 0, 0, 0);
                DateTime d2003 = new DateTime(2003, 12, 31, 23, 59, 59);
               
                
                foreach(var emp in context.Employees)
                {
                    if (emp.Projects.Count > 0)
                    {
                        
                        Console.WriteLine(emp.FirstName + " " + emp.LastName +
                            " - Menager: " + emp.Employees2.FirstName + " " + emp.Employees2.LastName);

                        var projects = from pro in emp.Projects
                                       where pro.StartDate >= d2001 && pro.StartDate <= d2003
                                       select pro;

                        foreach (var project in projects)
                        {
                            if (project.EndDate == null)
                            {
                                Console.WriteLine("-- " + project.Name + " - "
                                    + project.StartDate + " - not finished");
                            }
                            else
                            {
                                Console.WriteLine("-- " + project.Name + " - "
                                    + project.StartDate + " - " + project.EndDate);
                            }
                        }
                    }
                    counter++;
                    if(counter == 30)
                    {
                        break;
                    }
                }
                    */

                //ZADANIE 6
                /*
                var addresses = from adr in context.Addresses
                                join emp in context.Employees
                                on adr.AddressID equals emp.AddressID
                                group new { adr, emp } by new { adr.AddressText } into g
                                let r = g.FirstOrDefault()
                                orderby g.Count() descending
                                select new
                                {
                                    addressText = r.adr.AddressText,
                                    count = g.Count()
                                    
                                };
                       
                foreach(var address in addresses.Take(10))
                {
                    Console.WriteLine(address.addressText + " - " + address.count + " employee/s");
                }
                    */
                
                //ZADANIE 7


            


            }
        }
    }
}
