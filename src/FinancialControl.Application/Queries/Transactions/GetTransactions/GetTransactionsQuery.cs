using FinancialControl.Domain.Entities;
using MediatR;

namespace FinancialControl.Application.Queries.Transactions.GetTransactions;

public class GetTransactionsQuery 
    : IRequest<IEnumerable<Transaction>>
{
}