using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RedCloud.Application.Features.AdminUsers.Command;
using RedCloud.Domain.Entities;
using RedCloud.Models;

namespace RedCloudAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminUserController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger _logger;
        public AdminUserController(IMediator mediator, ILogger<AdminUserController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }
        [HttpPost("AddAdminUser")]
        public async Task<ActionResult> Create([FromBody] CreateAdminUserCommand CreateAdminUserCommand)
        {
            try
            {
                
                var response = await _mediator.Send(CreateAdminUserCommand);
                return Ok(response);
            }
            catch (Exception)
            {

                throw;
            }
        }


        [HttpPut("EditAdminUser")]
        public async Task<ActionResult> Update([FromBody] EditAdminUserCommand EditAdminUserCommand)
        {
            var response = await _mediator.Send(EditAdminUserCommand);
            return Ok(response);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult> GetAdminUserById(int id)
        {
            try
            {
                var response = await _mediator.Send(new GetAdminUserByIdQuery { ID = id });
                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching admin user by ID");
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
            }
        }

    }
}
