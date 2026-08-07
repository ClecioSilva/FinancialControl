using FinancialControl.Domain.Entities;
using FinancialControl.Domain.Interfaces;
using MediatR;
using FinancialControl.Application.Events;
using FinancialControl.Application.Messaging;

namespace FinancialControl.Application.Commands.Transactions.Create;

public class CreateTransactionHandler
    : IRequestHandler<CreateTransactionCommand, Guid>
{
    private readonly ITransactionRepository _repository;
    private readonly IMessagePublisher _publisher;

    public CreateTransactionHandler(
        ITransactionRepository repository,
        IMessagePublisher publisher)
    {
        _repository = repository;
        _publisher = publisher;
    }

    public async Task<Guid> Handle(
        CreateTransactionCommand request,
        CancellationToken cancellationToken)
        {
        var transaction = new Transaction(
            request.Description,
            request.Type,
            request.Amount,
            request.Date
        );


        await _repository.AddAsync(
            transaction,
            cancellationToken);


        var transactionEvent =
            new TransactionCreatedEvent
            {
                Id = transaction.Id,
                Description = transaction.Description,
                Amount = transaction.Amount,
                Type = (int)transaction.Type,
                Date = transaction.Date,
                CreatedAt = transaction.CreatedAt
            };


        await _publisher.PublishAsync(
            transactionEvent,
            cancellationToken);


        return transaction.Id;
    }
}