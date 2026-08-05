using Microsoft.AspNetCore.Mvc;

namespace FinacialControl.Api.Controllers;

    [ApiController]
    [Route("api/[controller]")]
    public class HealthController : ControllerBase
    {
         [HttpGet]
    public IActionResult Get()
    {
        return Ok(new
        {
            status = "API Online",
            application = "Financial Control API",
            version = "1.0.0",
            environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT"),
            timestamp = DateTime.UtcNow
        });
    }
}