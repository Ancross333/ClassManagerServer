using ClassManagerServer.Api.Requests;
using FluentValidation;

namespace ClassManagerServer.Api.Validations
{
    public class CreateUserRequestValidator : AbstractValidator<CreateUserRequest>
    {

        public CreateUserRequestValidator() 
        {
            RuleFor(x => x.FirstName).NotEmpty()
                .WithMessage("Validator Is Working (Req)");
        }
    }
}
