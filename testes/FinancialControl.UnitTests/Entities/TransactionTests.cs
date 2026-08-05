using FluentAssertions;
using FinancialControl.Domain.Entities;
using FinancialControl.Domain.Enums;

namespace FinancialControl.UnitTests.Entities;


public class TransactionTests
{
    [Fact]
    public void Should_Create_Valid_Transaction()
    {
        var transaction = new Transaction(
            "Venda produto",
            TransactionType.Credit,
            100,
            DateTime.Now);


        transaction.Should().NotBeNull();

        transaction.Description
            .Should()
            .Be("Venda produto");

        transaction.Amount
            .Should()
            .Be(100);
    }



    [Fact]
    public void Should_Not_Create_Transaction_With_Invalid_Value()
    {
        Action action = () =>
            new Transaction(
                "Pagamento",
                TransactionType.Debit,
                -10,
                DateTime.Now);


        action.Should()
            .Throw<ArgumentException>();
    }
}