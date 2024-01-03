using Microsoft.EntityFrameworkCore;
using ResEvi.Data;

namespace Tests.Data;

internal class OptionsManager
{
    public static DbContextOptions<AppDbContext> Options
    {
        get
        {
            return new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
        }
    }
}
