using databasTest.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
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
            using (var connection = new SqlConnection("Server=91.107.162.209,1433;Database=AdventureWorks2022;User Id=sa;Password=Mr5568###;TrustServerCertificate=true;Encrypt=false;"))
            {
                await connection.OpenAsync();
            }
            return Ok(new { status = "Healthy", db = "Connected" });
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