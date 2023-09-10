using ClassManagerServer.Api.Commands.User_Authentication;
using ClassManagerServer.Api.Requests;
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
        public async Task<IActionResult> CreateUser([FromBody] CreateUserRequest request)
        {
            _logger.LogInformation("Request to create user has been made.");

            var cmd = new CreateUserCommand(request.Email, request.Password, request.FirstName, request.LastName, request.UserType);
            var data = await _mediator.Send(cmd);

            return CreatedAtAction(nameof(CreateUser), data); // Assuming the command handler returns data with an Id property
        }
    }
}
