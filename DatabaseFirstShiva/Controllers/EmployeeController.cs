using Microsoft.AspNetCore.Mvc;
using DatabaseFirstShiva.Models;
using Microsoft.EntityFrameworkCore;

namespace DatabaseFirstShiva.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly EmployeeDbContext _dbContext;
        public EmployeeController(EmployeeDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IActionResult> Index()
        {
            var employees = await _dbContext.Employees.ToListAsync();
            return View(employees);
        }
        public IActionResult Create() => View();

        [HttpPost]
        public async Task<IActionResult> Create(Employee empObj)
        {
            if (ModelState.IsValid)
            {
                _dbContext.Add(empObj);
                int n = await _dbContext.SaveChangesAsync();
                if (n != 0)
                {
                    TempData["insert"] = "<script>alert('Employee Added SuccessFully!');</script>";
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["insert"] = "<script>alert('Employee Failed!');</script>";
                }
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Error in Model!!");
            }
            return View();
        }
        public async Task<IActionResult> Edit(int id)
        {
            var employee = await _dbContext.Employees.Where(m => m.Eid == id).FirstOrDefaultAsync();
            return View(employee);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Employee empObj)
        {
            if (ModelState.IsValid)
            {
                _dbContext.Entry(empObj).State = EntityState.Modified;
                int n = await _dbContext.SaveChangesAsync();
                if (n != 0)
                {
                    TempData["update"] = "<script>alert('Employee Updated SuccessFully!');</script>";
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["update"] = "<script>alert('Employee Failed!');</script>";
                }
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Error in Model!!");
            }
            return View();
        }
        public async Task<IActionResult> Details(int id)
        {
            var employee = await _dbContext.Employees.Where(m => m.Eid == id).FirstOrDefaultAsync();
            return View(employee);
        }
        public async Task<IActionResult> Delete(int id)
        {
            var employee = _dbContext.Employees.Where(m => m.Eid == id).FirstOrDefault();
            if (employee != null)
            {
                _dbContext.Employees.Remove(employee);
                int n = await _dbContext.SaveChangesAsync();
                if (n != 0)
                {
                    TempData["delete"] = "<script>alert('Employee Deleted SuccessFully!');</script>";
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["delete"] = "<script>alert('Employee Failed!');</script>";
                }
            }
            return View();
        }
    }
}
