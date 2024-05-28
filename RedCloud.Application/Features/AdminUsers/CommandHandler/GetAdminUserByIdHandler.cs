using AutoMapper;
using MediatR;
using RedCloud.Application.Contract.Persistence;
using RedCloud.Application.Features.AdminUsers.Command;
using RedCloud.Application.Responses;
using RedCloud.Domain.Entities;
using RedCloud.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedCloud.Application.Features.AdminUsers.CommandHandler
{
    public class GetAdminUserByIdHandler : IRequestHandler<GetAdminUserByIdQuery, BaseResponse<AdminUser>>
    {
        private readonly IAsyncRepository<AdminUser> _repository;
        private readonly IMapper _mapper;

        public GetAdminUserByIdHandler(IAsyncRepository<AdminUser> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<BaseResponse<AdminUser>> Handle(GetAdminUserByIdQuery request, CancellationToken cancellationToken)
        {
            var adminUser = await _repository.GetByIdAsync(request.ID);
            return new BaseResponse<AdminUser>(adminUser, "success");
        }

    }
}
    

