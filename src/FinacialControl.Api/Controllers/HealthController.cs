using FinancialControl.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;


namespace FinancialControl.Api.Controllers;


[ApiController]
[Route("api/health")]
public class HealthController : ControllerBase
{

    private readonly ITransactionRepository _repository;


    public HealthController(
        ITransactionRepository repository)
    {
        _repository = repository;
    }


    [HttpGet]
    public IActionResult Get()
    {
        return Ok(new
        {
            Status = "API funcionando",
            Repository = _repository.GetType().Name
        });
    }
}