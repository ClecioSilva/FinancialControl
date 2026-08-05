using FinancialControl.Domain.Enums;
using MediatR;

namespace FinancialControl.Application.Commands.Transactions;


public class CreateTransactionCommand : IRequest<Guid>
{
    public string Description { get; }

    public TransactionType Type { get; }

    public decimal Amount { get; }

    public DateTime Date { get; }


    public CreateTransactionCommand(
        string description,
        TransactionType type,
        decimal amount,
        DateTime date)
    {
        Description = description;
        Type = type;
        Amount = amount;
        Date = date;
    }
}