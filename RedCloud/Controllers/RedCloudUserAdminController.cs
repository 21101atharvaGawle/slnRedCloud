using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MvcApiCallingService.Helpers.ApiHelper;
using RedCloud.Domain.Entities;
using RedCloud.Interface;
using RedCloud.Models;
using RedCloud.Service;
using RedCloud.Services;

namespace RedCloud.Controllers
{
    public class RedCloudUserAdminController : Controller
    {

        private readonly IAdminUserService _adminUserService;
        private readonly ILogger<AdminUserService> _logger;

        


        public RedCloudUserAdminController(IAdminUserService adminUserService, ILogger<AdminUserService> logger)
        {
            _adminUserService = adminUserService;
            _logger = logger;
            
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AddAdmin()
        {
            return View();
        }
        [HttpPost("AddAdminUser")]
        public async Task<IActionResult> AddAdmin(RedCloudUserVM request)
        {
            if (ModelState.IsValid)
            {
                var adminUser = new AdminUser
                {
                    FirstName = request.FirstName,
                    LastName = request.LastName,
                    Email = request.Email,
                    MobileNumber = request.MobileNumber,
                    IsActive = request.IsActive,
                    CreatedDate = DateTime.UtcNow,
                    CreatedBy = null,
                    IsDeleted = false
                };

                var response = await _adminUserService.CreateAdminUser(adminUser);
                return RedirectToAction("Index");
            }

            
            return View(request);
        }


        //public async Task<IActionResult> EditAdmin(int id)
        //{

        //    var user = await _adminUserService.GetAdminUserById(id);


        //    if (user == null)
        //    {
        //        return NotFound();

        //    }


        //    var userModel = new RedCloudUserVM
        //    {
        //        ID = user.ID,
        //        FirstName = user.FirstName,
        //        LastName = user.LastName,
        //        Email = user.Email,
        //        MobileNumber = user.MobileNumber,
        //        IsActive = user.IsActive
        //    };

        //    return View(userModel);
        //}


        //public async Task<IActionResult> EditAdmin(int id)
        //{
        //    _logger.LogInformation($"Fetching admin user with ID: {id}");
        //    var user = await _adminUserService.GetAdminUserById(id);

        //    if (user == null)
        //    {
        //        _logger.LogWarning($"Admin user with ID: {id} not found");
        //        return NotFound();
        //    }

        //    var userModel = new RedCloudUserVM
        //    {
        //        ID = user.ID,
        //        FirstName = user.FirstName,
        //        LastName = user.LastName,
        //        Email = user.Email,
        //        MobileNumber = user.MobileNumber,
        //        IsActive = user.IsActive
        //    };

        //    _logger.LogInformation($"Admin user with ID: {id} found and being sent to view");
        //    return View(userModel);
        //}

        public async Task<IActionResult> EditAdmin(int id)
        {
            var response = await _adminUserService.GetAdminUserById(id);
            
            return View(response);
        }





        //public IActionResult EditAdmin()
        //{
        //    return View();
        //}






        [HttpPost("EditAdminUser")]
        public async Task<IActionResult> EditAdmin(RedCloudUserVM request)
        {
            if (ModelState.IsValid)
            {
                var adminUser = new AdminUser
                {
                    ID = request.ID,
                    FirstName = request.FirstName,
                    LastName = request.LastName,
                    Email = request.Email,
                    MobileNumber = request.MobileNumber,
                    IsActive = request.IsActive,
                    ModifiedDate = DateTime.UtcNow,
                    LastModifiedBy = null

                };


                await _adminUserService.EditAdminUser(adminUser);

                return RedirectToAction("Index");
            }


            return View(request);
        }

        


    }
}