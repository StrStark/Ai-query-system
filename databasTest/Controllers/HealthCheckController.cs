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
        bool canConnect = await _context.Database.CanConnectAsync();
        if (canConnect)
            return Ok(new { status = "Healthy", db = "Connected" });
        else
            return StatusCode(500, new { status = "Unhealthy", db = "Cannot connect" });
    }
}