using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RedCloud.Application.Features.OrganizationsAdmin.Command;

namespace RedCloudAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrganizationAdmin : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrganizationAdmin(IMediator mediator)
        {
            _mediator = mediator;
         
        }

        [HttpPost( "AddOrganizationAdmin")]
        public async Task<ActionResult> Create([FromBody] CreateOrganizationAdmin createOrganizationAdmin)
        {
            var response = await _mediator.Send(createOrganizationAdmin);
            return Ok(response);
        }

        [HttpPut( "UpdateOrganizationAdmin")]
        public async Task<ActionResult> Update([FromBody] UpdateOrganizationAdmin updateOrganizationAdmin)
        {
            var response = await _mediator.Send(updateOrganizationAdmin);
            return Ok(response);
        }
    }
}
