using FluentValidation;
using test_crud.core.DTOs;

namespace test_crud.infrastructure.Validators
{
    public class SecurityValidator : AbstractValidator<SecurityDto>
    {
        public SecurityValidator()
        {
            RuleFor(user => user.TxtUser).NotNull().Length(1, 50);
            RuleFor(user => user.TxtPassword).NotNull().Length(6, 50);
            RuleFor(user => user.TxtName).NotNull().Length(1, 200);
            RuleFor(user => user.TxtLastName).NotNull().Length(1, 200);
            RuleFor(user => user.RoleCode).NotNull();
        }
    }
}
