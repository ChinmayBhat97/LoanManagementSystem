using LoanManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace LoanManagementSystem.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        // Home page function 
        public IActionResult HomePage()
        {
            try
            {
                return View();
            }
            catch (Exception Ex)
            {
                return View(Ex.Message);
            }
            
        }

        // About page function 
        public IActionResult About()
        {
            try
            {
                return View();
            }
            catch (Exception Ex)
            {
                return View(Ex.Message);
            }
        }

        // Contact page function 
        public IActionResult Contact()
        {
            try
            {
                return View();
            }
            catch (Exception Ex)
            {
                return View(Ex.Message);
            }

        }

      

        //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        //public IActionResult Error()
        //{
        //    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        //}
    }
}