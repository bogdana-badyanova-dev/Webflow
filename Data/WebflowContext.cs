using Microsoft.EntityFrameworkCore;

namespace Webflow.Data
{
    public class WebflowContext : DbContext
    {
        public WebflowContext (DbContextOptions<WebflowContext> options)
            : base(options)
        {
        }

        public DbSet<Models.File> Files { get; set; } = default!;
    }
}
