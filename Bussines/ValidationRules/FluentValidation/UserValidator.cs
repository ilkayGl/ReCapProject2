using Core.Entities.Concrete;
using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bussines.ValidationRules.FluentValidation
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(u => u.FirstName).NotEmpty();
            RuleFor(u => u.LastName).NotEmpty();
            //RuleFor(u => u.PasswordHash).NotEmpty();
            //RuleFor(u => u.PasswordHash).MinimumLength(8).WithMessage("Must be at least 8 characters");
            RuleFor(u => u.Email).EmailAddress().WithMessage("Geçersiz e-posta adresi");
        }
    }
}
