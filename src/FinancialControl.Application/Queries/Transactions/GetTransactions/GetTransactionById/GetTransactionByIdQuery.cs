using FinancialControl.Application.DTOs.Transactions;
using FinancialControl.Domain.Entities;
using MediatR;

namespace FinancialControl.Application.Queries.Transactions.GetTransactionById;

public class GetTransactionByIdQuery 
    : IRequest<TransactionResponse?>
{
    public Guid Id { get; }


    public GetTransactionByIdQuery(Guid id)
    {
        Id = id;
    }
}