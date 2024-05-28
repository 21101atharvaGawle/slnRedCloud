using Microsoft.AspNetCore.Mvc;
using RedCloud.Models.Account;
namespace RedCloud.Controllers
{
    public class AccountController : Controller
    {
        // Action method to display the login page
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }


        // Action method to handle login POST requests
        [HttpPost]
        public async Task<IActionResult> Login(Login model)
        {
            if (ModelState.IsValid)
            {
               
                if (true)
                {
                    // Here you would call your API to validate the credentials
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                }
            }
            return View(model);
        }

        //[HttpPost]
        //public async Task<IActionResult> LoginAsync(Login login)
        //{

        //    if (ModelState.IsValid)
        //    {

        //        //LoginResponse loginResponse = await _service.Login(login);
        //        //if (loginResponse.UserName != null)
        //        {
        //            //HttpContext.Session.SetString("UserName", loginResponse.UserName);
        //            //_notyf.Success("Logged In Successfully");
                    
        //            return RedirectToAction("Index", "Home");
        //        }
        //        else
        //        {

        //            //_notyf.Error(loginResponse.Message);
        //            return View();
        //        }

        //    }
        //    else
        //    {
        //        return View();
        //    }
        //}






    }
}
