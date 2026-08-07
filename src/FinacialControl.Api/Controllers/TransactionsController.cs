using FinancialControl.Application.Commands.Transactions.Create;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using FinancialControl.Application.Queries.Transactions.GetTransactions;
using FinancialControl.Application.Queries.Transactions.GetTransactionById;
using FinancialControl.Application.Commands.Transactions.Update;
using FinancialControl.Application.Commands.Transactions.Delete;

namespace FinacialControl.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TransactionsController : ControllerBase
{
    private readonly IMediator _mediator;


    public TransactionsController(
        IMediator mediator)
    {
        _mediator = mediator;
    }


    [HttpPost]
    public async Task<IActionResult> Create(
        CreateTransactionCommand command)
    {
        var id = await _mediator.Send(command);

        return CreatedAtAction(
            nameof(Create),
            new { id },
            new
            {
                id
            });
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result =
            await _mediator.Send(
                new GetTransactionsQuery());

        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var transaction =
            await _mediator.Send(
                new GetTransactionByIdQuery(id));


        if(transaction == null)
            return NotFound();


        return Ok(transaction);
    }


    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update(
        Guid id,
        UpdateTransactionCommand command)
    {
        if (id != command.Id)
            return BadRequest("O Id da URL é diferente do Id enviado no corpo da requisição.");

        var updated =
            await _mediator.Send(command);

        if (!updated)
            return NotFound();

        return NoContent();
    }


    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var deleted =
            await _mediator.Send(
                new DeleteTransactionCommand
                {
                    Id = id
                });

        if (!deleted)
            return NotFound();

        return NoContent();
    }
}