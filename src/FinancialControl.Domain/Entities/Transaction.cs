using FinancialControl.Domain.Enums;

namespace FinancialControl.Domain.Entities
{
    public class Transaction
    {
        public Guid Id { get; private set; }

    public string Description { get; private set; }

    public TransactionType Type { get; private set; }

    public decimal Amount { get; private set; }

    public DateTime Date { get; private set; }

    public DateTime CreatedAt { get; private set; }


    //private Transaction()
    //{
        // Necessário para ORM/serialização futuramente
    //}


    public Transaction(
        string description,
        TransactionType type,
        decimal amount,
        DateTime date)
    {
        Validate(description, amount);


        Id = Guid.NewGuid();

        Description = description;

        Type = type;

        Amount = amount;

        Date = date;

        CreatedAt = DateTime.UtcNow;
    }


    private static void Validate(
        string description,
        decimal amount)
    {
        if (string.IsNullOrWhiteSpace(description))
            throw new ArgumentException(
                "Descrição obrigatória.");


        if (amount <= 0)
            throw new ArgumentException(
                "Valor deve ser maior que zero.");
    }


    public void Update(
        string description,
        TransactionType type,
        decimal amount,
        DateTime date)
    {
        Validate(description, amount);

        Description = description;
        Type = type;
        Amount = amount;
        Date = date;
    }
    }
}