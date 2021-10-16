﻿using Core.Entites.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(u => u.FirstName).NotEmpty();
            RuleFor(u => u.LastName).NotEmpty();
            //RuleFor(u => u.Password).NotEmpty();
            //RuleFor(u => u.Password).MinimumLength(8);
            RuleFor(u => u.Email).NotEmpty();
        }
    }
}
