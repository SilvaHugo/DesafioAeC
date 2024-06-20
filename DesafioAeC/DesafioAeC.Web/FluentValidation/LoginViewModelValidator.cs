using DesafioAeC.Web.ViewModels;
using FluentValidation;

namespace DesafioAeC.Web.FluentValidation
{
    public class LoginViewModelValidator : AbstractValidator<LoginViewModel>
    {
        public LoginViewModelValidator()
        {
            RuleFor(x => x.Login)
                .NotEmpty().WithMessage("Campo Login é obrigatório.");

            RuleFor(x => x.Senha)
                .NotEmpty().WithMessage("Campo Senha é obrigatório.");
        }
    }
}
