using ClassManagerServer.Api.Commands.User_Authentication;
using ClassManagerServer.Api.Requests;
using ClassManagerServer.Domain.Enums;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace ClassManagerServer.Api.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("/users/[controller]")]
    public class UserAuthenticationController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<UserAuthenticationController> _logger;

        public UserAuthenticationController(ILogger<UserAuthenticationController> logger,
                                             IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route("Add")]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserRequest request)
        {
            _logger.LogInformation("Request to create user has been made.");

            var cmd = new CreateUserCommand(request.Email, request.Password, request.FirstName, request.LastName, request.UserType);
            var data = await _mediator.Send(cmd);

            _logger.LogInformation($"Created user with Id{data.UserId}");
            return CreatedAtAction(nameof(CreateUser), data);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Route("Get")]
        public async Task<IActionResult> GetUser([FromBody] RetrieveUserRequest request)
        {
            var cmd = new RetrieveUserCommand(request.Email, request.Password);
            var data = await _mediator.Send(cmd);

            if(data.User.UserType == UserType.NotFound)
            {
                return NotFound();
            }
            
            if(data.User.UserType == UserType.Unauthorized)
            {
                return Unauthorized();
            }

            return Ok(data);
        }
    }
}
