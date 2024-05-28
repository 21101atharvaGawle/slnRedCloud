using AutoMapper;
using MediatR;
using RedCloud.Application.Contract.Persistence;
using RedCloud.Application.Features.ResellerAdmins.Command;
using RedCloud.Application.Responses;
using RedCloud.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedCloud.Application.Features.ResellerAdmins.CommandHandler
{
    public class UpdateResellerAdminCommandHandler : IRequestHandler<UpdateResellerAdminCommand, BaseResponse<Unit>>
    {
        private readonly IAsyncRepository<ResellerAdmin> _repository;
        private readonly IMapper _mapper;


        public UpdateResellerAdminCommandHandler(IAsyncRepository<ResellerAdmin> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<BaseResponse<Unit>> Handle(UpdateResellerAdminCommand request, CancellationToken cancellationToken)
        {
            var adminuser = _mapper.Map<ResellerAdmin>(request);
            await _repository.UpdateAsync(adminuser);
            var response = new BaseResponse<Unit>( "Inserted successfully");
            return response;
        }
    }
}
