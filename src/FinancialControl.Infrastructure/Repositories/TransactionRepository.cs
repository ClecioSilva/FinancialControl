using FinancialControl.Domain.Entities;
using FinancialControl.Domain.Interfaces;
using FinancialControl.Infrastructure.Mongo;
using MongoDB.Driver;


namespace FinancialControl.Infrastructure.Repositories;


public class TransactionRepository 
    : ITransactionRepository
{

    private readonly MongoContext _context;


    public TransactionRepository(
        MongoContext context)
    {
        _context = context;
    }

    public async Task AddAsync(
        Transaction transaction,
        CancellationToken cancellationToken = default)
    {
        await _context.Transactions
            .InsertOneAsync(
                transaction,
                cancellationToken: cancellationToken);
    }

    public async Task<Transaction?> GetByIdAsync(
        Guid id,
        CancellationToken cancellationToken = default)
    {
        return await _context.Transactions
            .Find(x => x.Id == id)
            .FirstOrDefaultAsync(
                cancellationToken);
    }



    public async Task<IEnumerable<Transaction>> GetAllAsync(
        CancellationToken cancellationToken = default)
    {
        return await _context.Transactions
            .Find(_ => true)
            .ToListAsync(
                cancellationToken);
    }


    public async Task UpdateAsync(
        Transaction transaction,
        CancellationToken cancellationToken = default)
    {
        await _context.Transactions.ReplaceOneAsync(
            x => x.Id == transaction.Id,
            transaction,
            cancellationToken: cancellationToken);
    }


    public async Task DeleteAsync(
        Guid id,
        CancellationToken cancellationToken = default)
    {
        await _context.Transactions.DeleteOneAsync(
            x => x.Id == id,
            cancellationToken);
    }
}