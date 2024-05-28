using MediatR;
using RedCloud.Application.Contract.Persistence;
using RedCloud.Application.Features.ResellerAdmins.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using RedCloud.Domain.Entities;
using AutoMapper;
using Azure;
using RedCloud.Application.Responses;

namespace RedCloud.Application.Features.ResellerAdmins.CommandHandler
{
    public class CreateResellerAdminCommandHandler : IRequestHandler<CreateResellerAdminCommand, BaseResponse<int>>
    {

        private readonly IAsyncRepository<ResellerAdmin> _repository;
        private readonly IMapper _mapper;


        public CreateResellerAdminCommandHandler(IAsyncRepository<ResellerAdmin> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<BaseResponse<int>> Handle(CreateResellerAdminCommand request, CancellationToken cancellationToken)
        {
            var AdminRese = _mapper.Map<ResellerAdmin>(request);
            var result = await _repository.AddAsync(AdminRese);
            //var response = new Response<BlogVM>(_mapper.Map<BlogVM>(blog), "Inserted successfully ");
            var response = new BaseResponse<int>(result.Id, "Inserted successfully ");
            return response;

        }
    }
}
