using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Linq;
using MovieApp.Core.Entities;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using MovieApp.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using MovieApp.Web.ViewModels;

namespace MovieApp.Web.Controllers
{
    public class AccountController : Controller
    {
        private ApplicationContext db;
        public AccountController(ApplicationContext context)
        {
            db = context;
        }

        [HttpGet("login")]
        public IActionResult Login()
        {
            if (User.Identity.IsAuthenticated)
            {
                /*Role. (User.Identity.Name, "admin");*/
                //todo change this redirect
                return RedirectToAction("Index", User.IsInRole("admin") ? "Panel" : "Account");
            }

            return View();
        }

        public IActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                ViewBag.Name = User.Identity.Name;
                /*Role. (User.Identity.Name, "admin");*/
                if (User.IsInRole("admin")) return LocalRedirect("~/Dashboard/Home");

                return View();
            }

            return RedirectToAction("Login", "Account");
        }

        [HttpPost("login")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                User user = await db.Users
                    .Include(u => u.Role)
                    .FirstOrDefaultAsync(u => u.Email == model.Email && u.Password == model.Password);
                
                if (user != null)
                {
                    await Authenticate(user);
                    return LocalRedirect("~/Dashboard/Home");
                    //return RedirectToAction("Index", user.Role.Name == "admin" ? "Panel" : "Account");
                }

                ModelState.AddModelError("", "Некорректные логин и(или) пароль");
            }

            return View(model);
        }

        [HttpGet("register")]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                User user = await db.Users.FirstOrDefaultAsync(u => u.Email == model.Email);
                if (user == null)
                {
                    user = new User { Email = model.Email, Password = model.Password, Login = model.Login };
                    Role userRole = await db.Roles.FirstOrDefaultAsync(r => r.Name == "user");
                    if (userRole != null)
                        user.Role = userRole;

                    db.Users.Add(user);

                    await db.SaveChangesAsync();

                    await Authenticate(user);

                    return RedirectToAction("Index", "Account");
                }
                else
                {
                    ModelState.AddModelError("", "Некорректные логин и(или) пароль");
                }
            }

            return View(model);
        }

        [HttpGet("logout")]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return RedirectToAction("Login", "Account");
        }

        private async Task Authenticate(User user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, user.Email),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, user.Role?.Name)
            };
            
            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType,
                ClaimsIdentity.DefaultRoleClaimType);
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }
    }
}
