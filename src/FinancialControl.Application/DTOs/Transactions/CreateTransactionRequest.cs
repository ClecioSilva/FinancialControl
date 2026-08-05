using FinancialControl.Domain.Enums;

namespace FinancialControl.Application.DTOs.Transactions;

public class CreateTransactionRequest
{
    public string Description { get; set; } = string.Empty;

    public TransactionType Type { get; set; }

    public decimal Amount { get; set; }

    public DateTime Date { get; set; }
}