using MediatR;

namespace ClassManagerServer.Api.Commands.User_Authentication
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, UserAuthenticationDto>
    {
        private readonly ILogger<CreateUserCommandHandler> _logger;

        public CreateUserCommandHandler(ILogger<CreateUserCommandHandler> logger)
        {
            _logger = logger;
        }
        public Task<UserAuthenticationDto> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            if(request is null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            return HandleInternalAsync(request, cancellationToken);
        }

        public async Task<UserAuthenticationDto> HandleInternalAsync(CreateUserCommand request, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;
            _logger.LogInformation("Command Handler Hit");
            return new UserAuthenticationDto();
        }
    }
}
