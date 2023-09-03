using ClassManagerServer.Api.Commands.User_Authentication;
using ClassManagerServer.Api.Requests;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ClassManagerServer.Api.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("/users/[controller]")]
    public class UserAuthenticationController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<UserAuthenticationController> _logger;

        public UserAuthenticationController(ILogger<UserAuthenticationController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }


        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task CreateUser(CreateUserRequest request)
        {
            _logger.LogInformation("Request to create user has been made.");

            var cmd = new CreateUserCommand(request.Email, request.Password, request.FirstName, request.LastName);
            var data = _mediator.Send(cmd);
            await Task.CompletedTask;
        }

    }
}
