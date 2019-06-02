using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeUWPApp
{
    class Employee
    {
        private const string TEXT_FILE_NAME = "Employee.txt";
        public string Name { get; set; }
        public string Title { get; set; }

        public async static Task<ICollection<Employee>> GetEmployeesAsync()
        {
            //deserialize
            var employees = new List<Employee>(); //array
            var content = await FileHelper.ReadTextFileAsync(TEXT_FILE_NAME);
            var lines = content.Split('\r', '\n'); //separate each row.
            foreach (var line in lines)
            {
                if (string.IsNullOrEmpty(line))
                    continue;
                var lineParts = line.Split(','); //split each row.
                var employee = new Employee
                {
                    Name = lineParts[0],
                    Title = lineParts[1]
                };
                employees.Add(employee);
            }

            var emp = new Employee
            {
                Name = "Daniela Sanchez",
                Title = "CEO"
            };
            return employees;
        }

        //Click of buttin will create serialization (Object to string)
        //Write method
        public static void WriteEmployee(Employee employee)
        {
            var employeeData = $"{employee.Name}, {employee.Title}";
            FileHelper.WriteTextFileAsync(TEXT_FILE_NAME, employeeData);
        }
    }
}
