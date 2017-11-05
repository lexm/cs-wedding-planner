using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using wplan.Models;

namespace wplan.Controllers
{
    public class UserController : Controller
    {
        private WPlanContext _context;

        public UserController(WPlanContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("")]
        public IActionResult LogReg()
        {
            return View();
        }

        [HttpPost]
        [Route("register")]
        public IActionResult Register(UserViewModel user)
        {
            System.Console.WriteLine("start");
            if(ModelState.IsValid)
            {
                System.Console.WriteLine("valid");
                string UserEmail = user.email;
                User LookupUser = _context.users.SingleOrDefault(login => login.email == UserEmail);
                if(LookupUser == null)
                {
                    PasswordHasher<UserViewModel> Hasher = new PasswordHasher<UserViewModel>();
                    user.password = Hasher.HashPassword(user, user.password);
                    System.Console.WriteLine("length is {0}", user.password.Length);
                    User NewUser = new User
                    {
                        firstname = user.firstname,
                        lastname = user.lastname,
                        email = user.email,
                        password = user.password
                    };
                    _context.Add(NewUser);
                    _context.SaveChanges();
                    System.Console.WriteLine("Iz guud!");
                    return RedirectToAction("Success");
                }
                else
                {
                    ModelState.AddModelError("email", "This Email is already registered.");
                    ViewBag.errors = ModelState.Values; 
                    return View("~/Views/User/LogReg.cshtml", user);
                }
            }
            else
            {
                System.Console.WriteLine("Iz nah guud.");
                return View("~/Views/User/LogReg.cshtml", user);
            }
        }

        [HttpPost]
        [Route("Login/login")]
        public IActionResult Login(UserViewModel user)
        {
            string UserEmail = user.email;
            User LookupUser = _context.users.SingleOrDefault(login => login.email == UserEmail);
            if(LookupUser != null)
            {
                PasswordHasher<UserViewModel> Hasher = new PasswordHasher<UserViewModel>();
                string CheckPassword = Hasher.HashPassword(user, user.password);
                if(LookupUser.password == CheckPassword)
                {
                    return RedirectToAction("Success");
                }
            }
            ModelState.AddModelError("password", "User/password mismatch");
            ViewBag.errors = ModelState.Values;
            return View("~/Views/User/LogReg.cshtml", user);
        }


        public IActionResult Success()
        {
            return View("~/Views/User/Success.cshtml");
        }
    }
}