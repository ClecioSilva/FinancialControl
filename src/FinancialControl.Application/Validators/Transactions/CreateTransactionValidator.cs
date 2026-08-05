using FluentValidation;
using FinancialControl.Application.Commands.Transactions;


namespace FinancialControl.Application.Validators.Transactions;


public class CreateTransactionValidator 
    : AbstractValidator<CreateTransactionCommand>
{
    public CreateTransactionValidator()
    {
        RuleFor(x => x.Description)
            .NotEmpty()
            .MaximumLength(200);


        RuleFor(x => x.Amount)
            .GreaterThan(0);
    }
}