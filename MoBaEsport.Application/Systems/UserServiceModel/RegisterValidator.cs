using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoBaEsport.Application.Systems.UserServiceModel
{
    public class RegisterValidator : AbstractValidator<RegisterRequestModel>
    {
        public RegisterValidator()
        {
            RuleFor(m => m.Email).NotEmpty().WithMessage("Email is required")
                .Matches(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$")
                .WithMessage("Email format not match");

            RuleFor(m => m.Fullname).NotEmpty().WithMessage("FullName is requied");
            RuleFor(m => m.Phone).NotEmpty().WithMessage("Phone number is required");
            RuleFor(m => m.Gender).NotEmpty().WithMessage("Gender is required");
            RuleFor(m => m.DOB).NotEmpty().WithMessage("Birthday is required")
                .LessThanOrEqualTo(DateTime.Now).WithMessage("Birthday cannot greater than today");

            RuleFor(m => m.UserName).NotEmpty().WithMessage("UserName is required");
            RuleFor(m => m.Password).NotEmpty().WithMessage("Password is required")
                .MinimumLength(4).WithMessage("Password at least 4 characters");

        }
    }
}
