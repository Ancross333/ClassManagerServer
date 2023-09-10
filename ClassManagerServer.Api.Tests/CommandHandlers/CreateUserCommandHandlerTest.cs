using ClassManagerServer.Api.Commands.User_Authentication;
using ClassManagerServer.Domain.Enums;
using ClassManagerServer.Domain.UserAuthentication;
using FluentAssertions;
using Moq;
using Moq.AutoMock;

namespace ClassManagerServer.Api.Tests.CommandHandlers
{
    public class CreateUserCommandHandlerTest
    {
        private readonly AutoMocker _mocker;
        private readonly Mock<IUserRepository> _userRepoMock;
        private readonly CreateUserCommandHandler _commandHandler;

        public CreateUserCommandHandlerTest()
        {
            _mocker = new AutoMocker();
            _userRepoMock = _mocker.GetMock<IUserRepository>();
            _commandHandler = _mocker.CreateInstance<CreateUserCommandHandler>();
        }

        [Fact]
        public void It_does_not_return_a_null_user_authentication_dto()
        {
            SetupDependencies();
            var result = _commandHandler.Handle(GetCommand(), default);

            result.Should().NotBeNull();
        }

        [Fact]
        public void It_adds_a_user_to_the_db()
        {
            SetupDependencies();
            _commandHandler.Handle(GetCommand(), default);

            _userRepoMock.Verify(x => x.AddUser(It.IsAny<User>()), Times.Once());
        }
        private CreateUserCommand GetCommand()
        {
            return new CreateUserCommand("email", "password", "firstname", "lastname", UserType.Student);
        }

        private void SetupDependencies()
        {
            _userRepoMock.Setup(x => x.AddUser(It.IsAny<User>()))
                .Verifiable();
        }
    }
}
