using FinancialControl.Domain.Entities;
using FinancialControl.Domain.Interfaces;
using MediatR;

namespace FinancialControl.Application.Queries.Transactions.GetTransactionById;

public class GetTransactionByIdHandler
    : IRequestHandler<GetTransactionByIdQuery, Transaction?>
{

    private readonly ITransactionRepository _repository;


    public GetTransactionByIdHandler(
        ITransactionRepository repository)
    {
        _repository = repository;
    }


    public async Task<Transaction?> Handle(
        GetTransactionByIdQuery request,
        CancellationToken cancellationToken)
    {
        return await _repository.GetByIdAsync(
            request.Id,
            cancellationToken);
    }
}