using MvcApiCallingService.Helpers.ApiHelper;
using RedCloud.Domain.Entities;
using RedCloud.Interface;
using RedCloud.Service;

namespace RedCloud.Services
{
    public class OrganizationAdminService : IOrganizationAdminService
    {
        private readonly IApiClient<OrganizationAdmin> _client;
        public readonly ILogger<OrganizationAdminService> _logger;

        public OrganizationAdminService(IApiClient<OrganizationAdmin> client, ILogger<OrganizationAdminService> logger)
        {
            _client = client;
            _logger = logger;
        }
        public async Task<int> CreateOrganizationAdmin(OrganizationAdmin organizationAdmin)
        {
            //_logger.LogInformation("CreateCategory Service initiated");
            var users = await _client.PostAsync("OrganizationAdmin/AddOrganizationAdmin", organizationAdmin);
            //_logger.LogInformation("CreateCategory Service conpleted");
            return users.Data;
        }
    }
}
