using FluentValidation;
using System;

namespace ma9.Business.Models
{
    public class Contato : Entity
    {
        public Guid ClienteId { get; set; }
        public string DDD { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public Cliente Cliente { get; set; }
    }

    public class ContatoValidation : AbstractValidator<Contato>
    {
        public ContatoValidation()
        {
            RuleFor(contato => contato.DDD)
                .NotEmpty()
                    .WithMessage("O campo {PropertyName} precisa ser fornecido.")
                .Length(2)
                    .WithMessage("O campo {PropertyName} precisa ter {MaxLength} caracteres.");

            RuleFor(contato => contato.Telefone)
                .NotEmpty()
                    .WithMessage("O campo {PropertyName} precisa ser fornecido.")
                .Length(9)
                    .WithMessage("O campo {PropertyName} precisa ter {MaxLength} caracteres.");

            RuleFor(contato => contato.Email)
                .NotEmpty()
                    .WithMessage("O campo {PropertyName} precisa ser fornecido.")
                .EmailAddress()
                    .WithMessage("O email fornecido não é válido.");
        }
    }
}
