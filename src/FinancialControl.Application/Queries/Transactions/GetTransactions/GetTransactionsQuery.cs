using FinancialControl.Application.DTOs.Transactions;
using MediatR;

namespace FinancialControl.Application.Queries.Transactions.GetTransactions;

public class GetTransactionsQuery 
    : IRequest<IEnumerable<TransactionResponse>>
{
}