using ClassManagerServer.Api.Requests;
using ClassManagerServer.Api.Validations;
using ClassManagerServer.Domain.Enums;
using FluentAssertions;
using Moq;
using Moq.AutoMock;
using Xunit;

namespace ClassManagerServer.Api.Tests.Validators
{
    public class CreateUserRequestValidatorTests
    {
        private readonly AutoMocker _mocker;

        public CreateUserRequestValidatorTests()
        {
            _mocker = new AutoMocker();
        }

        [Fact]
        public void It_rejects_invalid_emails()
        {
            var validator = new CreateUserRequestValidator();
            var request = new CreateUserRequest()
            {
                Email = "Invalid Email",
                Password = "ValidPassword1",
                FirstName = "First Name",
                LastName = "LastName",
                UserType = UserType.Student
            };

            var result = validator.Validate(request);
            result.IsValid.Should().Be(false);
        }

        [Fact]
        public void It_rejects_short_passwords()
        {
            var validator = new CreateUserRequestValidator();
            var request = new CreateUserRequest()
            {
                Email = "Valid@Email.net",
                Password = "short",
                FirstName = "First Name",
                LastName = "LastName",
                UserType = UserType.Student
            };

            var result = validator.Validate(request);
            result.IsValid.Should().Be(false);
        }

        [Fact]
        public void It_rejects_numberless_passwords()
        {
            var validator = new CreateUserRequestValidator();
            var request = new CreateUserRequest()
            {
                Email = "Valid@Email.net",
                Password = "NoNumbers",
                FirstName = "First Name",
                LastName = "LastName",
                UserType = UserType.Student
            };

            var result = validator.Validate(request);
            result.IsValid.Should().Be(false);
        }

        [Fact]
        public void It_rejects_no_lowercase_passwords()
        {
            var validator = new CreateUserRequestValidator();
            var request = new CreateUserRequest()
            {
                Email = "Valid@Email.net",
                Password = "ALLCAPS2001",
                FirstName = "First Name",
                LastName = "LastName",
                UserType = UserType.Student
            };

            var result = validator.Validate(request);
            result.IsValid.Should().Be(false);
        }

        [Fact]
        public void It_rejects_no_cap_passwords()
        {
            var validator = new CreateUserRequestValidator();
            var request = new CreateUserRequest()
            {
                Email = "Valid@Email.net",
                Password = "no_caps2001",
                FirstName = "First Name",
                LastName = "LastName",
                UserType = UserType.Student
            };

            var result = validator.Validate(request);
            result.IsValid.Should().Be(false);
        }

        [Fact]
        public void It_rejects_short_first_name()
        {
            var validator = new CreateUserRequestValidator();
            var request = new CreateUserRequest()
            {
                Email = "Valid@Email.net",
                Password = "ValidPassword1",
                FirstName = "F",
                LastName = "LastName",
                UserType = UserType.Student
            };

            var result = validator.Validate(request);
            result.IsValid.Should().Be(false);
        }

        [Fact]
        public void It_rejects_long_first_name()
        {
            var validator = new CreateUserRequestValidator();
            var request = new CreateUserRequest()
            {
                Email = "Valid@Email.net",
                Password = "ValidPassword1",
                FirstName = new string('a', 51),
                LastName = "LastName",
                UserType = UserType.Student
            };

            var result = validator.Validate(request);
            result.IsValid.Should().Be(false);
        }

        [Fact]
        public void It_rejects_short_last_name()
        {
            var validator = new CreateUserRequestValidator();
            var request = new CreateUserRequest()
            {
                Email = "Valid@Email.net",
                Password = "ValidPassword1",
                FirstName = "First Name",
                LastName = "L",
                UserType = UserType.Student
            };

            var result = validator.Validate(request);
            result.IsValid.Should().Be(false);
        }

        [Fact]
        public void It_rejects_long_last_name()
        {
            var validator = new CreateUserRequestValidator();
            var request = new CreateUserRequest()
            {
                Email = "Valid@Email.net",
                Password = "ValidPassword1",
                FirstName = "First Name",
                LastName = new string('b', 51),
                UserType = UserType.Student
            };

            var result = validator.Validate(request);
            result.IsValid.Should().Be(false);
        }

        [Fact]
        public void It_rejects_invalid_user_type()
        {
            var validator = new CreateUserRequestValidator();
            var request = new CreateUserRequest()
            {
                Email = "Valid@Email.net",
                Password = "ValidPassword1",
                FirstName = "First Name",
                LastName = "LastName",
                UserType = (UserType)999
            };

            var result = validator.Validate(request);
            result.IsValid.Should().Be(false);
        }

        [Fact]
        public void It_accepts_valid_requests()
        {
            var validator = new CreateUserRequestValidator();
            var request = new CreateUserRequest()
            {
                Email = "Valid@Email.net",
                Password = "ValidPassword1",
                FirstName = "First Name",
                LastName = "LastName",
                UserType = UserType.Student
            };

            var result = validator.Validate(request);
            result.IsValid.Should().Be(true);
        }
    }
}
