using ClassManagerServer.Domain.UserAuthentication;
using MediatR;
using System.Runtime.Serialization;

namespace ClassManagerServer.Api.Commands.User_Authentication
{
    public class RetrieveUserCommand : IRequest<RetrieveUserDto>
    {
        [DataMember]
        public string Email { get; set; }
        [DataMember]
        public string Password { get; set; }

        public RetrieveUserCommand(string email, string password)
        {
            Email = email;
            Password = password;
        }
    }

    public record RetrieveUserDto
    {
        public User User { get; init; }
    }
}
