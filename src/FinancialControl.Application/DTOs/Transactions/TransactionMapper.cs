using FinancialControl.Domain.Entities;

namespace FinancialControl.Application.DTOs.Transactions;

public static class TransactionMapper
{
    public static TransactionResponse ToResponse(
        this Transaction transaction)
    {
        return new TransactionResponse
        {
            Id = transaction.Id,
            Description = transaction.Description,
            Type = transaction.Type.ToString(),
            Amount = transaction.Amount,
            Date = transaction.Date,
            CreatedAt = transaction.CreatedAt
        };
    }
}