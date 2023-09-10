using ClassManagerServer.Domain.Enums;

namespace ClassManagerServer.Domain.UserAuthentication
{
    public interface IUserRepository
    {
        public Task SaveAsync();
        public Task AddUser(User user);
    }
}
