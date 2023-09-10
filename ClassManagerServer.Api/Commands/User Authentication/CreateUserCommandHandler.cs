using ClassManagerServer.Domain.Enums;
using ClassManagerServer.Domain.UserAuthentication;
using MediatR;

namespace ClassManagerServer.Api.Commands.User_Authentication
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, UserAuthenticationDto>
    {
        private readonly ILogger<CreateUserCommandHandler> _logger;
        private readonly IUserRepository _userRepo;

        public CreateUserCommandHandler(ILogger<CreateUserCommandHandler> logger, IUserRepository userRepo)
        {
            _userRepo = userRepo;
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
            await _userRepo.AddUser(request.Email, request.Password, request.FirstName, request.LastName, UserType.Student);
            await _userRepo.SaveAsync();

            _logger.LogInformation("Command Handler Hit");
            return new UserAuthenticationDto();
        }
    }
}
