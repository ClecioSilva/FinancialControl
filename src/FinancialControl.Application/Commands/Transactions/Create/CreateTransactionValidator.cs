using FluentValidation;

namespace FinancialControl.Application.Commands.Transactions.Create;

public class CreateTransactionValidator
    : AbstractValidator<CreateTransactionCommand>
{
    public CreateTransactionValidator()
    {
        RuleFor(x => x.Description)
            .NotEmpty()
            .WithMessage("A descrição é obrigatória.")
            .MaximumLength(150)
            .WithMessage("A descrição deve possuir no máximo 150 caracteres.");

        RuleFor(x => x.Amount)
            .GreaterThan(0)
            .WithMessage("O valor da transação deve ser maior que zero.");

        RuleFor(x => x.Type)
            .IsInEnum()
            .WithMessage("O tipo da transação informado é inválido.");
    }
}