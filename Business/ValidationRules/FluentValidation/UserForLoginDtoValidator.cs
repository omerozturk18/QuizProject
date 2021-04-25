using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class UserForLoginDtoValidator : AbstractValidator<UserForLoginDto>
    {
        public UserForLoginDtoValidator()
        {
            RuleFor(p => p.Email).NotEmpty();
            RuleFor(p => p.Email).EmailAddress();
            RuleFor(p => p.Email.Length).GreaterThan(2);
            RuleFor(p => p.Email).MaximumLength(50);

            RuleFor(p => p.Password).NotEmpty();
            RuleFor(p => p.Password.Length).GreaterThan(6);
            RuleFor(p => p.Password).MaximumLength(50);
        }
    }
}
