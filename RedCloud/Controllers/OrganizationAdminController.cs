using Microsoft.AspNetCore.Mvc;
using RedCloud.Domain.Entities;
using RedCloud.Interface;
using RedCloud.Service;

namespace RedCloud.Controllers
{
    public class OrganizationAdminController : Controller
    {
        private readonly IOrganizationAdminService _organizationAdminService;
        private readonly ILogger<OrganizationAdmin> _logger;


        public OrganizationAdminController(IOrganizationAdminService organizationAdminService, ILogger<OrganizationAdmin> logger)
        {
            _organizationAdminService = organizationAdminService;
            _logger = logger;

        }
        public IActionResult AddOrganizationAdmin()
        {
            return View();
        }

        [HttpPost("AddOrganizationAdmin")]
        public async Task<IActionResult> AddOrganizationAdmin(OrganizationAdmin request)
        {
            // _logger.LogInformation("CreateCategory Action initiated");
            var response = await _organizationAdminService.CreateOrganizationAdmin(request);

            //_logger.LogInformation("CreateCategory Action initiated");
            return RedirectToAction("Index");
        }

    }
}
