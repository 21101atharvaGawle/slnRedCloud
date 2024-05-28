using MediatR;
using RedCloud.Domain.Entities;
using RedCloud.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedCloud.Interface
{
    public interface IAdminUserService
    {
        Task<int> CreateAdminUser(AdminUser adminUser);
        Task EditAdminUser(AdminUser adminUser);

        Task<RedCloudUserVM> GetAdminUserById(int id);


    }
}
