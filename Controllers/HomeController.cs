using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BeltExam.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;

namespace BeltExam.Controllers
{
    public class HomeController : Controller
    {
        private HomeContext dbContext;
        public HomeController(HomeContext context)
        {
            dbContext = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet("signin")]
        public IActionResult SignIn()
        {
            return View();
        }

        [HttpPost("register")]
        public IActionResult Register(User register)
        {
            if(ModelState.IsValid)
            {
                if(dbContext.Users.Any(u => u.UserName == register.UserName))
                {
                    ModelState.AddModelError("UserName", "That Username is already in use");
                    return View("Index");
                }
                else
                {
                    PasswordHasher<User> Hasher = new PasswordHasher<User>();
                    register.Password = Hasher.HashPassword(register, register.Password);
                    dbContext.Users.Add(register);
                    dbContext.SaveChanges();
                    HttpContext.Session.SetString("UserName", register.UserName);
                    return RedirectToAction("Dashboard", "Hobby");
                }
            }
            else
            {
                return View("Index");
            }
        }
        [HttpPost("login")]
        public IActionResult LogIn(LoginUser login)
        {
            if(ModelState.IsValid)
            {
                User userInDb = dbContext.Users.FirstOrDefault(u => u.UserName == login.LogInUser);
                if(userInDb == null)
                {
                    ModelState.AddModelError("Login", "Invalid Email or Password");
                    return View("SignIn");
                }
                PasswordHasher<LoginUser> hasher = new PasswordHasher<LoginUser>();
                var result = hasher.VerifyHashedPassword(login, userInDb.Password, login.LogInPassword);
                if(result == 0)
                {
                    ModelState.AddModelError("LoginUser", "Invalid usenname or Password");
                    return View("SignIn");
                }
                HttpContext.Session.SetString("UserName", login.LogInUser);
                return RedirectToAction("Dashboard", "Hobby");
            }
            else
            {
                return View("SignIn");
            }
        }

        [HttpGet("logout")]
        public IActionResult LogOut()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
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
