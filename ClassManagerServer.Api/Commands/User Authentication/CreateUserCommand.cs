using System.Runtime.Serialization;
using ClassManagerServer.Domain.Enums;
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
        [DataMember]
        public UserType UserType { get; init; }

        public CreateUserCommand(string email, string password, string firstName, string lastName, UserType userType)
        {
            Email = email;
            Password = password;
            FirstName = firstName;
            LastName = lastName;
            UserType = userType;
        }
    }

    public record UserAuthenticationDto
    {
        public int UserId { get; init; }
    }
}
