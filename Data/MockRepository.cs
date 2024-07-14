using System.Collections.Generic;
using System.Linq;
using EmployeeCrudManagement.Models;

namespace EmployeeCrudManagement.Data
{
    public static class MockRepository
    {
        private static List<Employee> _employees = new List<Employee>
        {
            new Employee { Id = 1, FirstName = "Purvi", LastName = "Patil", Position = "Developer" },
            new Employee { Id = 2, FirstName = "Shivam", LastName = "Patel", Position = "Designer" },
        };

        public static IEnumerable<Employee> GetAllEmployees()
        {
            return _employees;
        }

        public static Employee GetEmployeeById(int id)
        {
            return _employees.FirstOrDefault(e => e.Id == id);
        }

        public static void AddEmployee(Employee employee)
        {
            employee.Id = _employees.Max(e => e.Id) + 1;
            _employees.Add(employee);
        }

        public static void UpdateEmployee(Employee updatedEmployee)
        {
            var existingEmployee = _employees.FirstOrDefault(e => e.Id == updatedEmployee.Id);
            if (existingEmployee != null)
            {
                existingEmployee.FirstName = updatedEmployee.FirstName;
                existingEmployee.LastName = updatedEmployee.LastName;
                existingEmployee.Position = updatedEmployee.Position;
            }
        }

        public static void DeleteEmployee(int id)
        {
            var employeeToRemove = _employees.FirstOrDefault(e => e.Id == id);
            if (employeeToRemove != null)
            {
                _employees.Remove(employeeToRemove);
            }
        }
    }
}
