using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoBaEsport.Application.Systems.UserServiceModel
{
    public class LoginValidator : AbstractValidator<LoginRequestModel>
    {
        public LoginValidator()
        {
            RuleFor(m => m.UserName).NotEmpty().WithMessage("UserName is required");
            RuleFor(m => m.Password).NotEmpty().WithMessage("Password is required")
                .MinimumLength(4).WithMessage("Password at least 4 characters");
        }
    }
}
