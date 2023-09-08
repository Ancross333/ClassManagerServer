using ClassManagerServer.Domain.Enums;

namespace ClassManagerServer.Domain.UserAuthentication
{
    public class User
    {
        public string Email { get; private set; }
        public string Password { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public UserType UserType { get; private set; }

        public User(string email, string password, string firstName, string lastName, UserType userType)
        {
            Email = email;
            Password = password;
            FirstName = firstName;
            LastName = lastName;
            UserType = userType;
        }
    }
}
