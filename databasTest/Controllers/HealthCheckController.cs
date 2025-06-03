using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
namespace databasTest.Controllers;

[ApiController]
[Route("api/[controller]")]
public class HealthCheckController : ControllerBase
{
    private readonly RsvpContext _context;
    public HealthCheckController(RsvpContext context)
    {
        _context = context;
    }
    [HttpGet("db")]
    public async Task<IActionResult> CheckDatabaseConnection()
    {
        try
        {
            using (var conn = _context.Database.GetDbConnection())
            {
                await conn.OpenAsync();
            }
            return Ok(new { status = "Healthy", db = "Connected" });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new
            {
                status = "Unhealthy",
                db = "EF failed",
                error = ex.GetType().Name,
                message = ex.Message,
                inner = ex.InnerException?.Message
            });
        }
    }
}