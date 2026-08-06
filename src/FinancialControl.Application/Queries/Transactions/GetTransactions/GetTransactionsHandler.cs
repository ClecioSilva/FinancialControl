using FinancialControl.Application.DTOs.Transactions;
using FinancialControl.Domain.Interfaces;
using MediatR;

namespace FinancialControl.Application.Queries.Transactions.GetTransactions;

public class GetTransactionsHandler
    : IRequestHandler<GetTransactionsQuery, IEnumerable<TransactionResponse>>
{
    private readonly ITransactionRepository _repository;


    public GetTransactionsHandler(
        ITransactionRepository repository)
    {
        _repository = repository;
    }


    public async Task<IEnumerable<TransactionResponse>> Handle(
        GetTransactionsQuery request,
        CancellationToken cancellationToken)
    {
        var transactions =
            await _repository.GetAllAsync(
                cancellationToken);


        return transactions
            .Select(x => x.ToResponse());
    }
}