using Login.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Login.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            _logger.LogWarning("Index is called !");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(_login login)
        {
            if (!ModelState.IsValid)
            {
                return View(login);
            }

            if (login.RememberMe == true)
            {
                CookieOptions options = new CookieOptions();
                options.Expires = DateTimeOffset.Now.AddMinutes(1);
                HttpContext.Response.Cookies.Append("Cookies", "login", options);
            }
           


            ViewBag.Values = login;
            return RedirectToAction("Privacy");

        }
        public IActionResult Privacy()
        {
            string Cookies = HttpContext.Request.Cookies["Cookies"];

            if (Cookies != null)
            {
                ViewBag.Message = "Saved";
                ViewBag.Cookies = Cookies;  

            }
            else
            {
                ViewBag.Message = "Not Saved";

            }
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}