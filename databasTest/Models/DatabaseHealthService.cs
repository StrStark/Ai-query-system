
namespace databasTest;

public class DatabaseHealthService
{
    private readonly RsvpContext _context;

    public DatabaseHealthService(RsvpContext context)
    {
        _context = context;
    }

    public async Task<bool> CanConnectAsync()
    {
        return await _context.Database.CanConnectAsync();
    }
}
