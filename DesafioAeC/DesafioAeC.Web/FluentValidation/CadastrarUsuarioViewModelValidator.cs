using DesafioAeC.Web.ViewModels;
using FluentValidation;

namespace DesafioAeC.Web.FluentValidation
{
    public class CadastrarUsuarioViewModelValidator : AbstractValidator<CadastrarUsuarioViewModel>
    {
        public CadastrarUsuarioViewModelValidator()
        {
            RuleFor(x => x.Nome)
                .NotEmpty().WithMessage("Campo Nome é obrigatório.")
                .MaximumLength(255).WithMessage("Campo Nome suporta no máximo {MaxLength} caracteres.")
                .Matches(@"^[a-zA-Z0-9À-ú\s]+$").WithMessage("O nome não pode conter caracteres especiais.");

            RuleFor(x => x.Login)
                .NotEmpty().WithMessage("Campo Login é obrigatório.")
                .MaximumLength(255).WithMessage("Campo Login suporta no máximo {MaxLength} caracteres.")
                .Matches(@"^[a-zA-Z0-9]+$").WithMessage("O login não pode conter caracteres especiais ou espaços."); ;

            RuleFor(x => x.Senha)
                .NotEmpty().WithMessage("Campo Senha é obrigatório.");

            RuleFor(x => x.ConfirmarSenha)
                .NotEmpty().WithMessage("Campo Confirmar Senha é obrigatório.")
                .Equal(x => x.Senha).WithMessage("As senhas não coincidem.");
        }
    }
}
