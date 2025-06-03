using databasTest.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
            // Try opening a raw ADO.NET connection to get detailed errors
            using (var connection = _context.Database.GetDbConnection())
            {
                await connection.OpenAsync(); // This will throw if something is wrong
            }

            return Ok(new
            {
                status = "Healthy",
                db = "Connected"
            });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new
            {
                status = "Unhealthy",
                db = "Cannot connect",
                error = ex.GetType().Name,
                message = ex.Message,
                inner = ex.InnerException?.Message
            });
        }
    }

}