using FluentValidation;

namespace ma9.Business.Models.Validations
{
    public class ContatoValidation : AbstractValidator<Contato>
    {
        public ContatoValidation()
        {
            RuleFor(contato => contato.DDD)
                .NotEmpty()
                    .WithMessage("O campo {PropertyName} pewcisa ser fornecido.")
                .Length(2)
                    .WithMessage("O campo {PropertyName} precisa ter {MaxLength} caracteres.");

            RuleFor(contato => contato.Telefone)
                .NotEmpty()
                    .WithMessage("O campo {PropertyName} pewcisa ser fornecido.")
                .Length(9)
                    .WithMessage("O campo {PropertyName} precisa ter {MaxLength} caracteres.");

            RuleFor(contato => contato.Email)
                .NotEmpty()
                    .WithMessage("O campo {PropertyName} pewcisa ser fornecido.")
                .EmailAddress()
                    .WithMessage("O email fornecido não é válido.");
        }
    }
}
