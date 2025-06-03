using databasTest.Models;
using Microsoft.AspNetCore.Mvc;

namespace databasTest.Controllers;

[ApiController]
[Route("api/[controller]")]
public class HealthCheckController : ControllerBase
{
    private readonly AdventureWorks2022Context _context;

    public HealthCheckController(AdventureWorks2022Context context)
    {
        _context = context;
    }

    [HttpGet("db")]
    public async Task<IActionResult> CheckDatabaseConnection()
    {
        try
        {
            bool canConnect = await _context.Database.CanConnectAsync();
            return Ok(new { status = canConnect ? "Healthy" : "Unhealthy", db = canConnect ? "Connected" : "Cannot connect" });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { status = "Exception", error = ex.Message });
        }
    }
}