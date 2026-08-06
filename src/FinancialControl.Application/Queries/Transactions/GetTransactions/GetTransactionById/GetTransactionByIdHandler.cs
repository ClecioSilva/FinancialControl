using FinancialControl.Application.DTOs.Transactions;
using FinancialControl.Domain.Interfaces;
using MediatR;

namespace FinancialControl.Application.Queries.Transactions.GetTransactionById;

public class GetTransactionByIdHandler
    : IRequestHandler<GetTransactionByIdQuery, TransactionResponse?>
{
    private readonly ITransactionRepository _repository;


    public GetTransactionByIdHandler(
        ITransactionRepository repository)
    {
        _repository = repository;
    }


    public async Task<TransactionResponse?> Handle(
        GetTransactionByIdQuery request,
        CancellationToken cancellationToken)
    {
        var transaction =
            await _repository.GetByIdAsync(
                request.Id,
                cancellationToken);


        return transaction?.ToResponse();
    }
}