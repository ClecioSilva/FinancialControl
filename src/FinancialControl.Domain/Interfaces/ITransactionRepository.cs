using FinancialControl.Domain.Entities;

namespace FinancialControl.Domain.Interfaces;

public interface ITransactionRepository
{
    Task AddAsync(
        Transaction transaction,
        CancellationToken cancellationToken = default);


    Task<Transaction?> GetByIdAsync(
        Guid id,
        CancellationToken cancellationToken = default);


    Task<IEnumerable<Transaction>> GetAllAsync(
        CancellationToken cancellationToken = default);
}