using FinancialControl.Application.Commands.Transactions;
using FinancialControl.Application.Handlers.Transactions;
using FinancialControl.Domain.Enums;
using FinancialControl.Domain.Interfaces;
using FluentAssertions;
using Moq;


namespace FinancialControl.UnitTests.Handlers;


public class CreateTransactionHandlerTests
{

    [Fact]
    public async Task Should_Create_Transaction_Successfully()
    {
        // Arrange

        var repositoryMock =
            new Mock<ITransactionRepository>();


        var handler =
            new CreateTransactionHandler(
                repositoryMock.Object);



        var command =
            new CreateTransactionCommand(
                "Venda produto",
                TransactionType.Credit,
                150,
                DateTime.Now);



        // Act

        var result =
            await handler.Handle(
                command,
                CancellationToken.None);



        // Assert

        result.Should()
            .NotBeEmpty();


        repositoryMock.Verify(
            x => x.AddAsync(
                It.IsAny<FinancialControl.Domain.Entities.Transaction>(),
                It.IsAny<CancellationToken>()),
            Times.Once);
    }
}