using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MvcApiCallingService.Helpers.ApiHelper;

using RedCloud.Domain.Entities;
using RedCloud.Interface;
using RedCloud.Models;
using RedCloud.ModelVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedCloud.Service
{
    public class AdminUserService : IAdminUserService
    {
        private readonly IApiClient<RedCloudUserVM> _client;
        public readonly ILogger<AdminUserService> _logger;
        
        public AdminUserService(IApiClient<RedCloudUserVM> client, ILogger<AdminUserService> logger)
        {
            _client = client;
            _logger = logger;
        }

        public async Task<int> CreateAdminUser(AdminUser adminUser)
        {
            //_logger.LogInformation("CreateCategory Service initiated");
            var users = await _client.PostAsync("AdminUser/AddAdminUser", adminUser);
            //_logger.LogInformation("CreateCategory Service conpleted");
            return users.Data;
        }

        
        [HttpPost]
        public async Task EditAdminUser(AdminUser adminUser)
        {
            var users = _client.PutAsync("AdminUser/EditAdminUser", adminUser);
            //return users.Data;
        }

        //public async Task<AdminUser> GetAdminUserById(int id)
        //{
        //    var response = await _client.GetByIdAsync($"AdminUser/{id}");
        //    return response.Data;
        //}


        //public async Task<RedCloudUserVM> GetAdminUserById(int id)
        //{
        //    _logger.LogInformation($"Calling API to fetch admin user with ID: {id}");
        //    var response = await _client.GetByIdAsync($"AdminUser/{id}");
        //    if (response.Data == null)
        //    {
        //        _logger.LogWarning($"No admin user found with ID: {id}");
        //    }
        //    else
        //    {
        //        _logger.LogInformation($"Admin user with ID: {id} retrieved successfully");
        //    }
        //    return response.Data;
        //}

        public async Task<RedCloudUserVM> GetAdminUserById(int id)
        {
            // _logger.LogInformation("GetEventById Service initiated");
            var Events = await _client.GetByIdAsync($"AdminUser/{id}");
            //_logger.LogInformation("GetEventById Service conpleted");
            return Events.Data;
        }


    }
}
