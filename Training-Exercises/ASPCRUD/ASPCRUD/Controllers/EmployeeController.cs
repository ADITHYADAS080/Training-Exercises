using ASPCRUD.DAL;
using ASPCRUD.Models;
using Microsoft.AspNetCore.Mvc;

namespace ASPCRUD.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly Employee_DAL _dal;

        public EmployeeController(Employee_DAL dal)
        {
            _dal = dal;
        }

        // Get All employees


        [HttpGet]
        public IActionResult Index()
        {
            List<Employee> employee = new List<Employee>();
            try
            {
                employee = _dal.GetAllEmployees();
            }
            catch(Exception Ex) 
            {
                TempData["ErrorMessage"] = Ex.Message;
            }
            return View(employee);
        }

        //insert new employees


        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }


        //insert new employee


        [HttpPost]
        public IActionResult Create(Employee employee)
        {
            if (!ModelState.IsValid)
            {
                TempData["ErrorMessage"] = "Model data is invalid";
            }
            bool result = _dal.InsertEmployee(employee);
            if (!result)
            {
                TempData["ErrorMessage"] = "Unable to save data";
                return View();

            }
            TempData["Succes"] = "Employee details saved";
            return RedirectToAction("Index");
        }

        //get Employee details

        [HttpGet]
        public IActionResult Details(int id)
        {
            Employee employee = _dal.GetEmployeeById(id);
            if (employee.EmployeeId == 0)
            {
                TempData["ErrorMessage"] = "no employee";
                return RedirectToAction("Index");
            }
            return View(employee);
        }

        //Get employee detail to edit


        [HttpGet]
        public IActionResult Edit(int id)
        {
            Employee employee = _dal.GetEmployeeById(id);
            if (employee.EmployeeId == 0)
            {
                TempData["ErrorMessage"] = "no employee";
                return RedirectToAction("Index");
            }
            return View(employee);
        }

        //Edit employee details


        [HttpPost ]
        public IActionResult Edit(Employee employee)
        {
            if (!ModelState.IsValid)
            {
                TempData["ErrorMessage"] = "no employee";
                return View();
            }
            bool result = _dal.Update(employee);
            if (!result)
            {
                TempData["ErrorMessage"] = "error";
            }
            return RedirectToAction("Index");
        }

        //get delete employee id
        [HttpGet]
        public IActionResult Delete(int id)
        {
            Employee employee = _dal.GetEmployeeById(id);
            if (employee.EmployeeId == 0)
            {
                TempData["ErrorMessage"] = "no employee found";
            }
            return View(employee);
        }
        //Delete employee

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmation(int id)
        {
            bool result = _dal.DeletEmployee(id);

            if (!result)
            {
                TempData["ErrorMessage"] = "No employee found";
                return RedirectToAction("Index");
            }
            TempData["SuccessMessage"] = "Employee deleted successfully";
            return RedirectToAction("Index");
        }

    }
}
