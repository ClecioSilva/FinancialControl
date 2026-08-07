using FluentValidation;

namespace FinancialControl.Application.Commands.Transactions.Update;

public class UpdateTransactionValidator
    : AbstractValidator<UpdateTransactionCommand>
{
    public UpdateTransactionValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty();

        RuleFor(x => x.Description)
            .NotEmpty()
            .MaximumLength(150);

        RuleFor(x => x.Amount)
            .GreaterThan(0);

        RuleFor(x => x.Type)
            .IsInEnum();
    }
}