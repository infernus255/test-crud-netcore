using FluentValidation;
using test_crud.core.DTOs;

namespace test_crud.infrastructure.Validators
{
    public class UserValidator : AbstractValidator<UserDto>
    {
        public UserValidator()
        {
            RuleFor(user => user.TxtUser).NotNull().Length(1, 50);
            RuleFor(user => user.TxtName).NotNull().Length(1, 200);
            RuleFor(user => user.TxtLastName).NotNull().Length(1, 200);
            RuleFor(user => user.IdentityCardNum).NotNull().Length(1, 50);
            RuleFor(user => user.RoleCode).NotNull();
            RuleFor(user => user.IsActive).NotNull();
        }
    }
}
