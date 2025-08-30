using FinanceApp.Data;
using Microsoft.AspNetCore.Mvc;
using FinanceApp.Models;
using Microsoft.EntityFrameworkCore;
using FinanceApp.Data.Services;


namespace FinanceApp.Controllers
{
    public class ExpensesController : Controller
    {
        private readonly IExpensesService _expesesService;


        public ExpensesController(IExpensesService expesesService)
        {
            _expesesService = expesesService;
        }
        public async Task<IActionResult> Index()
        {
            var expenses = await _expesesService.GetAll();
            return View(expenses);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Expense expense)
        {
            if (ModelState.IsValid)
            {
                await _expesesService.Add(expense);
                return RedirectToAction("Index");
            }
            return View(expense);
        }
        
        public IActionResult GetChart()
        {
            var data = _expesesService.GetChartData();
            return Json(data);
        }
    }
}
