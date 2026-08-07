using FinancialControl.Domain.Interfaces;
using MediatR;

namespace FinancialControl.Application.Commands.Transactions.Update;

public class UpdateTransactionHandler
    : IRequestHandler<UpdateTransactionCommand, bool>
{
    private readonly ITransactionRepository _repository;

    public UpdateTransactionHandler(
        ITransactionRepository repository)
    {
        _repository = repository;
    }

    public async Task<bool> Handle(
        UpdateTransactionCommand request,
        CancellationToken cancellationToken)
    {
        var transaction =
            await _repository.GetByIdAsync(
                request.Id,
                cancellationToken);

        if (transaction is null)
            return false;

        transaction.Update(
            request.Description,
            request.Type,
            request.Amount,
            request.Date);

        await _repository.UpdateAsync(
            transaction,
            cancellationToken);

        return true;
    }
}