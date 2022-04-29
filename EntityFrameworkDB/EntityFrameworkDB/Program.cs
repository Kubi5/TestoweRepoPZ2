
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
                                join town in context.Towns
                                on adr.TownID equals town.TownID
                                group new { adr, emp, town } by new { adr.AddressText } into g
                                let r = g.FirstOrDefault()
                                orderby g.Count() descending, r.town.Name, r.adr.AddressText
                                select new
                                {
                                    addressText = r.adr.AddressText,
                                    count = g.Count(),
                                    townText = r.town.Name
                                };
                       
                foreach(var address in addresses.Take(10))
                {
                    Console.WriteLine(address.addressText + 
                        ", " + address.townText + " - " + address.count + " employee/s");
                }
                   */

                //ZADANIE 7

                /*
                var data = context.Employees
                    .Where(e => e.EmployeeID == 147)
                    .Select(e => new { e.FirstName, e.LastName, e.JobTitle,
                        lista = e.Projects.Select(f => f.Name).OrderBy(f => f).ToList() });

                foreach (var emp in data)
                {
                    Console.WriteLine(emp.FirstName + " " + emp.LastName + " - " + emp.JobTitle);

                    foreach(var pro in emp.lista)
                    {
                        Console.WriteLine(pro);
                    }
                }
                */

                //ZADANIE 8  (nie sortuje ze wzgl na il mieszkancow ?? )

                /*
                var list = context.Departments
                            .Select(x => new
                            {
                                workers = x.Employees1.Select(z => new { z.FirstName, z.LastName, z.JobTitle })
                                .OrderBy(z => z.FirstName).ThenBy(z => z.LastName).ToList(),
                                x.Employees.FirstName,
                                x.Employees.LastName,
                                name = x.Name,
                                count = x.Employees1.Count()
                            })
                            .OrderBy(x => x.count)
                            .ThenBy(x => x.name)
                            .Where(x => x.count > 5)
                            .GroupBy(x => x.name)
                            .ToList();
                            
                            
                foreach(var data in list)
                {
                    foreach(var item in data.ToList())
                    {
                        Console.WriteLine(item.name + " - " + item.FirstName + " " + item.LastName + " " + item.count);

                        foreach(var worker in item.workers)
                        {
                            Console.WriteLine(worker.FirstName + " " + worker.LastName + " - " + worker.JobTitle);
                        }

                        Console.WriteLine("----------");
                    }
                }
                */

                //ZADANIE 9

                /*
                var data = context.Projects
                            .Select(x => x)
                           .OrderByDescending(p => p.StartDate)
                           .Take(10)
                           .OrderBy(p => p.Name);

                foreach (var entity in data)
                {
                    Console.WriteLine($"{entity.Name} \n");
                    Console.WriteLine($"{entity.Description} \n");
                    Console.WriteLine($"{entity.StartDate} \n");
                }
                */

                //ZADANIE 10

                /*
                var EMPlist = context.Employees
                            .Join(context.Departments, e => e.DepartmentID, d => d.DepartmentID,
                            (e, d) => new { e.FirstName, e.LastName, e.Salary, d.Name, e.EmployeeID })
                            .OrderBy(x => x.FirstName)
                            .ThenBy(x => x.LastName)
                            .Where(x => x.Name == "Enginnering" || x.Name == "Tool Design" ||
                            x.Name == "Marketing" || x.Name == "Information Services")
                            .Select(x => x.EmployeeID);

                foreach(var data in EMPlist)
                {
                    context.Employees.Find(data).Salary *= (decimal)1.12;
                }
                context.SaveChanges();

                foreach (var entity in EMPlist)
                {
                    var data = context.Employees.Find(entity);
                    Console.WriteLine($"{data.FirstName} {data.LastName} (${Math.Round(data.Salary,2)})");
                }
                */

                //ZADANIE 11

                /*
                var data = context.Employees
                           .Where(x => x.FirstName.StartsWith("Sa"))
                           .Select(x => x)
                           .OrderBy(x => x.FirstName)
                           .ThenBy(x => x.LastName);

                foreach (var entity in data)
                {
                    Console.WriteLine($"{entity.FirstName} {entity.LastName} - " +
                        $"{entity.JobTitle} - (${Math.Round(entity.Salary,2)})");
                }
                */

                //ZADANIE 12
                /*
                context.Projects.Remove(context.Projects.Find(2));
                context.SaveChanges();



                foreach(var project in context.Projects.Take(10))
                {
                    Console.WriteLine($"{project.Name}   {project.ProjectID}");
                }
                */

                //ZADANIE 13

                string CitytoDelete = Console.ReadLine();

                var EMPdata = from emp in context.Employees
                              join adr in context.Addresses
                              on emp.AddressID equals adr.AddressID
                              join town in context.Towns
                              on adr.TownID equals town.TownID
                              where town.Name == CitytoDelete
                              select emp.EmployeeID;

                //ustawienie adresów ludzi na null
                foreach(var e in EMPdata)
                {
                    context.Employees.Find(e).AddressID = null;
                }

                //usuniecie tych adresow
                var addressesToDEL = from adr in context.Addresses
                                     join town in context.Towns
                                     on adr.TownID equals town.TownID
                                     where town.Name == CitytoDelete
                                     select adr.AddressID;

                int howManyAddressesWasDeleted = 0;
                foreach(var data in addressesToDEL)
                {
                    context.Addresses.Remove(context.Addresses.Find(data));
                    howManyAddressesWasDeleted++;
                }
                context.SaveChanges();

                //usunienie miasta

                Console.WriteLine($"Numbers of town in database before deleting: {context.Towns.Count()}");
                context.Towns.Remove(context.Towns.Where(x => x.Name == CitytoDelete).SingleOrDefault());

                context.SaveChanges();
                Console.WriteLine($"Numbers of town in database after deleting: {context.Towns.Count()}");


                //wyswietlenie na konsole
                if (howManyAddressesWasDeleted <= 1)
                {
                    Console.WriteLine($"{howManyAddressesWasDeleted} address in {CitytoDelete} was deleted");
                }
                else
                {
                    Console.WriteLine($"{howManyAddressesWasDeleted} addressess in {CitytoDelete} was deleted");
                }



            }
        }
    }
}
