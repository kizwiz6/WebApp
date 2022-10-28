using Microsoft.AspNetCore.Mvc;
using WebApp.Models;

namespace WebApp.Controllers
{
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
            // Verify that we got the right username and password.
            if (userModel.UserName == "Kieran" && userModel.Password == "Emery")
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
