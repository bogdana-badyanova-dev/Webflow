using Microsoft.EntityFrameworkCore;

namespace Webflow.Infrastructure
{
    public class WebflowContext : DbContext
    {
        public WebflowContext(DbContextOptions<WebflowContext> options)
            : base(options)
        {
        }

        public DbSet<Domain.Files.File> Files { get; set; } = default!;
    }
}
