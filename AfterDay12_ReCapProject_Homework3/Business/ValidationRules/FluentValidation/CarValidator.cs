using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class CarValidator:AbstractValidator<Car>
    {
        // Kurallar Constructor içine yazılır.
        public CarValidator()
        {
            RuleFor(c=>c.BrandId).NotEmpty();
            RuleFor(c => c.DailyPrice).LessThan(100);
            RuleFor(c => c.DailyPrice).GreaterThan(10000);
            RuleFor(c => c.ModelYear).LessThan(2015);
            RuleFor(c=>c.Description).NotEmpty();
            RuleFor(c => c.Description).Must(StartWithA).WithMessage("Araç bilgisi A Harfi ile başlamalıdır");
        }

        private bool StartWithA(string arg)
        {
            return arg.StartsWith("A");
        }
    }
}
