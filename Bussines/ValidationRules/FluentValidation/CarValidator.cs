using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bussines.ValidationRules.FluentValidation
{
    public class CarValidator : AbstractValidator<Car>
    {
        public CarValidator()
        {
            RuleFor(p => p.DailyPrice).GreaterThanOrEqualTo(600);
            RuleFor(p => p.ModelYear).NotEmpty();
            RuleFor(p => p.Descriptions).NotEmpty();
            RuleFor(p => p.Descriptions).MinimumLength(2);
            RuleFor(p => p.BrandId).NotEmpty();
            RuleFor(p => p.ColorId).NotEmpty();
        }
  
    }
}
