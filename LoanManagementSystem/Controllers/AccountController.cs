using LoanManagementSystem.Sessions;
using Microsoft.AspNetCore.Mvc;

namespace LoanManagementSystem.Controllers
{
    public class AccountController : Controller
    {
        private IAccountServices _accountServices;

        public AccountController(IAccountServices accountServices)
        {
            _accountServices = accountServices;
        }

        // Login Page
        public IActionResult LoginPage()
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

        // Login function to Login to application
        [HttpPost]
        public IActionResult Login(string userName, string passWord)
        {
            try
            {
                var account = _accountServices.Login(userName, passWord);
                if (account != null)
                {
                    HttpContext.Session.SetString("username", userName);
                    //ViewBag.Message="Credentials are valid, redirecting to application.";
                    return RedirectToAction("HomePage", "Home");
                }
                else
                {
                    ViewBag.Message="Credentials are invalid, check the details.";
                    //ViewBag.Message1="invalid Credentials";
                    return View();
                }
            }
            catch (Exception Ex)
            {
                return View(Ex.Message);
            }
           
        }

        // Logout function to loggin out from application
        public IActionResult Logout()
        {
            try
            {
                HttpContext.Session.Remove("username");
                ViewBag.Message1="You have logged out from the application.";
                return RedirectToAction("LoginPage", "Account");
            }
            catch (Exception Ex)
            {
                return View(Ex.Message);
            }
          
        }
    }
}
