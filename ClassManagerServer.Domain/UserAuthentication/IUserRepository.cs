using ClassManagerServer.Domain.Enums;

namespace ClassManagerServer.Domain.UserAuthentication
{
    public interface IUserRepository
    {
        public Task SaveAsync();
        public Task AddUser(string email, string password, string firstName, string lastName, UserType userType);
    }
}
