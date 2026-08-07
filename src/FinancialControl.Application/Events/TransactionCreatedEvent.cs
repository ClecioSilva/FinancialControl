namespace FinancialControl.Application.Events;

public class TransactionCreatedEvent
{
    public Guid Id { get; init; }

    public string Description { get; init; } = string.Empty;

    public decimal Amount { get; init; }

    public int Type { get; init; }

    public DateTime Date { get; init; }

    public DateTime CreatedAt { get; init; }
}