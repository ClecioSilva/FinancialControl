using FinancialControl.Domain.Enums;
using MediatR;

namespace FinancialControl.Application.Commands.Transactions.Update;

public class UpdateTransactionCommand : IRequest<bool>
{
    public Guid Id { get; set; }

    public string Description { get; set; } = string.Empty;

    public TransactionType Type { get; set; }

    public decimal Amount { get; set; }

    public DateTime Date { get; set; }
}