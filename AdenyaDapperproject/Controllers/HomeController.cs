using AdenyaDapperproject.Models;
using AdenyaDapperProject.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AdenyaDapperproject.Controllers
{
    public class HomeController : Controller
    {
        private readonly Context _context;

        public HomeController(Context context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var jobs = _context.Listele<JobModel>("JobList");
            return View(jobs);
        }

        public IActionResult Jobs()
        {
            var jobs = _context.Listele<JobModel>("JobList");
            return View(jobs);
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Contact()
        {
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