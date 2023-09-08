using System.Runtime.Serialization;
using MediatR;

namespace ClassManagerServer.Api.Commands.User_Authentication
{
    public class CreateUserCommand : IRequest<UserAuthenticationDto>
    {

        [DataMember]
        public string Email { get; init; }
        [DataMember] 
        public string Password { get; init; }
        [DataMember] 
        public string FirstName { get; init; }
        [DataMember]
        public string LastName { get; init; }

        public CreateUserCommand(string email, string password, string firstName, string lastName)
        {
            Email = email;
            Password = password;
            FirstName = firstName;
            LastName = lastName;
        }
    }

    public record UserAuthenticationDto
    {

    }
}
