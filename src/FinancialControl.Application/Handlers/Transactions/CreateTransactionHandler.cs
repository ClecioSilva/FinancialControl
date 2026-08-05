using FinancialControl.Application.Commands.Transactions;
using FinancialControl.Domain.Entities;
using FinancialControl.Domain.Interfaces;
using MediatR;


namespace FinancialControl.Application.Handlers.Transactions;


public class CreateTransactionHandler 
    : IRequestHandler<CreateTransactionCommand, Guid>
{

    private readonly ITransactionRepository _repository;


    public CreateTransactionHandler(
        ITransactionRepository repository)
    {
        _repository = repository;
    }


    public async Task<Guid> Handle(
        CreateTransactionCommand request,
        CancellationToken cancellationToken)
    {

        var transaction = new Transaction(
            request.Description,
            request.Type,
            request.Amount,
            request.Date);


        await _repository.AddAsync(
            transaction,
            cancellationToken);


        return transaction.Id;
    }
}