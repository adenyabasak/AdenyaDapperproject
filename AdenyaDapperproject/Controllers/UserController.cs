using AdenyaDapperProject.Models;
using Dapper;
using Microsoft.AspNetCore.Mvc;

namespace AdenyaDapperProject.Controllers


    

{
    [SessionControl]
    public class UserController : Controller
    {
        private readonly Context _context;

        public UserController(Context context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var values = _context.Listele<UserModel>("UserList");
            return View(values);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(UserModel user)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@FullName", user.FullName);
            param.Add("@Email", user.Email);
            param.Add("@Password", user.Password);
            param.Add("@Role", user.Role);

            _context.Execute("UserAdd", param);

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@UserId", id);

            _context.Execute("UserDelete", param);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@UserId", id);

            var value = _context.Getir<UserModel>("UserGetById", param);
            return View(value);
        }

        [HttpPost]
        public IActionResult Edit(UserModel user)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@UserId", user.UserId);
            param.Add("@FullName", user.FullName);
            param.Add("@Email", user.Email);
            param.Add("@Password", user.Password);
            param.Add("@Role", user.Role);

            _context.Execute("UserUpdate", param);

            return RedirectToAction("Index");
        }
    }
}