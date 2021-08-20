using FluentValidation;

namespace ma9.Business.Models.Validations
{
    public class ClienteValidation : AbstractValidator<Cliente>
    {
        public ClienteValidation()
        {
            RuleFor(cliente => cliente.Nome)
                .NotEmpty()
                    .WithMessage("O campo {PropertyName} precisa ser fornecido.")
                .Length(2,30)
                    .WithMessage("O campo {PropertyName} precisa ter entre {MinLenght} e {MaxLenght} caracteres.");

            RuleFor(cliente => cliente.Sobrenome)
                .NotEmpty()
                    .WithMessage("O campo {PropertyName} precisa ser fornecido.")
                .Length(2, 30)
                    .WithMessage("O campo {PropertyName} precisa ter entre {MinLenght} e {MaxLenght} caracteres.");

            RuleFor(cliente => cliente.Sexo)
                .NotEmpty()
                    .WithMessage("O campo {PropertyName} precisa ser fornecido.");

            RuleFor(cliente => cliente.Cpf.Length)
                .Equal(CpfValidation.TamanhoCpf)
                    .WithMessage("O campo Documento precisa ter {ComparisonValue} caracteres e foi fornecido {PropertyValue}.");
            RuleFor(cliente => CpfValidation.Validar(cliente.Cpf))
                .Equal(true)
                    .WithMessage("O CPF fornecido é inválido.");
        }
    }
}
