namespace FinancialControl.Application.DTOs.Transactions;

public class TransactionResponse
{
    public Guid Id { get; set; }

    public string Description { get; set; } = string.Empty;

    public string Type { get; set; } = string.Empty;

    public decimal Amount { get; set; }

    public DateTime Date { get; set; }

    public DateTime CreatedAt { get; set; }
}