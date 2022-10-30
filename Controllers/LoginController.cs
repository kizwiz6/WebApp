using Microsoft.AspNetCore.Mvc;
using WebApp.Models;
using WebApp.Models.Services;

namespace WebApp.Controllers
{
    /// <summary>
    /// LoginController to manage user authetnitcation.
    /// </summary>
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// The form will resubmit to the controller and the action is specified as ProcessLogin.
        /// Function to process the login. Sends the browser to the next page.
        /// </summary>
        /// <param name="userModel">The user data from the login form.</param>
        /// <returns></returns>
        public IActionResult ProcessLogin(UserModel userModel)
        {
            // A new security service to validate a username and password.
            SecurityService securityService = new SecurityService();

            if (securityService.IsValid(userModel))
            {
                return View("LoginSuccess", userModel); // if successful, send to loginsuccess page
            }
            else
            {
                return View("LoginFailure", userModel);
            }

        }
    }
}
