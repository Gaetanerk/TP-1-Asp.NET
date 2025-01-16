using Microsoft.AspNetCore.Mvc;
using TPTodoList.Data;
using TPTodoList.Models;

namespace TPTodoList.Controllers
{
    public class AuthController : Controller
    {
        private readonly TPTodoListContext _context;

        public AuthController(TPTodoListContext context)
        {
            _context = context;
        }
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            var user = _context.Users.FirstOrDefault(u => u.Username == username && u.Password == password);

            if (user != null)
            {
                HttpContext.Session.SetString("Username", user.Username);
                return RedirectToAction("Index", "TodoLists");
            }

            ViewBag.Message = "Nom d'utilisateur ou mot de passe incorrect";
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Register(string username, string password)
        {
            var user = new User
            {
                Username = username,
                Password = password
            };
            _context.Users.Add(user);
            _context.SaveChanges();
            return RedirectToAction("Login");
        }
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }
    }
}
