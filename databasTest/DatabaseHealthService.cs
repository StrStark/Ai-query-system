using databasTest.Models;

namespace databasTest;

public class DatabaseHealthService
{
    private readonly AdventureWorks2022Context _context;

    public DatabaseHealthService(AdventureWorks2022Context context)
    {
        _context = context;
    }

    public async Task<bool> CanConnectAsync()
    {
        return await _context.Database.CanConnectAsync();
    }
}
