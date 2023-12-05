using ASPNETCore6.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ASPNETCore6.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IDeptRepository _deptRepository;

        public HomeController(ILogger<HomeController> logger, IDeptRepository deptRepository)
        {
            _logger = logger;
            _deptRepository = deptRepository;
        }
        public IActionResult Index()
        {

            //IEnumerable<TestDept> result = _deptRepository.GetAllDepts();
            //var result = _deptRepository.GetAllDeptsByStoredProcedure();
            var result = _deptRepository.GetAllDeptsCustomStoredProcedure();
            ViewBag.depts = result;
            var t = "rohit";
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}