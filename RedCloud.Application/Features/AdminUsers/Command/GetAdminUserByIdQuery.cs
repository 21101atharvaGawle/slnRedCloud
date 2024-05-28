using MediatR;
using RedCloud.Application.Responses;
using RedCloud.Domain.Entities;
using RedCloud.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedCloud.Application.Features.AdminUsers.Command
{
    public class GetAdminUserByIdQuery : IRequest<BaseResponse<AdminUser>>
    {
        public int ID { get; set; }
    }
    
}
