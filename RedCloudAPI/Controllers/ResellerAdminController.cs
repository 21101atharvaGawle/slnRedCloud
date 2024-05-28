using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RedCloud.Application.Features.ResellerAdmins.Command;

namespace RedCloudAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]   
    public class ResellerAdminController : ControllerBase
    {

        private readonly IMediator _mediator;
        private readonly ILogger _logger;

        public ResellerAdminController(IMediator mediator, ILogger<ResellerAdminController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpPost(Name = "AddResellerAdmin")]
        public async Task<ActionResult> Create([FromBody] CreateResellerAdminCommand CreateResellerAdminCommand)
        {
            var response = await _mediator.Send(CreateResellerAdminCommand);
            return Ok(response);
        }

        [HttpPut( "UpdateResellerAdmin")]
        public async Task<ActionResult> Update([FromBody] UpdateResellerAdminCommand updateResellerAdmin)
        {
            var response = await _mediator.Send(updateResellerAdmin);
            return Ok(response);
        }

    }
}
