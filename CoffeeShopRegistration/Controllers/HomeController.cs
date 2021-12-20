using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CoffeeShopRegistration.Models;

namespace CoffeeShopRegistration.Controllers
{
    class User
    {
        public string FirstName;
        public string LastName;
        public string Email;
        public string Password;

        public User(string FirstName, string LastName, string Email, string Password)
        {
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.Email = Email;
            this.Password = Password;
        }

        public bool VerifyUserInformation(string first, string last, string email, string pass, List<User> users)
        {
            foreach (User user in users)
            {
                if ((first == user.FirstName && last == user.LastName) || email == user.Email)
                {
                    return false;
                }
            }
            return true;
        }
    }
    public class HomeController : Controller
    {
        static List<User> Users = new List<User>();

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Registration()
        {
            return View();
        }

        public IActionResult RegistrationResponse(string first, string last, string email, string pass)
        {
            Users.Add(new User(first, last, email, pass));
            ViewBag.first = first;
            ViewBag.last = last;
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
