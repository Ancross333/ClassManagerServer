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
            if (request is null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            return HandleInternalAsync(request, cancellationToken);
        }

        public async Task<UserAuthenticationDto> HandleInternalAsync(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = new User(request.Email, request.Password, request.FirstName, request.LastName, request.UserType);

            await _userRepo.AddUser(user);
            await _userRepo.SaveAsync();

            return new UserAuthenticationDto()
            {
                UserId = user.UserId
            };
        }
    }
}
