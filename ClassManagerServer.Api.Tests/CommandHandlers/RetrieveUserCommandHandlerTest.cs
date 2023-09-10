using ClassManagerServer.Api.Commands.User_Authentication;
using ClassManagerServer.Domain.UserAuthentication;
using FluentAssertions;
using Moq;
using Moq.AutoMock;

namespace ClassManagerServer.Api.Tests.CommandHandlers
{
    public class RetrieveUserCommandHandlerTest
    {
        private readonly AutoMocker _mocker;
        private readonly Mock<IUserRepository> _userRepoMock;
        private readonly RetrieveUserCommandHandler _handler;

        public RetrieveUserCommandHandlerTest()
        {
            _mocker = new AutoMocker();
            _userRepoMock = _mocker.GetMock<IUserRepository>();
            _handler = _mocker.CreateInstance<RetrieveUserCommandHandler>();
        }

        [Fact]
        public void It_does_not_return_a_null_user()
        {
            SetupDependencies();

            var cmd = GetCommand();
            var result = _handler.Handle(cmd, default);

            result.Should().NotBeNull();
        }

        [Fact]
        public void It_attemps_to_retrieve_a_user_from_the_database()
        {
            SetupDependencies();
            var cmd = GetCommand();

            _handler.Handle(cmd, default);

            _userRepoMock.Verify(x => x.GetUser(It.IsAny<string>(), It.IsAny<string>()), Times.Once);

        }
        private void SetupDependencies()
        {
            _userRepoMock.Setup(x => x.GetUser(It.IsAny<string>(), It.IsAny<string>()))
                .ReturnsAsync(It.IsAny<User>())
                .Verifiable();
        }

        private RetrieveUserCommand GetCommand()
        {
            return new RetrieveUserCommand("email", "password");
        }
    }
}
