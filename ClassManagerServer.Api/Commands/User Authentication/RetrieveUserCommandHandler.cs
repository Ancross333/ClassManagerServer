using ClassManagerServer.Domain.Enums;
using ClassManagerServer.Domain.UserAuthentication;
using MediatR;

namespace ClassManagerServer.Api.Commands.User_Authentication
{
    public class RetrieveUserCommandHandler : IRequestHandler<RetrieveUserCommand, RetrieveUserDto>
    {
        private readonly IUserRepository _userRepository;

        public RetrieveUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public Task<RetrieveUserDto> Handle(RetrieveUserCommand request, CancellationToken cancellationToken)
        {
            if(request is null)
            {
                throw new ArgumentException(nameof(request));
            }
            return HandleInternalAsync(request, cancellationToken);
        }

        private async Task<RetrieveUserDto> HandleInternalAsync(RetrieveUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetUser(request.Email, request.Password);

            if(user == null)
            {
                user = new User("", "", "", "", UserType.NotFound);
            }

            return new RetrieveUserDto()
            {
                User = user,
            };

        }
    }
}
