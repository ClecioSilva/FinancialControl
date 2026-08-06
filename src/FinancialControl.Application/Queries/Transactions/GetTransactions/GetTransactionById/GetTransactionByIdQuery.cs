using FinancialControl.Domain.Entities;
using MediatR;

namespace FinancialControl.Application.Queries.Transactions.GetTransactionById;

public class GetTransactionByIdQuery 
    : IRequest<Transaction?>
{
    public Guid Id { get; }


    public GetTransactionByIdQuery(Guid id)
    {
        Id = id;
    }
}