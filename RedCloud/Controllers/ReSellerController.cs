using Microsoft.AspNetCore.Mvc;
using RedCloud.Models;

namespace RedCloud.Controllers
{
    public class ReSellerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AddReseller()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddReseller(ResellerAdminVM Model)
        {
            return View();
        }
    }
}
