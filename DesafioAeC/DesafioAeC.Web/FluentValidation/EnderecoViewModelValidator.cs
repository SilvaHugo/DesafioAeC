using DesafioAeC.Web.ViewModels;
using FluentValidation;

namespace DesafioAeC.Web.FluentValidation
{
    public class EnderecoViewModelValidator : AbstractValidator<EnderecoViewModel>
    {
        public EnderecoViewModelValidator()
        {
            RuleFor(x => x.Cep)
                .NotEmpty().WithMessage("Preencha o campo CEP.")
                .Matches(@"^\d{5}-\d{3}$").WithMessage("Formato inválido para o CEP.");

            RuleFor(x => x.Logradouro)
                .NotEmpty().WithMessage("Preencha o campo Logradouro.")
                .MaximumLength(255).WithMessage("Máximo {MaxLength} caracteres.");

            RuleFor(x => x.Bairro)
                .NotEmpty().WithMessage("Preencha o campo Bairro.")
                .MaximumLength(255).WithMessage("Máximo {MaxLength} caracteres.");

            RuleFor(x => x.Cidade)
                .NotEmpty().WithMessage("Preencha o campo Cidade.")
                .MaximumLength(255).WithMessage("Máximo {MaxLength} caracteres.");

            RuleFor(x => x.Uf)
                .NotEmpty().WithMessage("Preencha o campo UF.")
                .Length(2).WithMessage("Deve ter exatamente {MaxLength} caracteres.");

            RuleFor(x => x.Numero)
                .NotEmpty().WithMessage("Preencha o campo Número.");
        }
    }
}
