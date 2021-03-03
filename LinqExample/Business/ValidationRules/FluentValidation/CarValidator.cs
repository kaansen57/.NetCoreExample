using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class CarValidator : AbstractValidator<Car>
    {
        public CarValidator()
        {
            ////ID
            //RuleFor(c => c.Id).NotEmpty();
            //RuleFor(c => c.Id).GreaterThan(0);

            //ColorID
            RuleFor(c => c.ColorId).NotEmpty();
            RuleFor(c => c.ColorId).GreaterThan(0).LessThan(8);
            //BrandID
            RuleFor(c => c.BrandId).NotEmpty();
            //DailPrice
            RuleFor(c => c.DailyPrice).NotEmpty();
            RuleFor(c => c.DailyPrice).GreaterThan(0).LessThan(10000);
            //Description
            //RuleFor(c => c.Description).Must(StartWithA);

            //ModelYear
            RuleFor(c => c.ModelYear).NotEmpty();
            //CarName
            RuleFor(c => c.CarName).NotEmpty();
            RuleFor(c => c.CarName).MinimumLength(2);
        }

        private bool StartWithA(string arg)
        {
            return arg.StartsWith("K");
        }
    }
}
