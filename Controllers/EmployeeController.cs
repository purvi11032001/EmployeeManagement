using Microsoft.AspNetCore.Mvc;
using EmployeeCrudManagement.Models;
using EmployeeCrudManagement.Data;

namespace EmployeeCrudManagement.Controllers
{
    public class EmployeeController : Controller
    {
        public IActionResult Index()
        {
            var employees = MockRepository.GetAllEmployees();
            return View(employees);
        }

        public IActionResult Details(int id)
        {
            var employee = MockRepository.GetEmployeeById(id);
            return View(employee);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Employee employee)
        {
            if (ModelState.IsValid)
            {
                MockRepository.AddEmployee(employee);
                return RedirectToAction(nameof(Index));
            }
            return View(employee);
        }

        public IActionResult Edit(int id)
        {
            var employee = MockRepository.GetEmployeeById(id);
            return View(employee);
        }

        [HttpPost]
        public IActionResult Edit(Employee updatedEmployee)
        {
            if (ModelState.IsValid)
            {
                MockRepository.UpdateEmployee(updatedEmployee);
                return RedirectToAction(nameof(Index));
            }
            return View(updatedEmployee);
        }

        public IActionResult Delete(int id)
        {
            var employee = MockRepository.GetEmployeeById(id);
            return View(employee);
        }

        [HttpPost]
        public IActionResult DeleteConfirmed(int id)
        {
            MockRepository.DeleteEmployee(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
