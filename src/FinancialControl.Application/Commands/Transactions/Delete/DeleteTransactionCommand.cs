using MediatR;

namespace FinancialControl.Application.Commands.Transactions.Delete;

public class DeleteTransactionCommand : IRequest<bool>
{
    public Guid Id { get; set; }
}