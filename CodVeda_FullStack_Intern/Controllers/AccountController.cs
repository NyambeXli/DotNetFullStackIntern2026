using Microsoft.AspNetCore.Mvc;
using CodVeda_FullStack_Intern.Models;
using CodVeda_FullStack_Intern.Data;
using Microsoft.AspNetCore.Http;
using System.Linq;

namespace CodVeda_FullStack_Intern.Controllers
{
    public class AccountController : Controller
    {
        private readonly ApplicationDbContext _context;
        
        public AccountController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(User newUser)
        {
            if (ModelState.IsValid)
            {
                _context.Users.Add(newUser);
                _context.SaveChanges(); 
                return RedirectToAction("Login");
            }
            return View(newUser);
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string email, string password)
        {
            var user = _context.Users.FirstOrDefault(u => u.Email == email && u.Password == password);

            if (user != null)
            {
                HttpContext.Session.SetString("UserName", user.FullName);
                return RedirectToAction("Index", "Home");
            }

            ViewBag.ErrorMessage = "Invalid Login Attempt";
            return View();
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }
    }
}
