using AdenyaDapperProject.Models;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AdenyaDapperProject.Controllers
{
    [SessionControl]
    public class BidController : Controller
    {
        private readonly Context _context;

        public BidController(Context context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var role = HttpContext.Session.GetString("Role");
            var userId = HttpContext.Session.GetInt32("UserId");

            if (role == "Admin")
            {
                var values = _context.Listele<BidModel>("BidList");
                return View(values);
            }
            else
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@UserId", userId);

                var values = _context.Listele<BidModel>("BidListByUser", param);
                return View(values);
            }
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Jobs = new SelectList(_context.Listele<JobModel>("JobList"), "JobId", "Title");
            ViewBag.Users = new SelectList(_context.Listele<UserModel>("UserList"), "UserId", "FullName");

            return View();
        }

        [HttpPost]
        public IActionResult Create(BidModel bid)
        {
            DynamicParameters param = new DynamicParameters();

            param.Add("@JobId", bid.JobId);
            param.Add("@UserId", bid.UserId);
            param.Add("@Price", bid.Price);
            param.Add("@Message", bid.Message);

            _context.Execute("BidAdd", param);

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@BidId", id);

            _context.Execute("BidDelete", param);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@BidId", id);

            var value = _context.Getir<BidModel>("BidGetById", param);

            ViewBag.Jobs = new SelectList(_context.Listele<JobModel>("JobList"), "JobId", "Title");
            ViewBag.Users = new SelectList(_context.Listele<UserModel>("UserList"), "UserId", "FullName");

            return View(value);
        }

        [HttpPost]
        public IActionResult Edit(BidModel bid)
        {
            DynamicParameters param = new DynamicParameters();

            param.Add("@BidId", bid.BidId);
            param.Add("@JobId", bid.JobId);
            param.Add("@UserId", bid.UserId);
            param.Add("@Price", bid.Price);
            param.Add("@Message", bid.Message);

            _context.Execute("BidUpdate", param);

            return RedirectToAction("Index");
        }
    }
}