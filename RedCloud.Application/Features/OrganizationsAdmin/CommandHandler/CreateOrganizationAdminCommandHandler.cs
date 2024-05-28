using AutoMapper;
using Azure;
using MediatR;
using RedCloud.Application.Contract.Persistence;
using RedCloud.Application.Features.OrganizationsAdmin.Command;
using RedCloud.Application.Responses;
using RedCloud.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace RedCloud.Application.Features.OrganizationsAdmin.CommandHandler
{
    public class CreateOrganizationAdminCommandHandler : IRequestHandler<CreateOrganizationAdmin, BaseResponse<int>>
    {
        private readonly IAsyncRepository<OrganizationAdmin> _asyncRepository;
        private readonly IMapper _mapper;


        public CreateOrganizationAdminCommandHandler(IAsyncRepository<OrganizationAdmin> asyncRepository, IMapper mapper)
        {
            _asyncRepository = asyncRepository;
            _mapper = mapper;
        }
        public async Task<BaseResponse<int>> Handle(CreateOrganizationAdmin request, CancellationToken cancellationToken)
        {
            var org = _mapper.Map<OrganizationAdmin>(request);
           var result = await _asyncRepository.AddAsync(org);
            var response = new BaseResponse<int>(result.OrgID, "Inserted successfully ");
            return response;
        }
    }
}
