using FinancialControl.Domain.Entities;
using FinancialControl.Domain.Interfaces;
using MediatR;

namespace FinancialControl.Application.Queries.Transactions.GetTransactions;

public class GetTransactionsHandler 
    : IRequestHandler<GetTransactionsQuery, IEnumerable<Transaction>>
{

    private readonly ITransactionRepository _repository;


    public GetTransactionsHandler(
        ITransactionRepository repository)
    {
        _repository = repository;
    }



    public async Task<IEnumerable<Transaction>> Handle(
        GetTransactionsQuery request,
        CancellationToken cancellationToken)
    {
        return await _repository
            .GetAllAsync(cancellationToken);
    }
}