using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BeltExam.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BeltExam.Controllers
{
    [Route("hobbys")]
    public class HobbyController : Controller
    {
        private HomeContext dbContext;
        public HobbyController(HomeContext context)
        {
            dbContext = context;
        }

        [HttpGet("dashboard")]
        public IActionResult Dashboard()
        {
            if(HttpContext.Session.GetString("UserName") == null)
          {
              return RedirectToAction("LogOut", "Home");
          }
          else
          {
              User userInDb = dbContext.Users.Include(u => u.CoolHobbies).FirstOrDefault(u => u.UserName == HttpContext.Session.GetString("UserName"));
              ViewBag.User = userInDb;

              List<Hobby> AllHobbies = dbContext.Hobbies.Include(h => h.Enthusiasts).ThenInclude(a => a.Fan).ToList();
              return View(AllHobbies);
          }
        }

        [HttpGet("new")]
        public IActionResult New()
        {
            if(HttpContext.Session.GetString("UserName") == null)
            {
                return RedirectToAction("LogOut", "Home");
            }
            else
            {
                User userInDb = dbContext.Users.Include(u => u.CoolHobbies).FirstOrDefault(u => u.UserName == HttpContext.Session.GetString("UserName"));
                ViewBag.User = userInDb;
                return View();
            }
        }

        [HttpPost("create")]
        public IActionResult Create(Hobby hob)
        {
            if(HttpContext.Session.GetString("UserName") == null)
            {
                return RedirectToAction("LogOut", "Home");
            }
            else
            {
                if(ModelState.IsValid)
                {
                    dbContext.Hobbies.Add(hob);
                    dbContext.SaveChanges();
                    return Redirect($"Show/{hob.HobbyId}");
                }
                else
                {
                    User userInDb = dbContext.Users.Include(u => u.CoolHobbies).FirstOrDefault(u => u.UserName == HttpContext.Session.GetString("UserName"));
                    ViewBag.User = userInDb;
                    return View("New");
                }
            }
        }

        [HttpGet("show/{hobbyId}")]
        public IActionResult Show(int hobbyId)
        {
            if(HttpContext.Session.GetString("UserName") == null)
            {
                return RedirectToAction("LogOut", "Home");
            }
            else
            {
                User userInDb = dbContext.Users.Include(u => u.CoolHobbies).FirstOrDefault(u => u.UserName == HttpContext.Session.GetString("UserName"));
                ViewBag.User = userInDb;

                Hobby show = dbContext.Hobbies.Include(h => h.Enthusiasts).ThenInclude(a => a.Fan).FirstOrDefault(u => u.HobbyId == hobbyId);
                ViewBag.Fans = dbContext.Hobbies;
                return View(show);
            }
        }

        [HttpGet("cool/{hobbyId}/{userId}/{status}")]

        public IActionResult AddHobby(int hobbyId, int userId, string status)
        {
            if(HttpContext.Session.GetString("UserName") == null)
            {
                return RedirectToAction("LogOut", "Home");
            }
            else
            {
                if(status == "add")
                {
                    Association join = new Association();
                    join.HobbyId = hobbyId;
                    join.UserID = userId;
                    dbContext.Associations.Add(join);
                    dbContext.SaveChanges();
                }

                return RedirectToAction("Dashboard");
            }
        }



    }
}