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
        private readonly IValidator<CreateUserRequest> _validator;  // Step 1: Add a private field for the validator

        public UserAuthenticationController(ILogger<UserAuthenticationController> logger,
                                             IMediator mediator,
                                             IValidator<CreateUserRequest> validator)  // Step 2: Add an additional parameter for the validator
        {
            _logger = logger;
            _mediator = mediator;
            _validator = validator;  // Step 3: Assign the injected validator to the field
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserRequest request)
        {
            _logger.LogInformation("Request to create user has been made.");

            // Step 4: Use the validator to validate the request
            var validationResult = await _validator.ValidateAsync(request);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            var cmd = new CreateUserCommand(request.Email, request.Password, request.FirstName, request.LastName);
            var data = await _mediator.Send(cmd);

            return CreatedAtAction(nameof(CreateUser), data); // Assuming the command handler returns data with an Id property
        }
    }
}
