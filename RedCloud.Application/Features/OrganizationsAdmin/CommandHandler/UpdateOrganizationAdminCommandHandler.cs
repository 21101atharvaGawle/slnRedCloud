using AutoMapper;
using MediatR;
using RedCloud.Application.Contract.Persistence;
using RedCloud.Application.Features.OrganizationsAdmin.Command;
using RedCloud.Application.Responses;
using RedCloud.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedCloud.Application.Features.OrganizationsAdmin.CommandHandler
{
    public class UpdateOrganizationAdminCommandHandler : IRequestHandler<UpdateOrganizationAdmin, BaseResponse<Unit>>
    {

        private readonly IAsyncRepository<OrganizationAdmin> _repository;
        private readonly IMapper _mapper;


        public UpdateOrganizationAdminCommandHandler(IAsyncRepository<OrganizationAdmin> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<BaseResponse<Unit>> Handle(UpdateOrganizationAdmin request, CancellationToken cancellationToken)
        {
            var adminuser = _mapper.Map<OrganizationAdmin>(request);
            await _repository.UpdateAsync(adminuser);
            var response = new BaseResponse<Unit>("Inserted successfully");
            return response;
        }

    }
}
