using System;
using System.Collections.Generic;
using System.Linq;

namespace Linq
{
    class Joins
    {
        static void Main(string[] args)
        {
            IList<Department> departments = GetDepartments();
            IList<Employee> employees = GetEmployees();

            // inner join using Join
            var departmentEmployees = departments.Join(employees, d => d.Id, e => e.DepartmentId, (d, e) => new { DepartmentName = d.Name, EmployeeName = e.Name });
            //OR
            //var departmentEmployees = employees.Join(departments, e => e.DepartmentId, d => d.Id, (d, e) => new { DepartmentName = d.Name, EmployeeName = e.Name });

            //// left join using GroupJoin and SelectMany
            //var departmentEmployees = departments.GroupJoin(employees, d => d.Id, e => e.DepartmentId, (d, e) => new { tempDepartment = d, tempEmployees=e })
            //    .SelectMany(x=>x.tempEmployees.DefaultIfEmpty(),(d,e)=>new {DepartmentName=d.tempDepartment.Name,EmployeeName=e?.Name });

            //// right join ? confirm it's correct ?
            //var departmentEmployees = employees.GroupJoin(departments, e =>e.DepartmentId, d => d.Id, (d, e) => new { tempDepartment = d, tempEmployees = e })
            //    .SelectMany(x => x.tempEmployees.DefaultIfEmpty(), (d, e) => new { DepartmentName = d.tempDepartment.Name, EmployeeName = e?.Name });

            //// cross join using SelectMany
            //var departmentEmployees = departments.SelectMany(e => employees, (d, e) => new { DepartmentName = d.Name, EmployeeName = e.Name });

            foreach (var item in departmentEmployees)
            {
                Console.WriteLine($"Department: {item.DepartmentName} EmployeeName: {item.EmployeeName}");
            }

            Console.ReadKey();
        }

        private static IList<Department> GetDepartments()
        {
            return new List<Department>
            {
                new Department{Id=1,Name="IT"},
                new Department{Id=2,Name="Admin"},
                new Department{Id=3,Name="Accounts"},
                new Department{Id=4,Name="Support"},
                new Department{Id=5,Name="Callcenter"},
                new Department{Id=6,Name="HR"}

            };
        }

        private static IList<Employee> GetEmployees()
        {
            return new List<Employee>
            {
                new Employee{Id=1,Name="Steve",DepartmentId=4},
                new Employee{Id=2,Name="Smith",DepartmentId=2},
                new Employee{Id=3,Name="Devon",DepartmentId=1},
                new Employee{Id=4,Name="Alex",DepartmentId=6},
                new Employee{Id=5,Name="Bob",DepartmentId=1}
            };
        }
    }

    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int DepartmentId { get; set; }
    }
}
