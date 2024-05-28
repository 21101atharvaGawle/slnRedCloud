using AutoMapper;
using MediatR;
using RedCloud.Application.Contract.Persistence;
using RedCloud.Application.Features.AdminUsers.Command;
using RedCloud.Application.Responses;
using RedCloud.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedCloud.Application.Features.AdminUsers.CommandHandler
{
    public class EditAdminUserHandler : IRequestHandler<EditAdminUserCommand, BaseResponse<Unit>>
    {
        private readonly IAsyncRepository<AdminUser> _repository;
        private readonly IMapper _mapper;

        public EditAdminUserHandler(IAsyncRepository<AdminUser> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<BaseResponse<Unit>> Handle(EditAdminUserCommand request, CancellationToken cancellationToken)
        {
            var adminuser = _mapper.Map<AdminUser>(request);



            adminuser.ModifiedDate = DateTime.UtcNow;
            adminuser.LastModifiedBy = null;


            await _repository.UpdateAsync(adminuser);
            var response = new BaseResponse<Unit>("Updated Successfully");
            return response;
        }
    }
}
