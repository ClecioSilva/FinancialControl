using FinancialControl.Domain.Interfaces;
using MediatR;

namespace FinancialControl.Application.Commands.Transactions.Delete;

public class DeleteTransactionHandler
    : IRequestHandler<DeleteTransactionCommand, bool>
{
    private readonly ITransactionRepository _repository;

    public DeleteTransactionHandler(
        ITransactionRepository repository)
    {
        _repository = repository;
    }

    public async Task<bool> Handle(
        DeleteTransactionCommand request,
        CancellationToken cancellationToken)
    {
        var transaction =
            await _repository.GetByIdAsync(
                request.Id,
                cancellationToken);

        if (transaction is null)
            return false;

        await _repository.DeleteAsync(
            request.Id,
            cancellationToken);

        return true;
    }
}