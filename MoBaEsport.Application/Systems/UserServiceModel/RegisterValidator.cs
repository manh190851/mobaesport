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
            RuleFor(m => m.Phone).NotEmpty().WithMessage("Phone is required");
            RuleFor(m => m.DOB).GreaterThan(DateTime.Now).WithMessage("Birthday can not greater than today");
            RuleFor(m => m.Gender).IsInEnum().WithMessage("Select in gender enum");

            RuleFor(m => m.UserName).NotEmpty().WithMessage("UserName is required");
            RuleFor(m => m.Password).NotEmpty().WithMessage("Password is required")
                .MinimumLength(4).WithMessage("Password at least 4 characters");

            RuleFor(m => m.ConfirmPassword).NotEqual(m => m.Password).WithMessage("Confirm password is not match");
        }
    }
}
